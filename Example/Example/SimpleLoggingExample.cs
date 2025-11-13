using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Langfuse.Client.Api;
using Langfuse.Client.Client;
using Langfuse.Client.Model;
using Microsoft.Extensions.Configuration;

namespace Example;

/// <summary>
/// Simple logging example similar to BloodGPT's LoggingGptService
/// Demonstrates minimal trace logging without nested generations
/// </summary>
public class SimpleLoggingExample
{
    public static async Task Run()
    {
        Console.WriteLine("╔═══════════════════════════════════════════════╗");
        Console.WriteLine("║  Simple Logging Example                      ║");
        Console.WriteLine("║  (Pattern from BloodGPT backend)             ║");
        Console.WriteLine("╚═══════════════════════════════════════════════╝\n");

        // Load configuration
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

        var baseUrl = configuration["Langfuse:BaseUrl"];
        var publicKey = configuration["Langfuse:PublicKey"];
        var secretKey = configuration["Langfuse:SecretKey"];

        // Configure the API client
        var config = new Configuration
        {
            BasePath = baseUrl,
            Username = publicKey,
            Password = secretKey
        };

        var ingestionApi = new IngestionApi(config);

        try
        {
            // Simulate GPT request and response
            var userId = Guid.NewGuid();
            var traceName = "chat-completion";

            // Simulated GPT request (like from OpenAI)
            var gptRequest = new
            {
                model = "gpt-4",
                messages = new[]
                {
                    new { role = "system", content = "You are a helpful medical assistant for blood test analysis." },
                    new { role = "user", content = "What does high hemoglobin mean?" }
                },
                temperature = 0.7,
                max_tokens = 500
            };

            // Simulated GPT response
            var gptResponse = new
            {
                id = "chatcmpl-123",
                @object = "chat.completion",
                created = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
                model = "gpt-4",
                choices = new[]
                {
                    new
                    {
                        index = 0,
                        message = new
                        {
                            role = "assistant",
                            content = "High hemoglobin levels can indicate dehydration, lung disease, or living at high altitude. " +
                                     "It's important to consult with a healthcare provider for proper interpretation."
                        },
                        finish_reason = "stop"
                    }
                },
                usage = new
                {
                    prompt_tokens = 35,
                    completion_tokens = 42,
                    total_tokens = 77
                }
            };

            Console.WriteLine("📝 Logging GPT request/response to Langfuse...\n");

            // Create trace and generation (similar to BloodGPT pattern but with proper structure)
            var timestamp = DateTime.UtcNow;
            var traceId = Guid.NewGuid().ToString();

            // Create trace
            var traceBody = new LfTraceBody(
                id: traceId,
                name: traceName
            )
            {
                UserId = userId.ToString(),
                Metadata = new
                {
                    userId = userId,
                    source = "simple-logging-example"
                },
                Tags = new List<string> { "gpt", "medical-assistant", "blood-test" }
            };

            var traceEvent = new LfIngestionEventOneOf(
                body: traceBody,
                id: Guid.NewGuid().ToString(),
                timestamp: timestamp.ToString("yyyy-MM-dd'T'HH:mm:ss.fff'Z'"),
                metadata: null,
                type: LfIngestionEventOneOf.TypeEnum.TraceCreate
            );

            // Create generation with GPT request/response
            var generationBody = new LfCreateGenerationBody(
                id: Guid.NewGuid().ToString(),
                traceId: traceId,
                name: "gpt-completion"
            )
            {
                Model = gptRequest.model,
                Input = gptRequest.messages,
                Output = gptResponse.choices[0].message,
                Usage = new LfIngestionUsage(new LfUsage
                {
                    Input = gptResponse.usage.prompt_tokens,
                    Output = gptResponse.usage.completion_tokens,
                    Total = gptResponse.usage.total_tokens
                }),
                Metadata = new
                {
                    userId = userId.ToString(),
                    temperature = gptRequest.temperature,
                    max_tokens = gptRequest.max_tokens
                }
            };

            var generationEvent = new LfIngestionEventOneOf4(
                body: generationBody,
                id: Guid.NewGuid().ToString(),
                timestamp: timestamp.ToString("yyyy-MM-dd'T'HH:mm:ss.fff'Z'"),
                metadata: null,
                type: LfIngestionEventOneOf4.TypeEnum.GenerationCreate
            );

            // Send to Langfuse
            var batchRequest = new LfIngestionBatchRequest(
                batch: new List<LfIngestionEvent>
                {
                    new LfIngestionEvent(traceEvent),
                    new LfIngestionEvent(generationEvent)
                },
                metadata: null
            );

            var response = await ingestionApi.IngestionBatchAsync(batchRequest);

            Console.WriteLine("✅ Logged to Langfuse successfully!");
            Console.WriteLine($"   Trace ID: {traceId}");
            Console.WriteLine($"   User ID: {userId}");
            Console.WriteLine($"   Trace Name: {traceName}");
            Console.WriteLine($"   Successes: {response.Successes?.Count ?? 0}");
            Console.WriteLine($"   Errors: {response.Errors?.Count ?? 0}");

            if (response.Errors != null && response.Errors.Count > 0)
            {
                Console.WriteLine("\n⚠️  Errors:");
                foreach (var error in response.Errors)
                {
                    Console.WriteLine($"   • {error.Message}");
                }
            }

            Console.WriteLine("\n╔════════════════════════════════════════════════╗");
            Console.WriteLine("║           ✅ SUCCESS!                         ║");
            Console.WriteLine("╚════════════════════════════════════════════════╝");
            Console.WriteLine("\n📊 This pattern is similar to BloodGPT backend:");
            Console.WriteLine("  ✅ Trace with generation for GPT logging");
            Console.WriteLine("  ✅ GPT request/response logged as input/output");
            Console.WriteLine("  ✅ User ID tracking");
            Console.WriteLine("  ✅ Token usage tracking (prompt/completion/total)");
            Console.WriteLine("  ✅ Model and metadata logging");
            Console.WriteLine("  ✅ Tags for categorization");

            Console.WriteLine("\n🔗 Check your dashboard:");
            Console.WriteLine($"   https://hipaa.cloud.langfuse.com/traces");
            Console.WriteLine($"   Trace ID: {traceId}");
        }
        catch (ApiException e)
        {
            Console.WriteLine($"\n❌ API Error: {e.ErrorCode}");
            Console.WriteLine($"   Message: {e.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\n❌ Error: {ex.Message}");
        }
    }
}
