using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Langfuse.Client.Api;
using Langfuse.Client.Client;
using Langfuse.Client.Model;
using Microsoft.Extensions.Configuration;

namespace Example
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("╔═══════════════════════════════════════════════╗");
            Console.WriteLine("║  Langfuse GENERATED Client Example           ║");
            Console.WriteLine("║  Using OpenAPI Generator csharp               ║");
            Console.WriteLine("╚═══════════════════════════════════════════════╝\n");

            // Load configuration
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            var baseUrl = configuration["Langfuse:BaseUrl"];
            var publicKey = configuration["Langfuse:PublicKey"];
            var secretKey = configuration["Langfuse:SecretKey"];

            // Configure the generated API client
            var config = new Configuration
            {
                BasePath = baseUrl,
                Username = publicKey,
                Password = secretKey
            };

            // Create API instances
            var promptsApi = new PromptsApi(config);
            var ingestionApi = new IngestionApi(config);
            var mediaApi = new MediaApi(config);

            try
            {
                // ============================================
                // FETCH PROMPTS using Generated Client
                // ============================================
                Console.WriteLine("📋 Fetching Prompts with Generated Client\n");

                var promptsResponse = await promptsApi.PromptsListAsync(
                    name: null,
                    label: null,
                    tag: null,
                    page: 1,
                    limit: 10,
                    fromUpdatedAt: null,
                    toUpdatedAt: null
                );

                string promptName = null;
                int? promptVersion = null;

                if (promptsResponse.Data != null && promptsResponse.Data.Count > 0)
                {
                    Console.WriteLine($"✅ Found {promptsResponse.Data.Count} prompts:\n");

                    foreach (var prompt in promptsResponse.Data)
                    {
                        Console.WriteLine($"  • Prompt: {prompt.Name}");
                        Console.WriteLine($"    Versions: {string.Join(", ", prompt.Versions)}");
                        if (prompt.Labels != null && prompt.Labels.Count > 0)
                        {
                            Console.WriteLine($"    Labels: {string.Join(", ", prompt.Labels)}");
                        }
                        Console.WriteLine();

                        // Save first prompt info for linking to generation
                        if (promptName == null)
                        {
                            promptName = prompt.Name;
                            promptVersion = prompt.Versions.FirstOrDefault();
                        }
                    }
                }
                else
                {
                    Console.WriteLine("⚠️  No prompts found");
                }

                // ============================================
                // UPLOAD IMAGE using Generated Client
                // ============================================
                Console.WriteLine("\n📤 Uploading BloodGPT Logo using Generated Client\n");

                // Load BloodGPT logo from file
                var logoPath = Path.Combine(AppContext.BaseDirectory, "bloodgpt-logo.png");
                byte[] logoBytes = await File.ReadAllBytesAsync(logoPath);

                var traceId = Guid.NewGuid().ToString();

                // Calculate SHA256 hash
                string sha256Hash;
                using (var sha256 = SHA256.Create())
                {
                    byte[] hashBytes = sha256.ComputeHash(logoBytes);
                    sha256Hash = Convert.ToBase64String(hashBytes);
                }

                Console.WriteLine($"✓ Loaded BloodGPT logo ({logoBytes.Length} bytes)");
                Console.WriteLine($"✓ SHA256: {sha256Hash}");

                // Request upload URL
                var uploadRequest = new LfGetMediaUploadUrlRequest(
                    traceId: traceId,
                    observationId: null,
                    contentType: LfMediaContentType.ImagePng,
                    contentLength: logoBytes.Length,
                    sha256Hash: sha256Hash,
                    field: "input"
                );

                var uploadResponse = await mediaApi.MediaGetUploadUrlAsync(uploadRequest);
                var mediaId = uploadResponse.MediaId;
                var uploadUrl = uploadResponse.UploadUrl;

                Console.WriteLine($"✓ Got upload URL for media: {mediaId}");

                // Upload file to the URL (if uploadUrl is provided)
                if (!string.IsNullOrEmpty(uploadUrl))
                {
                    using (var httpClient = new HttpClient())
                    {
                        var uploadStart = DateTime.UtcNow;
                        var content = new ByteArrayContent(logoBytes);
                        content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/png");
                        content.Headers.Add("x-amz-checksum-sha256", sha256Hash);

                        var uploadHttpResponse = await httpClient.PutAsync(uploadUrl, content);
                        var uploadDuration = (DateTime.UtcNow - uploadStart).TotalMilliseconds;

                        if (uploadHttpResponse.IsSuccessStatusCode)
                        {
                            Console.WriteLine($"✓ Uploaded BloodGPT logo ({uploadDuration:F0}ms)");

                            // Update media status
                            var patchBody = new LfPatchMediaBody(
                                uploadedAt: DateTime.UtcNow,
                                uploadHttpStatus: (int)uploadHttpResponse.StatusCode
                            )
                            {
                                UploadTimeMs = (int)uploadDuration
                            };

                            await mediaApi.MediaPatchAsync(mediaId, patchBody);
                            Console.WriteLine($"✓ Media status updated");
                        }
                        else
                        {
                            Console.WriteLine($"❌ Upload failed: {uploadHttpResponse.StatusCode}");
                            var errorContent = await uploadHttpResponse.Content.ReadAsStringAsync();
                            Console.WriteLine($"   Error: {errorContent}");
                            mediaId = null; // Don't use failed media
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"ℹ️  Already in storage (deduplication by SHA256)");
                }

                // ============================================
                // SEND TRACE WITH GENERATION using Generated Client
                // ============================================
                Console.WriteLine("\n📤 Sending Trace with Generation using Generated Client\n");

                var timestamp = DateTime.UtcNow;

                // Prepare input with media reference if upload succeeded
                object traceInput;
                if (!string.IsNullOrEmpty(mediaId))
                {
                    var mediaRef = $"@@@langfuseMedia:image/png|||{mediaId}@@@";
                    traceInput = new
                    {
                        question = "What is Langfuse?",
                        logo = mediaRef,
                        note = "BloodGPT logo attached"
                    };
                    Console.WriteLine($"✓ Attaching BloodGPT logo to trace: {mediaRef}");
                }
                else
                {
                    traceInput = new { question = "What is Langfuse?" };
                }

                // Create trace-create event
                var traceBody = new LfTraceBody(
                    id: traceId,
                    name: "generated-client-test-trace-with-image"
                )
                {
                    UserId = "test-user-generated",
                    SessionId = $"session-{Guid.NewGuid().ToString().Substring(0, 8)}",
                    Input = traceInput,
                    Output = new { answer = "Langfuse is an LLM observability platform!" },
                    VarEnvironment = "production",
                    Metadata = new
                    {
                        client = "generated-csharp-client",
                        version = "1.0.0",
                        hasLogo = !string.IsNullOrEmpty(mediaId),
                        mediaId = mediaId ?? "none",
                        logoSize = logoBytes.Length
                    },
                    Tags = new List<string> { "generated", "test", "csharp", "with-logo" }
                };

                var traceEvent = new LfIngestionEventOneOf(
                    body: traceBody,
                    id: Guid.NewGuid().ToString(),
                    timestamp: timestamp.ToString("yyyy-MM-dd'T'HH:mm:ss.fff'Z'"),
                    metadata: null,
                    type: LfIngestionEventOneOf.TypeEnum.TraceCreate
                );

                Console.WriteLine($"✓ Created trace event: {traceId}");

                // Create generation-create event
                var generationBody = new LfCreateGenerationBody(
                    id: Guid.NewGuid().ToString(),
                    traceId: traceId,
                    name: "llm-call-with-prompt"
                )
                {
                    StartTime = timestamp.AddMilliseconds(100),
                    EndTime = timestamp.AddMilliseconds(1500),
                    Model = "gpt-3.5-turbo",
                    VarEnvironment = "production",
                    Input = new object[]
                    {
                        new { role = "system", content = "You are a helpful assistant." },
                        new { role = "user", content = "What is Langfuse?" }
                    },
                    Output = new { role = "assistant", content = "Langfuse is an LLM observability platform." },
                    Usage = new LfIngestionUsage(new LfUsage
                    {
                        Input = 20,
                        Output = 10,
                        Total = 30
                    }),
                    PromptName = promptName,
                    PromptVersion = promptVersion
                };

                var generationEvent = new LfIngestionEventOneOf4(
                    body: generationBody,
                    id: Guid.NewGuid().ToString(),
                    timestamp: timestamp.AddMilliseconds(100).ToString("yyyy-MM-dd'T'HH:mm:ss.fff'Z'"),
                    metadata: null,
                    type: LfIngestionEventOneOf4.TypeEnum.GenerationCreate
                );

                if (!string.IsNullOrEmpty(promptName))
                {
                    Console.WriteLine($"✓ Created generation linked to prompt: {promptName} (v{promptVersion})");
                }
                else
                {
                    Console.WriteLine($"✓ Created generation (no prompt link)");
                }

                // Create score-create event
                var scoreBody = new LfScoreBody(
                    id: Guid.NewGuid().ToString(),
                    traceId: traceId,
                    name: "quality",
                    value: new LfCreateScoreValue(0.95)
                )
                {
                    VarEnvironment = "production",
                    Comment = "Excellent response quality"
                };

                var scoreEvent = new LfIngestionEventOneOf1(
                    body: scoreBody,
                    id: Guid.NewGuid().ToString(),
                    timestamp: timestamp.AddMilliseconds(2000).ToString("yyyy-MM-dd'T'HH:mm:ss.fff'Z'"),
                    metadata: null,
                    type: LfIngestionEventOneOf1.TypeEnum.ScoreCreate
                );

                Console.WriteLine($"✓ Created score event");

                // ============================================
                // CREATE NESTED GENERATIONS (Parent-Child)
                // ============================================
                Console.WriteLine("\n🔗 Creating nested generations (parent-child relationship)...");

                // Parent generation - main orchestrator
                var parentGenerationId = Guid.NewGuid().ToString();
                var parentGenerationBody = new LfCreateGenerationBody(
                    id: parentGenerationId,
                    traceId: traceId,
                    name: "orchestrator-llm"
                )
                {
                    StartTime = timestamp.AddMilliseconds(2100),
                    EndTime = timestamp.AddMilliseconds(5000),
                    Model = "gpt-4",
                    VarEnvironment = "production",
                    Input = new object[]
                    {
                        new { role = "user", content = "Analyze blood test results and provide recommendations" }
                    },
                    Output = new {
                        role = "assistant",
                        content = "I need to check parameters and generate recommendations",
                        tool_calls = new[] { "check_parameters", "generate_recommendations" }
                    },
                    Usage = new LfIngestionUsage(new LfUsage
                    {
                        Input = 50,
                        Output = 30,
                        Total = 80
                    }),
                    Metadata = new { type = "orchestrator", has_children = true }
                };

                var parentGenerationEvent = new LfIngestionEventOneOf4(
                    body: parentGenerationBody,
                    id: Guid.NewGuid().ToString(),
                    timestamp: timestamp.AddMilliseconds(2100).ToString("yyyy-MM-dd'T'HH:mm:ss.fff'Z'"),
                    metadata: null,
                    type: LfIngestionEventOneOf4.TypeEnum.GenerationCreate
                );

                Console.WriteLine($"✓ Created parent generation: orchestrator-llm (id: {parentGenerationId})");

                // Child generation 1 - parameter checker
                var child1GenerationId = Guid.NewGuid().ToString();
                var child1GenerationBody = new LfCreateGenerationBody(
                    id: child1GenerationId,
                    traceId: traceId,
                    name: "check-parameters-llm"
                )
                {
                    ParentObservationId = parentGenerationId,
                    StartTime = timestamp.AddMilliseconds(2200),
                    EndTime = timestamp.AddMilliseconds(3500),
                    Model = "gpt-3.5-turbo",
                    VarEnvironment = "production",
                    Input = new object[]
                    {
                        new { role = "system", content = "Check blood parameters against normal ranges" },
                        new { role = "user", content = "Hemoglobin: 140 g/L, Glucose: 5.2 mmol/L" }
                    },
                    Output = new {
                        role = "assistant",
                        content = "Parameters are within normal range",
                        parameters_checked = 2,
                        status = "normal"
                    },
                    Usage = new LfIngestionUsage(new LfUsage
                    {
                        Input = 35,
                        Output = 15,
                        Total = 50
                    }),
                    Metadata = new { type = "tool_call", parent_id = parentGenerationId }
                };

                var child1GenerationEvent = new LfIngestionEventOneOf4(
                    body: child1GenerationBody,
                    id: Guid.NewGuid().ToString(),
                    timestamp: timestamp.AddMilliseconds(2200).ToString("yyyy-MM-dd'T'HH:mm:ss.fff'Z'"),
                    metadata: null,
                    type: LfIngestionEventOneOf4.TypeEnum.GenerationCreate
                );

                Console.WriteLine($"✓ Created child generation 1: check-parameters-llm (parent: {parentGenerationId})");

                // Child generation 2 - recommendation generator
                var child2GenerationId = Guid.NewGuid().ToString();
                var child2GenerationBody = new LfCreateGenerationBody(
                    id: child2GenerationId,
                    traceId: traceId,
                    name: "generate-recommendations-llm"
                )
                {
                    ParentObservationId = parentGenerationId,
                    StartTime = timestamp.AddMilliseconds(3600),
                    EndTime = timestamp.AddMilliseconds(4900),
                    Model = "gpt-4",
                    VarEnvironment = "production",
                    Input = new object[]
                    {
                        new { role = "system", content = "Generate health recommendations based on blood test results" },
                        new { role = "user", content = "Status: normal, Parameters: Hemoglobin, Glucose" }
                    },
                    Output = new {
                        role = "assistant",
                        content = "Maintain current lifestyle. Consider regular exercise and balanced diet.",
                        recommendations = new[] { "Regular exercise", "Balanced diet", "Annual checkup" }
                    },
                    Usage = new LfIngestionUsage(new LfUsage
                    {
                        Input = 40,
                        Output = 25,
                        Total = 65
                    }),
                    Metadata = new { type = "tool_call", parent_id = parentGenerationId }
                };

                var child2GenerationEvent = new LfIngestionEventOneOf4(
                    body: child2GenerationBody,
                    id: Guid.NewGuid().ToString(),
                    timestamp: timestamp.AddMilliseconds(3600).ToString("yyyy-MM-dd'T'HH:mm:ss.fff'Z'"),
                    metadata: null,
                    type: LfIngestionEventOneOf4.TypeEnum.GenerationCreate
                );

                Console.WriteLine($"✓ Created child generation 2: generate-recommendations-llm (parent: {parentGenerationId})");

                // Create batch request with all events
                var batchRequest = new LfIngestionBatchRequest(
                    batch: new List<LfIngestionEvent>
                    {
                        new LfIngestionEvent(traceEvent),
                        new LfIngestionEvent(generationEvent),
                        new LfIngestionEvent(scoreEvent),
                        new LfIngestionEvent(parentGenerationEvent),
                        new LfIngestionEvent(child1GenerationEvent),
                        new LfIngestionEvent(child2GenerationEvent)
                    },
                    metadata: null
                );

                Console.WriteLine("\n📨 Sending batch to Langfuse...");

                var ingestionResponse = await ingestionApi.IngestionBatchAsync(batchRequest);

                Console.WriteLine($"✅ Batch sent successfully!");
                Console.WriteLine($"   Successes: {ingestionResponse.Successes?.Count ?? 0}");
                Console.WriteLine($"   Errors: {ingestionResponse.Errors?.Count ?? 0}");

                if (ingestionResponse.Errors != null && ingestionResponse.Errors.Count > 0)
                {
                    Console.WriteLine("\n⚠️  Errors details:");
                    foreach (var error in ingestionResponse.Errors)
                    {
                        Console.WriteLine($"   • {error.Message}");
                        if (error.Error != null)
                        {
                            Console.WriteLine($"     Details: {error.Error}");
                        }
                    }
                }

                Console.WriteLine("\n╔════════════════════════════════════════════════╗");
                Console.WriteLine("║           ✅ COMPLETE SUCCESS!                ║");
                Console.WriteLine("╚════════════════════════════════════════════════╝");
                Console.WriteLine("\n📊 What we did:");
                Console.WriteLine("  ✅ Fetched prompts using PromptsApi");
                Console.WriteLine("  ✅ Uploaded BloodGPT logo using MediaApi (with deduplication)");
                Console.WriteLine("  ✅ Created trace event (with image attached)");
                Console.WriteLine("  ✅ Created generation event (linked to prompt)");
                Console.WriteLine("  ✅ Created score event");
                Console.WriteLine("  ✅ Created nested generations (parent-child hierarchy):");
                Console.WriteLine("      • Parent: orchestrator-llm (gpt-4)");
                Console.WriteLine("      • Child 1: check-parameters-llm (gpt-3.5-turbo)");
                Console.WriteLine("      • Child 2: generate-recommendations-llm (gpt-4)");
                Console.WriteLine("  ✅ Sent batch with 6 events using IngestionApi");

                Console.WriteLine("\n🔗 Check your dashboard:");
                Console.WriteLine($"   https://hipaa.cloud.langfuse.com/traces");
                Console.WriteLine($"   Trace ID: {traceId}");
                Console.WriteLine($"   Trace Name: generated-client-test-trace-with-image");
                if (!string.IsNullOrEmpty(mediaId))
                {
                    Console.WriteLine($"   Media ID: {mediaId}");
                }

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
}
