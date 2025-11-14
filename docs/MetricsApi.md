# Langfuse.Client.Api.MetricsApi

All URIs are relative to *http://localhost*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**MetricsMetrics**](MetricsApi.md#metricsmetrics) | **GET** /api/public/metrics |  |

<a id="metricsmetrics"></a>
# **MetricsMetrics**
> LfMetricsResponse MetricsMetrics (string query)



Get metrics from the Langfuse project using a query object

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using Langfuse.Client.Api;
using Langfuse.Client.Client;
using Langfuse.Client.Model;

namespace Example
{
    public class MetricsMetricsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            // Configure HTTP basic authorization: BasicAuth
            config.Username = "YOUR_USERNAME";
            config.Password = "YOUR_PASSWORD";

            // create instances of HttpClient, HttpClientHandler to be reused later with different Api classes
            HttpClient httpClient = new HttpClient();
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            var apiInstance = new MetricsApi(httpClient, config, httpClientHandler);
            var query = "query_example";  // string | JSON string containing the query parameters with the following structure: ```json {   \"view\": string,           // Required. One of \"traces\", \"observations\", \"scores-numeric\", \"scores-categorical\"   \"dimensions\": [           // Optional. Default: []     {       \"field\": string       // Field to group by, e.g. \"name\", \"userId\", \"sessionId\"     }   ],   \"metrics\": [              // Required. At least one metric must be provided     {       \"measure\": string,    // What to measure, e.g. \"count\", \"latency\", \"value\"       \"aggregation\": string // How to aggregate, e.g. \"count\", \"sum\", \"avg\", \"p95\", \"histogram\"     }   ],   \"filters\": [              // Optional. Default: []     {       \"column\": string,     // Column to filter on       \"operator\": string,   // Operator, e.g. \"=\", \">\", \"<\", \"contains\"       \"value\": any,         // Value to compare against       \"type\": string,       // Data type, e.g. \"string\", \"number\", \"stringObject\"       \"key\": string         // Required only when filtering on metadata     }   ],   \"timeDimension\": {        // Optional. Default: null. If provided, results will be grouped by time     \"granularity\": string   // One of \"minute\", \"hour\", \"day\", \"week\", \"month\", \"auto\"   },   \"fromTimestamp\": string,  // Required. ISO datetime string for start of time range   \"toTimestamp\": string,    // Required. ISO datetime string for end of time range   \"orderBy\": [              // Optional. Default: null     {       \"field\": string,      // Field to order by       \"direction\": string   // \"asc\" or \"desc\"     }   ],   \"config\": {               // Optional. Query-specific configuration     \"bins\": number,         // Optional. Number of bins for histogram (1-100), default: 10     \"row_limit\": number     // Optional. Row limit for results (1-1000)   } } ```

            try
            {
                LfMetricsResponse result = apiInstance.MetricsMetrics(query);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling MetricsApi.MetricsMetrics: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the MetricsMetricsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<LfMetricsResponse> response = apiInstance.MetricsMetricsWithHttpInfo(query);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling MetricsApi.MetricsMetricsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **query** | **string** | JSON string containing the query parameters with the following structure: &#x60;&#x60;&#x60;json {   \&quot;view\&quot;: string,           // Required. One of \&quot;traces\&quot;, \&quot;observations\&quot;, \&quot;scores-numeric\&quot;, \&quot;scores-categorical\&quot;   \&quot;dimensions\&quot;: [           // Optional. Default: []     {       \&quot;field\&quot;: string       // Field to group by, e.g. \&quot;name\&quot;, \&quot;userId\&quot;, \&quot;sessionId\&quot;     }   ],   \&quot;metrics\&quot;: [              // Required. At least one metric must be provided     {       \&quot;measure\&quot;: string,    // What to measure, e.g. \&quot;count\&quot;, \&quot;latency\&quot;, \&quot;value\&quot;       \&quot;aggregation\&quot;: string // How to aggregate, e.g. \&quot;count\&quot;, \&quot;sum\&quot;, \&quot;avg\&quot;, \&quot;p95\&quot;, \&quot;histogram\&quot;     }   ],   \&quot;filters\&quot;: [              // Optional. Default: []     {       \&quot;column\&quot;: string,     // Column to filter on       \&quot;operator\&quot;: string,   // Operator, e.g. \&quot;&#x3D;\&quot;, \&quot;&gt;\&quot;, \&quot;&lt;\&quot;, \&quot;contains\&quot;       \&quot;value\&quot;: any,         // Value to compare against       \&quot;type\&quot;: string,       // Data type, e.g. \&quot;string\&quot;, \&quot;number\&quot;, \&quot;stringObject\&quot;       \&quot;key\&quot;: string         // Required only when filtering on metadata     }   ],   \&quot;timeDimension\&quot;: {        // Optional. Default: null. If provided, results will be grouped by time     \&quot;granularity\&quot;: string   // One of \&quot;minute\&quot;, \&quot;hour\&quot;, \&quot;day\&quot;, \&quot;week\&quot;, \&quot;month\&quot;, \&quot;auto\&quot;   },   \&quot;fromTimestamp\&quot;: string,  // Required. ISO datetime string for start of time range   \&quot;toTimestamp\&quot;: string,    // Required. ISO datetime string for end of time range   \&quot;orderBy\&quot;: [              // Optional. Default: null     {       \&quot;field\&quot;: string,      // Field to order by       \&quot;direction\&quot;: string   // \&quot;asc\&quot; or \&quot;desc\&quot;     }   ],   \&quot;config\&quot;: {               // Optional. Query-specific configuration     \&quot;bins\&quot;: number,         // Optional. Number of bins for histogram (1-100), default: 10     \&quot;row_limit\&quot;: number     // Optional. Row limit for results (1-1000)   } } &#x60;&#x60;&#x60; |  |

### Return type

[**LfMetricsResponse**](LfMetricsResponse.md)

### Authorization

[BasicAuth](../README.md#BasicAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** |  |  -  |
| **400** |  |  -  |
| **401** |  |  -  |
| **403** |  |  -  |
| **404** |  |  -  |
| **405** |  |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

