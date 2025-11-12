# Langfuse C# Client

Типизированный C# SDK для работы с Langfuse API, сгенерированный из OpenAPI спецификации с помощью OpenAPI Generator.

## Структура

```
langfuse-csharp-client/
├── langfuse-openapi.yml          # OpenAPI спецификация
├── scripts/
│   └── generate-openapi-client.sh    # Скрипт генерации SDK
├── src/Langfuse.Client/          # Сгенерированная библиотека (gitignored)
├── docs/                          # Сгенерированная документация (gitignored)
├── api/                           # Копия OpenAPI spec (gitignored)
├── SimpleExample/                # Пример с HTTP запросами
└── Example/                      # Пример использования
```

## Быстрый старт

### Вариант 1: Типизированный клиент (рекомендуется)

#### 1. Настроить credentials

Отредактируйте `Example/Example/appsettings.json`:

```json
{
  "Langfuse": {
    "BaseUrl": "https://hipaa.cloud.langfuse.com",
    "PublicKey": "pk-lf-...",
    "SecretKey": "sk-lf-..."
  }
}
```

#### 2. Запустить пример

```bash
cd Example/Example
dotnet run
```

#### 3. Возможности типизированного клиента

Пример демонстрирует:
- ✅ **PromptsApi** - получение промптов с полной типизацией
- ✅ **MediaApi** - загрузка изображений (BloodGPT logo) с дедупликацией по SHA256
- ✅ **IngestionApi** - создание traces, generations и scores
- ✅ **Prompt linking** - связывание generation с промптами
- ✅ **Media references** - прикрепление изображений к traces
- ✅ **IntelliSense** - полная поддержка автодополнения
- ✅ **Type safety** - ошибки на этапе компиляции

### Вариант 2: HTTP клиент (legacy)

```bash
cd SimpleExample
dotnet run
```

## Генерация SDK

### Требования

- .NET 8.0 SDK
- Docker (для OpenAPI Generator) или npm

### Шаги генерации

```bash
# 1. Обновить OpenAPI спецификацию (если нужно)
wget https://cloud.langfuse.com/generated/api/openapi.yml -O langfuse-openapi.yml

# 2. Запустить генерацию
cd scripts
./generate-openapi-client.sh
```

Скрипт автоматически:
- ✅ Генерирует клиент с префиксом `Lf`
- ✅ Применяет исправления (GetInt?() → GetIntNullable())
- ✅ Собирает проект
- ✅ Размещает в `src/Langfuse.Client/`

### Префикс Lf в моделях

Все модели генерируются с префиксом `Lf`:

```csharp
// В коде используйте:
var trace = new LfTraceBody(id: "...", name: "...");
var generation = new LfCreateGenerationBody(id: "...", traceId: "...", name: "...");
var score = new LfScoreBody(id: "...", traceId: "...", name: "...", value: ...);
```

Это избегает конфликт namespace: класс `Model` внутри `Langfuse.Client.Model`

## Использование типизированного клиента

### Инициализация

```csharp
using Langfuse.Client.Api;
using Langfuse.Client.Client;
using Langfuse.Client.Model;

var config = new Configuration
{
    BasePath = "https://hipaa.cloud.langfuse.com",
    Username = "pk-lf-...",  // Public Key
    Password = "sk-lf-..."   // Secret Key
};

var promptsApi = new PromptsApi(config);
var ingestionApi = new IngestionApi(config);
var mediaApi = new MediaApi(config);
```

### Получение промптов

```csharp
// Список промптов
var promptsResponse = await promptsApi.PromptsListAsync(
    page: 1,
    limit: 10
);

foreach (var prompt in promptsResponse.Data)
{
    Console.WriteLine($"{prompt.Name} - v{string.Join(", v", prompt.Versions)}");
}

// Получить конкретный промпт
var promptDetail = await promptsApi.PromptsGetAsync(
    promptName: "my-prompt",
    label: "production"
);
```

### Загрузка изображений

```csharp
// 1. Загрузить файл и вычислить SHA256
byte[] imageBytes = await File.ReadAllBytesAsync("logo.png");
string sha256Hash;
using (var sha256 = SHA256.Create())
{
    sha256Hash = Convert.ToBase64String(sha256.ComputeHash(imageBytes));
}

// 2. Запросить upload URL
var uploadRequest = new LfGetMediaUploadUrlRequest(
    traceId: traceId,
    observationId: null,
    contentType: LfMediaContentType.ImagePng,
    contentLength: imageBytes.Length,
    sha256Hash: sha256Hash,
    field: "input"
);

var uploadResponse = await mediaApi.MediaGetUploadUrlAsync(uploadRequest);

// 3. Загрузить в S3 (если нужно - может вернуть null при дедупликации)
if (!string.IsNullOrEmpty(uploadResponse.UploadUrl))
{
    var content = new ByteArrayContent(imageBytes);
    content.Headers.ContentType = new MediaTypeHeaderValue("image/png");
    content.Headers.Add("x-amz-checksum-sha256", sha256Hash);

    var uploadResult = await httpClient.PutAsync(uploadResponse.UploadUrl, content);

    // 4. Подтвердить загрузку
    await mediaApi.MediaPatchAsync(
        uploadResponse.MediaId,
        new LfPatchMediaBody(
            uploadedAt: DateTime.UtcNow,
            uploadHttpStatus: (int)uploadResult.StatusCode
        )
    );
}
```

### Создание traces с generations

```csharp
var traceId = Guid.NewGuid().ToString();
var timestamp = DateTime.UtcNow;

// Trace с изображением
var traceBody = new LfTraceBody(
    id: traceId,
    name: "my-trace"
)
{
    Input = new {
        question = "What is this?",
        image = $"@@@langfuseMedia:image/png|||{mediaId}@@@"
    },
    Output = new { answer = "It's a logo!" },
    VarEnvironment = "production",
    Tags = new List<string> { "with-image" }
};

var traceEvent = new LfIngestionEventOneOf(
    body: traceBody,
    id: Guid.NewGuid().ToString(),
    timestamp: timestamp.ToString("yyyy-MM-dd'T'HH:mm:ss.fff'Z'"),
    metadata: null,
    type: LfIngestionEventOneOf.TypeEnum.TraceCreate
);

// Generation с линком к промпту
var generationBody = new LfCreateGenerationBody(
    id: Guid.NewGuid().ToString(),
    traceId: traceId,
    name: "llm-call"
)
{
    Model = "gpt-4",
    VarEnvironment = "production",
    Input = new[] { new { role = "user", content = "Hello" } },
    Output = new { role = "assistant", content = "Hi!" },
    Usage = new LfIngestionUsage(new LfUsage {
        Input = 10,
        Output = 5,
        Total = 15
    }),
    PromptName = "my-prompt",
    PromptVersion = 1
};

var generationEvent = new LfIngestionEventOneOf4(
    body: generationBody,
    id: Guid.NewGuid().ToString(),
    timestamp: timestamp.AddMilliseconds(100).ToString("yyyy-MM-dd'T'HH:mm:ss.fff'Z'"),
    metadata: null,
    type: LfIngestionEventOneOf4.TypeEnum.GenerationCreate
);

// Score
var scoreBody = new LfScoreBody(
    id: Guid.NewGuid().ToString(),
    traceId: traceId,
    name: "quality",
    value: new LfCreateScoreValue(0.95)
)
{
    VarEnvironment = "production",
    Comment = "Excellent"
};

var scoreEvent = new LfIngestionEventOneOf1(
    body: scoreBody,
    id: Guid.NewGuid().ToString(),
    timestamp: timestamp.AddMilliseconds(200).ToString("yyyy-MM-dd'T'HH:mm:ss.fff'Z'"),
    metadata: null,
    type: LfIngestionEventOneOf1.TypeEnum.ScoreCreate
);

// Отправить batch
var batchRequest = new LfIngestionBatchRequest(
    batch: new List<LfIngestionEvent>
    {
        new LfIngestionEvent(traceEvent),
        new LfIngestionEvent(generationEvent),
        new LfIngestionEvent(scoreEvent)
    },
    metadata: null
);

var response = await ingestionApi.IngestionBatchAsync(batchRequest);
Console.WriteLine($"Successes: {response.Successes.Count}, Errors: {response.Errors.Count}");
```

### Media reference format

Формат ссылки на media в trace/observation input/output:

```
@@@langfuseMedia:{contentType}|||{mediaId}@@@
```

Примеры:
- `@@@langfuseMedia:image/png|||C9E-jA9753sY4imf5GfSJc@@@`
- `@@@langfuseMedia:image/jpeg|||AbC123xyz@@@`
- `@@@langfuseMedia:video/mp4|||XyZ789abc@@@`

## Преимущества типизированного клиента

| Возможность | HTTP клиент | Типизированный клиент |
|-------------|-------------|----------------------|
| Типизация | ❌ dynamic/anonymous | ✅ Полная типизация |
| IntelliSense | ❌ Нет | ✅ Полная поддержка |
| Compile-time проверки | ❌ Runtime ошибки | ✅ Compile-time ошибки |
| Рефакторинг | ❌ Сложно | ✅ Безопасный |
| Документация | ❌ В коде | ✅ XML комментарии |
| API Discovery | ❌ Нужно искать вручную | ✅ Автодополнение |

## Ссылки

- [Langfuse Documentation](https://langfuse.com/docs)
- [API Reference](https://api.reference.langfuse.com)
- [Multi-modality Guide](https://langfuse.com/docs/observability/features/multi-modality)
- [OpenAPI Generator](https://openapi-generator.tech/docs/generators/csharp)
