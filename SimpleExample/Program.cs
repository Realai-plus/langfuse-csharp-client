using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SimpleExample
{
    class Program
    {
        // Конфигурация Langfuse
        private const string LANGFUSE_BASE_URL = "https://hipaa.cloud.langfuse.com";
        private const string LANGFUSE_PUBLIC_KEY = "pk-lf-716d83ad-fb2e-426b-9dd3-33376055c38b";
        private const string LANGFUSE_SECRET_KEY = "sk-lf-32ca876e-c29a-4359-82bb-eb655a4a0565";

        // Путь к логотипу BloodGPT
        private const string LOGO_PATH = "/home/i/JOBS/BloodGPT/bloodgpt-for-labs/apps/bulk-bloodgpt/public/images/logo.png";

        static async Task Main(string[] args)
        {
            Console.WriteLine("=== Langfuse API Example ===\n");

            using var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(LANGFUSE_BASE_URL);
            
            // Настройка Basic Auth
            var authValue = Convert.ToBase64String(
                Encoding.UTF8.GetBytes($"{LANGFUSE_PUBLIC_KEY}:{LANGFUSE_SECRET_KEY}")
            );
            httpClient.DefaultRequestHeaders.Authorization = 
                new AuthenticationHeaderValue("Basic", authValue);
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                // 1. ПОЛУЧЕНИЕ ПРОМПТОВ
                Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                Console.WriteLine("📋 STEP 1: Fetch Prompts");
                Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━\n");
                var promptInfo = await FetchPrompts(httpClient);

                // 2. ГЕНЕРАЦИЯ TRACE ID (СНАЧАЛА!)
                var traceId = Guid.NewGuid().ToString();
                Console.WriteLine($"\n🆔 Generated Trace ID: {traceId}");

                // 3. ЗАГРУЗКА ИЗОБРАЖЕНИЯ (С ПРАВИЛЬНЫМ TRACE ID!)
                Console.WriteLine("\n━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                Console.WriteLine("🖼️  STEP 2: Upload BloodGPT Logo");
                Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━\n");

                string logoMediaId = null;
                if (File.Exists(LOGO_PATH))
                {
                    byte[] logoBytes = File.ReadAllBytes(LOGO_PATH);
                    Console.WriteLine($"📷 Logo: {logoBytes.Length:N0} bytes ({logoBytes.Length / 1024.0:F1} KB)");
                    logoMediaId = await UploadMedia(httpClient, traceId, logoBytes, "image/png");

                    if (!string.IsNullOrEmpty(logoMediaId))
                    {
                        Console.WriteLine($"✅ Logo uploaded: {logoMediaId}");
                    }
                }
                else
                {
                    Console.WriteLine($"⚠️  Logo not found: {LOGO_PATH}");
                }

                // 4. ОТПРАВКА TRACE С ИЗОБРАЖЕНИЕМ И ПРОМПТОМ (С ТЕМ ЖЕ TRACE ID!)
                Console.WriteLine("\n━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                Console.WriteLine("📤 STEP 3: Send Trace with Media & Prompt Link");
                Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━\n");
                await SendTrace(httpClient, traceId, logoMediaId, promptInfo);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine($"Stack: {ex.StackTrace}");
            }
        }

        static async Task<(string name, int version, string content)> FetchPrompts(HttpClient httpClient)
        {
            Console.WriteLine("📋 FETCHING PROMPTS:\n");

            string promptName = null;
            int promptVersion = 0;
            string promptContent = null;

            // Получить список промптов
            var response = await httpClient.GetAsync("/api/public/v2/prompts");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                dynamic result = JsonConvert.DeserializeObject(content);

                if (result?.data != null && result.data.Count > 0)
                {
                    var firstPrompt = result.data[0];
                    Console.WriteLine($"• Prompt: {firstPrompt.name}");
                    Console.WriteLine($"  Version: {firstPrompt.version}");
                    Console.WriteLine($"  Labels: {string.Join(", ", firstPrompt.labels ?? new List<string>())}");
                    Console.WriteLine();

                    promptName = firstPrompt.name;

                    // Получить детали первого промпта
                    if (promptName != null)
                    {
                        var details = await GetPromptDetails(httpClient, promptName);
                        if (details.version > 0)
                        {
                            promptVersion = details.version;
                            promptContent = details.content;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No prompts found. Create some in Langfuse UI first.");
                }
            }
            else
            {
                Console.WriteLine($"Failed to fetch prompts: {response.StatusCode}");
                var error = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error: {error}");
            }

            return (promptName, promptVersion, promptContent);
        }

        static async Task<(int version, string content)> GetPromptDetails(HttpClient httpClient, string promptName)
        {
            Console.WriteLine($"📄 PROMPT DETAILS for '{promptName}':\n");

            int version = 0;
            string fullContent = null;

            var response = await httpClient.GetAsync($"/api/public/v2/prompts/{promptName}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                dynamic prompt = JsonConvert.DeserializeObject(content);

                Console.WriteLine($"  Type: {prompt.type}");
                Console.WriteLine($"  Version: {prompt.version}");

                version = (int)prompt.version;

                if (prompt.prompt != null)
                {
                    var promptText = JsonConvert.SerializeObject(prompt.prompt, Formatting.Indented);
                    fullContent = promptText;
                    Console.WriteLine($"  Content: {promptText.Substring(0, Math.Min(500, promptText.Length))}...");
                }

                if (prompt.config != null)
                {
                    Console.WriteLine($"  Config: {JsonConvert.SerializeObject(prompt.config, Formatting.Indented)}");
                }

                Console.WriteLine();
            }

            return (version, fullContent);
        }

        static object CreateGenerationBody(string traceId, (string name, int version, string content)? promptInfo)
        {
            var generationBody = new Dictionary<string, object>
            {
                ["id"] = Guid.NewGuid().ToString(),
                ["traceId"] = traceId,
                ["name"] = "llm-call-with-prompt",
                ["startTime"] = DateTime.UtcNow.AddMilliseconds(100).ToString("yyyy-MM-dd'T'HH:mm:ss.fff'Z'"),
                ["endTime"] = DateTime.UtcNow.AddMilliseconds(1500).ToString("yyyy-MM-dd'T'HH:mm:ss.fff'Z'"),
                ["model"] = "gpt-3.5-turbo",
                ["modelParameters"] = new
                {
                    temperature = 0.7,
                    max_tokens = 150
                },
                ["input"] = new object[]
                {
                    new { role = "system", content = "You are a helpful assistant." },
                    new { role = "user", content = "What is Langfuse?" }
                },
                ["output"] = new { role = "assistant", content = "Langfuse is an LLM observability platform." },
                ["usage"] = new
                {
                    input = 20,
                    output = 10,
                    total = 30
                }
            };

            // ЛИНКУЕМ К ПРОМПТУ!
            if (promptInfo.HasValue && !string.IsNullOrEmpty(promptInfo.Value.name))
            {
                generationBody["promptName"] = promptInfo.Value.name;
                generationBody["promptVersion"] = promptInfo.Value.version;

                Console.WriteLine($"\n🔗 Linking generation to prompt:");
                Console.WriteLine($"   Prompt: {promptInfo.Value.name}");
                Console.WriteLine($"   Version: {promptInfo.Value.version}");
            }

            return generationBody;
        }

        static async Task<string> UploadMedia(HttpClient httpClient, string traceId, byte[] fileBytes, string contentType)
        {
            try
            {
                // Вычислить SHA256
                string sha256Hash;
                using (var sha256 = SHA256.Create())
                {
                    byte[] hashBytes = sha256.ComputeHash(fileBytes);
                    sha256Hash = Convert.ToBase64String(hashBytes);
                }

                Console.WriteLine($"   🔗 Linking media to trace: {traceId}");

                // Запросить upload URL (с ПРАВИЛЬНЫМ trace ID!)
                var requestBody = new
                {
                    traceId = traceId,
                    contentType = contentType,
                    contentLength = fileBytes.Length,
                    sha256Hash = sha256Hash,
                    field = "input"
                };

                var json = JsonConvert.SerializeObject(requestBody);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("/api/public/media", content);

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"❌ Failed to get upload URL: {response.StatusCode}");
                    return null;
                }

                var responseContent = await response.Content.ReadAsStringAsync();
                dynamic result = JsonConvert.DeserializeObject(responseContent);

                string mediaId = result.mediaId;
                string uploadUrl = result.uploadUrl;

                // Загрузить файл, если нужно
                if (uploadUrl != null)
                {
                    using (var uploadClient = new HttpClient())
                    {
                        var uploadContent = new ByteArrayContent(fileBytes);
                        uploadContent.Headers.ContentType = new MediaTypeHeaderValue(contentType);
                        uploadContent.Headers.Add("x-amz-checksum-sha256", sha256Hash);

                        var uploadStartTime = DateTime.UtcNow;
                        var uploadResponse = await uploadClient.PutAsync(uploadUrl, uploadContent);
                        var uploadDuration = (DateTime.UtcNow - uploadStartTime).TotalMilliseconds;

                        if (uploadResponse.IsSuccessStatusCode)
                        {
                            Console.WriteLine($"   ⬆️  Uploaded to S3 ({uploadDuration:F0}ms)");

                            // Обновить статус
                            var patchBody = new
                            {
                                uploadedAt = DateTime.UtcNow.ToString("yyyy-MM-dd'T'HH:mm:ss.fff'Z'"),
                                uploadHttpStatus = (int)uploadResponse.StatusCode,
                                uploadTimeMs = (int)uploadDuration
                            };

                            var patchJson = JsonConvert.SerializeObject(patchBody);
                            var patchContent = new StringContent(patchJson, Encoding.UTF8, "application/json");
                            await httpClient.PatchAsync($"/api/public/media/{mediaId}", patchContent);
                        }
                        else
                        {
                            Console.WriteLine($"   ❌ Upload failed: {uploadResponse.StatusCode}");
                            return null;
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"   ℹ️  Already in storage (deduplication)");
                }

                return mediaId;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Upload error: {ex.Message}");
                return null;
            }
        }

        static async Task SendTrace(HttpClient httpClient, string traceId, string logoMediaId = null, (string name, int version, string content)? promptInfo = null)
        {
            Console.WriteLine("📤 SENDING TRACE VIA INGESTION:\n");
            Console.WriteLine($"   Using Trace ID: {traceId}");
            var timestamp = DateTime.UtcNow.ToString("yyyy-MM-dd'T'HH:mm:ss.fff'Z'");

            // Подготовить input с изображением если есть
            object inputData;
            if (!string.IsNullOrEmpty(logoMediaId))
            {
                var mediaRef = $"@@@langfuseMedia:image/png|||{logoMediaId}@@@";
                inputData = new
                {
                    question = "What is Langfuse?",
                    logo = mediaRef,
                    note = "BloodGPT logo attached"
                };
                Console.WriteLine($"📎 Attaching logo to trace: {mediaRef}");
            }
            else
            {
                inputData = new { question = "What is Langfuse?" };
            }

            var ingestionData = new
            {
                batch = new object[]
                {
                    // Создание trace
                    new
                    {
                        id = Guid.NewGuid().ToString(),
                        type = "trace-create",
                        timestamp = timestamp,
                        body = new
                        {
                            id = traceId,
                            name = "test-trace-csharp-with-logo",
                            input = inputData,
                            output = new { answer = "Langfuse is an LLM observability platform." },
                            metadata = new Dictionary<string, object>
                            {
                                ["environment"] = "production",
                                ["client"] = "csharp-example",
                                ["version"] = "1.0.0",
                                ["hasLogo"] = !string.IsNullOrEmpty(logoMediaId),
                                ["logoMediaId"] = logoMediaId ?? "none"
                            },
                            tags = new[] { "test", "example", "csharp" },
                            sessionId = $"session-{Guid.NewGuid().ToString().Substring(0, 8)}",
                            userId = "test-user-123"
                        }
                    },
                    // Добавление generation (LLM вызов) - ЛИНКОВАН К ПРОМПТУ!
                    new
                    {
                        id = Guid.NewGuid().ToString(),
                        type = "generation-create",
                        timestamp = DateTime.UtcNow.AddMilliseconds(100).ToString("yyyy-MM-dd'T'HH:mm:ss.fff'Z'"),
                        body = CreateGenerationBody(traceId, promptInfo)
                    },
                    // Добавление score
                    new
                    {
                        id = Guid.NewGuid().ToString(),
                        type = "score-create",
                        timestamp = DateTime.UtcNow.AddMilliseconds(2000).ToString("yyyy-MM-dd'T'HH:mm:ss.fff'Z'"),
                        body = new
                        {
                            id = Guid.NewGuid().ToString(),
                            traceId = traceId,
                            name = "quality",
                            value = 0.9,
                            comment = "High quality response"
                        }
                    }
                }
            };

            var json = JsonConvert.SerializeObject(ingestionData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            
            var response = await httpClient.PostAsync("/api/public/ingestion", content);
            
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                dynamic result = JsonConvert.DeserializeObject(responseContent);
                
                Console.WriteLine($"✅ Successfully sent trace!");
                Console.WriteLine($"   Trace ID: {traceId}");
                
                if (result?.successes != null)
                {
                    Console.WriteLine($"   Successful events: {result.successes.Count}");
                }
                
                if (result?.errors != null && result.errors.Count > 0)
                {
                    Console.WriteLine($"   Failed events: {result.errors.Count}");
                    foreach (var error in result.errors)
                    {
                        Console.WriteLine($"     - {error.id}: {error.error}");
                    }
                }
                
                Console.WriteLine($"\n📊 View trace in Langfuse UI:");
                Console.WriteLine($"   {LANGFUSE_BASE_URL}/project/<your-project>/traces/{traceId}");
            }
            else
            {
                Console.WriteLine($"❌ Failed to send trace: {response.StatusCode}");
                var error = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"   Error: {error}");
            }
        }
    }
}