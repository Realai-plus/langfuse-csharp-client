using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using zborek.Langfuse;
using zborek.Langfuse.Services;

namespace EnhancedSdkExample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("╔══════════════════════════════════════════════╗");
            Console.WriteLine("║  Langfuse SDK Enhanced Example              ║");
            Console.WriteLine("║  Using zborek.LangfuseDotnet v0.4.0         ║");
            Console.WriteLine("╚══════════════════════════════════════════════╝\n");

            // Build configuration
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            // Setup DI container
            var services = new ServiceCollection();
            services.AddSingleton(TimeProvider.System);
            services.AddLangfuse(configuration);

            // Build service provider
            var serviceProvider = services.BuildServiceProvider();

            // Get Langfuse service
            var langfuseTrace = serviceProvider.GetRequiredService<LangfuseTrace>();

            try
            {
                // ============================================
                // СОЗДАНИЕ TRACE С GENERATION (как в SimpleExample)
                // ============================================
                Console.WriteLine("📤 Creating Trace with Generation & Score using SDK\n");

                var traceId = Guid.NewGuid().ToString();
                var timestamp = DateTime.UtcNow;

                // Настройка trace
                langfuseTrace.Trace.Body.Id = traceId;
                langfuseTrace.Trace.Body.Name = "sdk-enhanced-example-trace";
                langfuseTrace.Trace.Body.UserId = "test-user-sdk";
                langfuseTrace.Trace.Body.SessionId = $"session-{Guid.NewGuid().ToString().Substring(0, 8)}";
                langfuseTrace.Trace.Body.Metadata = new
                {
                    environment = "production",
                    client = "zborek.LangfuseDotnet",
                    version = "0.4.0",
                    example = "enhanced-sdk"
                };
                langfuseTrace.Trace.Body.Tags = new[] { "sdk", "enhanced", "example", "production" };
                langfuseTrace.Trace.Body.Input = new
                {
                    question = "How does the typed SDK client work?",
                    context = "Testing enhanced SDK example"
                };

                Console.WriteLine($"✓ Configured trace: {traceId}");

                // Создаем Generation для LLM вызова
                using (var generation = langfuseTrace.CreateGenerationScoped(
                    "llm-completion",
                    input: new
                    {
                        model = "gpt-4",
                        temperature = 0.7,
                        maxTokens = 150,
                        messages = new[]
                        {
                            new { role = "system", content = "You are a helpful assistant." },
                            new { role = "user", content = "How does the typed SDK client work?" }
                        }
                    },
                    output: null))
                {
                    Console.WriteLine($"✓ Created generation span");

                    // Симулируем LLM вызов
                    await Task.Delay(800);

                    var llmOutput = new
                    {
                        role = "assistant",
                        content = "The zborek.LangfuseDotnet SDK provides type-safe API with DI integration and automatic trace management!",
                        model = "gpt-4",
                        usage = new
                        {
                            promptTokens = 30,
                            completionTokens = 20,
                            totalTokens = 50
                        }
                    };

                    generation.SetOutput(llmOutput);
                    Console.WriteLine($"✓ Set generation output (50 tokens)");
                }

                // Добавляем Score
                using (var scoreEvent = langfuseTrace.CreateEventScoped(
                    "quality-score",
                    input: new { metric = "accuracy", evaluator = "automated" },
                    output: new { score = 0.95, comment = "High quality response" }))
                {
                    Console.WriteLine($"✓ Added quality score: 0.95");
                }

                // Финальный output трейса
                langfuseTrace.Trace.Body.Output = new
                {
                    answer = "The SDK provides full type safety and easy integration!",
                    confidence = 0.95,
                    processingTimeMs = 800
                };

                Console.WriteLine($"✓ Set trace output");

                // Отправляем в Langfuse
                Console.WriteLine("\n📨 Sending trace to Langfuse...");
                await langfuseTrace.IngestAsync();
                Console.WriteLine("✅ Trace sent successfully!");

                // ============================================
                // ИТОГИ
                // ============================================
                Console.WriteLine("\n╔══════════════════════════════════════════════╗");
                Console.WriteLine("║           ✅ SUCCESS!                        ║");
                Console.WriteLine("╚══════════════════════════════════════════════╝");
                Console.WriteLine("\n📊 What we did (same as SimpleExample but with SDK):");
                Console.WriteLine("  ✓ Created trace using LangfuseTrace");
                Console.WriteLine("  ✓ Added generation with LLM simulation");
                Console.WriteLine("  ✓ Added quality score event");
                Console.WriteLine("  ✓ Sent everything to Langfuse");

                Console.WriteLine("\n📈 Advantages of SDK:");
                Console.WriteLine("  ✅ Type-safe API (no string magic!)");
                Console.WriteLine("  ✅ IntelliSense support");
                Console.WriteLine("  ✅ Automatic parent-child relationships");
                Console.WriteLine("  ✅ DI integration");
                Console.WriteLine("  ✅ Scoped operations");

                Console.WriteLine("\n🔗 Check your dashboard:");
                Console.WriteLine($"   https://hipaa.cloud.langfuse.com/traces");
                Console.WriteLine($"   Trace ID: {traceId}");
                Console.WriteLine($"   Trace Name: sdk-enhanced-example-trace");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n❌ Error: {ex.Message}");
                Console.WriteLine($"   Type: {ex.GetType().Name}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"   Inner: {ex.InnerException.Message}");
                }
                Console.WriteLine($"\n   Stack: {ex.StackTrace}");
            }
        }
    }
}
