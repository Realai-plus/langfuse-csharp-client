using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Langfuse.Client;
using Microsoft.Extensions.DependencyInjection;

namespace LangfuseExample
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            // Настройка DI контейнера
            var services = new ServiceCollection();
            
            // Регистрация HttpClient с базовой аутентификацией
            services.AddHttpClient<LangfuseClient>(client =>
            {
                client.BaseAddress = new Uri("https://cloud.langfuse.com");
                
                // Basic Auth
                var publicKey = "your-public-key";
                var secretKey = "your-secret-key";
                var authValue = Convert.ToBase64String(
                    Encoding.UTF8.GetBytes($"{publicKey}:{secretKey}")
                );
                client.DefaultRequestHeaders.Authorization = 
                    new AuthenticationHeaderValue("Basic", authValue);
            });

            var serviceProvider = services.BuildServiceProvider();
            var langfuseClient = serviceProvider.GetRequiredService<LangfuseClient>();

            try
            {
                // Пример: Проверка здоровья API
                var healthResponse = await langfuseClient.Health_healthAsync();
                Console.WriteLine($"API Health: {healthResponse.Status}");

                // Пример: Получение списка датасетов
                var datasetsResponse = await langfuseClient.Datasets_listAsync(
                    page: 1, 
                    limit: 10
                );
                
                foreach (var dataset in datasetsResponse.Result.Data)
                {
                    Console.WriteLine($"Dataset: {dataset.Name}, ID: {dataset.Id}");
                }

                // Пример: Создание трейса
                var ingestionRequest = new IngestionRequest
                {
                    Batch = new List<IngestionEvent>
                    {
                        new IngestionEvent
                        {
                            Id = Guid.NewGuid().ToString(),
                            Type = "trace-create",
                            Timestamp = DateTime.UtcNow,
                            Body = new TraceBody
                            {
                                Id = Guid.NewGuid().ToString(),
                                Name = "Test Trace",
                                Input = new { query = "test" },
                                Output = new { response = "test response" },
                                Metadata = new Dictionary<string, object>
                                {
                                    ["environment"] = "production",
                                    ["version"] = "1.0.0"
                                }
                            }
                        }
                    }
                };

                var ingestionResponse = await langfuseClient.Ingestion_batchAsync(ingestionRequest);
                Console.WriteLine($"Ingestion successful: {ingestionResponse.Result.Successes.Count} items");
            }
            catch (ApiException ex)
            {
                Console.WriteLine($"API Error: {ex.StatusCode} - {ex.Response}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    // Пример кастомного HttpMessageHandler для логирования
    public class LoggingHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, 
            System.Threading.CancellationToken cancellationToken)
        {
            Console.WriteLine($"Request: {request.Method} {request.RequestUri}");
            
            var response = await base.SendAsync(request, cancellationToken);
            
            Console.WriteLine($"Response: {response.StatusCode}");
            
            return response;
        }
    }
}