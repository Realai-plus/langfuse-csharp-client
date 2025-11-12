using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Langfuse.Client;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace TypedExample
{
    class Program
    {
        // Конфигурация Langfuse
        private const string LANGFUSE_BASE_URL = "https://hipaa.cloud.langfuse.com";
        private const string LANGFUSE_PUBLIC_KEY = "pk-lf-716d83ad-fb2e-426b-9dd3-33376055c38b";
        private const string LANGFUSE_SECRET_KEY = "sk-lf-32ca876e-c29a-4359-82bb-eb655a4a0565";

        static async Task Main(string[] args)
        {
            Console.WriteLine("=== Langfuse Typed Client Example ===\n");
            Console.WriteLine("Using GENERATED client with full type safety!\n");

            // Настройка DI контейнера
            var services = new ServiceCollection();

            // Регистрация HttpClient с Basic Auth
            services.AddHttpClient("LangfuseClient", client =>
            {
                client.BaseAddress = new Uri(LANGFUSE_BASE_URL);

                var authValue = Convert.ToBase64String(
                    Encoding.UTF8.GetBytes($"{LANGFUSE_PUBLIC_KEY}:{LANGFUSE_SECRET_KEY}")
                );
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Basic", authValue);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
            });

            var serviceProvider = services.BuildServiceProvider();
            var httpClientFactory = serviceProvider.GetRequiredService<IHttpClientFactory>();
            var httpClient = httpClientFactory.CreateClient("LangfuseClient");

            // Создаем типизированный клиент
            var langfuseClient = new LangfuseClient(httpClient);

            try
            {
                // ============================================
                // 1. ПОЛУЧЕНИЕ ПРОМПТОВ (Typed Methods)
                // ============================================
                Console.WriteLine("📋 FETCHING PROMPTS (using typed client):\n");

                // Типизированный метод ListAsync с IntelliSense!
                var promptsResponse = await langfuseClient.ListAsync(
                    name: null,  // фильтр по имени
                    label: null, // фильтр по label
                    tag: null,   // фильтр по тегу
                    page: 1,
                    limit: 10,
                    fromUpdatedAt: null,
                    toUpdatedAt: null
                );

                if (promptsResponse.Result?.Data != null && promptsResponse.Result.Data.Count > 0)
                {
                    Console.WriteLine($"Found {promptsResponse.Result.Data.Count} prompts:\n");

                    foreach (var promptMeta in promptsResponse.Result.Data)
                    {
                        Console.WriteLine($"• Prompt: {promptMeta.Name}");
                        Console.WriteLine($"  Version: {promptMeta.Version}");
                        if (promptMeta.Labels != null && promptMeta.Labels.Count > 0)
                        {
                            Console.WriteLine($"  Labels: {string.Join(", ", promptMeta.Labels)}");
                        }
                        if (promptMeta.Tags != null && promptMeta.Tags.Count > 0)
                        {
                            Console.WriteLine($"  Tags: {string.Join(", ", promptMeta.Tags)}");
                        }
                        Console.WriteLine();
                    }

                    // Получить детали первого промпта
                    var firstPromptName = promptsResponse.Result.Data[0].Name;
                    Console.WriteLine($"\n📄 PROMPT DETAILS (typed GetAsync method):\n");

                    // Типизированный метод GetAsync с IntelliSense!
                    var promptDetail = await langfuseClient.GetAsync(
                        promptName: firstPromptName,
                        version: null,  // null = latest
                        label: "production" // или "staging", "latest"
                    );

                    if (promptDetail.Result != null)
                    {
                        var prompt = promptDetail.Result;
                        Console.WriteLine($"  Name: {prompt.Name}");
                        Console.WriteLine($"  Version: {prompt.Version}");
                        Console.WriteLine($"  Type: {prompt.Type}");

                        if (prompt.Labels != null && prompt.Labels.Count > 0)
                        {
                            Console.WriteLine($"  Labels: {string.Join(", ", prompt.Labels)}");
                        }

                        if (prompt.Config != null)
                        {
                            var configJson = JsonConvert.SerializeObject(prompt.Config, Formatting.Indented);
                            Console.WriteLine($"\n  Config (JSON Schema):");
                            Console.WriteLine($"  {configJson.Substring(0, Math.Min(500, configJson.Length))}...");
                        }

                        if (prompt.Prompt != null)
                        {
                            Console.WriteLine($"\n  Prompt content:");
                            var promptJson = JsonConvert.SerializeObject(prompt.Prompt, Formatting.Indented);
                            Console.WriteLine($"  {promptJson.Substring(0, Math.Min(300, promptJson.Length))}...");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No prompts found. Create some in Langfuse UI first.");
                }

                Console.WriteLine("\n\n========================================");
                Console.WriteLine("Benefits of using TYPED client:");
                Console.WriteLine("✅ Full IntelliSense support");
                Console.WriteLine("✅ Compile-time type safety");
                Console.WriteLine("✅ Auto-completion for all methods");
                Console.WriteLine("✅ Strongly typed request/response objects");
                Console.WriteLine("✅ No string magic - everything is typed!");
                Console.WriteLine("========================================");
            }
            catch (ApiException apiEx)
            {
                Console.WriteLine($"\n❌ API Error {apiEx.StatusCode}: {apiEx.Message}");
                if (!string.IsNullOrEmpty(apiEx.Response))
                {
                    Console.WriteLine($"  Response: {apiEx.Response}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n❌ Error: {ex.Message}");
                Console.WriteLine($"  Stack: {ex.StackTrace}");
            }

            Console.WriteLine("\n\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
