using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using zborek.Langfuse;  // Extensions class
using zborek.Langfuse.Services;  // LangfuseTrace
using zborek.Langfuse.Client;  // ILangfuseClient

namespace CommunityLibraryExample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("=== Langfuse Community Library Example ===\n");
            Console.WriteLine("Using zborek.LangfuseDotnet v0.4.0\n");

            // Build configuration
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            // Setup DI container
            var services = new ServiceCollection();

            // Add TimeProvider (required for Langfuse)
            services.AddSingleton(TimeProvider.System);

            // Add Langfuse from configuration (using Extensions class)
            services.AddLangfuse(configuration);

            // Build service provider
            var serviceProvider = services.BuildServiceProvider();

            // Get Langfuse service - using full namespace
            var langfuseTrace = serviceProvider.GetRequiredService<LangfuseTrace>();

            try
            {
                Console.WriteLine("Creating trace with generation...\n");

                // Set input for the trace
                langfuseTrace.Trace.Body.Input = new
                {
                    question = "What is the community .NET library for Langfuse?",
                    context = "testing zborek.LangfuseDotnet package"
                };

                langfuseTrace.Trace.Body.Name = "community-library-test";
                langfuseTrace.Trace.Body.UserId = "test-user";
                langfuseTrace.Trace.Body.Metadata = new { environment = "production", library = "zborek.LangfuseDotnet" };
                langfuseTrace.Trace.Body.Tags = new[] { "community", "dotnet", "test" };

                Console.WriteLine($"✓ Set trace properties");

                // Create a span for data retrieval
                using (var dataSpan = langfuseTrace.CreateSpanScoped("GetData"))
                {
                    Console.WriteLine($"✓ Created span: GetData");

                    // Simulate getting data
                    await Task.Delay(300);
                    var data = "Sample data from database";

                    dataSpan.SetOutput(new { data, recordsCount = 42 });
                    Console.WriteLine($"✓ Set span output");
                }

                // Create a generation for LLM processing
                using (var generationSpan = langfuseTrace.CreateGenerationScoped(
                    "LLMProcessing",
                    input: new
                    {
                        model = "gpt-4",
                        messages = new[]
                        {
                            new { role = "system", content = "You are a helpful assistant." },
                            new { role = "user", content = "What is the community .NET library for Langfuse?" }
                        }
                    },
                    output: null))
                {
                    Console.WriteLine($"✓ Created generation span: LLMProcessing");

                    // Simulate LLM call
                    await Task.Delay(500);
                    var llmResult = new
                    {
                        response = "zborek.LangfuseDotnet is a community .NET client for Langfuse, available on NuGet!",
                        model = "gpt-4",
                        usage = new
                        {
                            promptTokens = 25,
                            completionTokens = 18,
                            totalTokens = 43
                        }
                    };

                    generationSpan.SetOutput(llmResult);
                    Console.WriteLine($"✓ Set generation output");
                }

                // Create an event
                using (var eventSpan = langfuseTrace.CreateEventScoped(
                    "ProcessingComplete",
                    input: new { status = "success", timestamp = DateTime.UtcNow },
                    output: new { result = "completed", confidence = 0.98 }))
                {
                    Console.WriteLine($"✓ Created event: ProcessingComplete");
                }

                // Set final trace output
                langfuseTrace.Trace.Body.Output = new
                {
                    answer = "zborek.LangfuseDotnet is available on NuGet!",
                    confidence = 0.98,
                    processingTime = "1.2s"
                };

                Console.WriteLine($"✓ Set trace output");

                // Ingest (send) data to Langfuse
                Console.WriteLine("\n📤 Ingesting data to Langfuse...");
                await langfuseTrace.IngestAsync();
                Console.WriteLine("✅ Data sent successfully!");

                Console.WriteLine("\n========================================");
                Console.WriteLine("✅ SUCCESS! GENERATED SDK WORKS!");
                Console.WriteLine("========================================");
                Console.WriteLine("✅ Easy DI integration");
                Console.WriteLine("✅ Scoped operations with automatic relationships");
                Console.WriteLine("✅ Type-safe API");
                Console.WriteLine("✅ Works with your Langfuse credentials!");
                Console.WriteLine("========================================");

                Console.WriteLine("\n📊 Check your Langfuse dashboard:");
                Console.WriteLine("   https://hipaa.cloud.langfuse.com/traces");
                Console.WriteLine($"\n   Trace name: community-library-test");
                Console.WriteLine($"   User: test-user");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n❌ Error: {ex.Message}");
                Console.WriteLine($"   Type: {ex.GetType().Name}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"   Inner: {ex.InnerException.Message}");
                }
            }
        }
    }
}
