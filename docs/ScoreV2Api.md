# Langfuse.Client.Api.ScoreV2Api

All URIs are relative to *http://localhost*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**ScoreV2Get**](ScoreV2Api.md#scorev2get) | **GET** /api/public/v2/scores |  |
| [**ScoreV2GetById**](ScoreV2Api.md#scorev2getbyid) | **GET** /api/public/v2/scores/{scoreId} |  |

<a id="scorev2get"></a>
# **ScoreV2Get**
> LfGetScoresResponse ScoreV2Get (int? page = null, int? limit = null, string? userId = null, string? name = null, DateTime? fromTimestamp = null, DateTime? toTimestamp = null, List<string>? environment = null, LfScoreSource? source = null, string? varOperator = null, double? value = null, string? scoreIds = null, string? configId = null, string? queueId = null, LfScoreDataType? dataType = null, List<string>? traceTags = null)



Get a list of scores (supports both trace and session scores)

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
    public class ScoreV2GetExample
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
            var apiInstance = new ScoreV2Api(httpClient, config, httpClientHandler);
            var page = 56;  // int? | Page number, starts at 1. (optional) 
            var limit = 56;  // int? | Limit of items per page. If you encounter api issues due to too large page sizes, try to reduce the limit. (optional) 
            var userId = "userId_example";  // string? | Retrieve only scores with this userId associated to the trace. (optional) 
            var name = "name_example";  // string? | Retrieve only scores with this name. (optional) 
            var fromTimestamp = DateTime.Parse("2013-10-20T19:20:30+01:00");  // DateTime? | Optional filter to only include scores created on or after a certain datetime (ISO 8601) (optional) 
            var toTimestamp = DateTime.Parse("2013-10-20T19:20:30+01:00");  // DateTime? | Optional filter to only include scores created before a certain datetime (ISO 8601) (optional) 
            var environment = new List<string>?(); // List<string>? | Optional filter for scores where the environment is one of the provided values. (optional) 
            var source = new LfScoreSource?(); // LfScoreSource? | Retrieve only scores from a specific source. (optional) 
            var varOperator = "varOperator_example";  // string? | Retrieve only scores with <operator> value. (optional) 
            var value = 1.2D;  // double? | Retrieve only scores with <operator> value. (optional) 
            var scoreIds = "scoreIds_example";  // string? | Comma-separated list of score IDs to limit the results to. (optional) 
            var configId = "configId_example";  // string? | Retrieve only scores with a specific configId. (optional) 
            var queueId = "queueId_example";  // string? | Retrieve only scores with a specific annotation queueId. (optional) 
            var dataType = new LfScoreDataType?(); // LfScoreDataType? | Retrieve only scores with a specific dataType. (optional) 
            var traceTags = new List<string>?(); // List<string>? | Only scores linked to traces that include all of these tags will be returned. (optional) 

            try
            {
                LfGetScoresResponse result = apiInstance.ScoreV2Get(page, limit, userId, name, fromTimestamp, toTimestamp, environment, source, varOperator, value, scoreIds, configId, queueId, dataType, traceTags);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ScoreV2Api.ScoreV2Get: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ScoreV2GetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<LfGetScoresResponse> response = apiInstance.ScoreV2GetWithHttpInfo(page, limit, userId, name, fromTimestamp, toTimestamp, environment, source, varOperator, value, scoreIds, configId, queueId, dataType, traceTags);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ScoreV2Api.ScoreV2GetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **page** | **int?** | Page number, starts at 1. | [optional]  |
| **limit** | **int?** | Limit of items per page. If you encounter api issues due to too large page sizes, try to reduce the limit. | [optional]  |
| **userId** | **string?** | Retrieve only scores with this userId associated to the trace. | [optional]  |
| **name** | **string?** | Retrieve only scores with this name. | [optional]  |
| **fromTimestamp** | **DateTime?** | Optional filter to only include scores created on or after a certain datetime (ISO 8601) | [optional]  |
| **toTimestamp** | **DateTime?** | Optional filter to only include scores created before a certain datetime (ISO 8601) | [optional]  |
| **environment** | [**List&lt;string&gt;?**](string.md) | Optional filter for scores where the environment is one of the provided values. | [optional]  |
| **source** | [**LfScoreSource?**](LfScoreSource?.md) | Retrieve only scores from a specific source. | [optional]  |
| **varOperator** | **string?** | Retrieve only scores with &lt;operator&gt; value. | [optional]  |
| **value** | **double?** | Retrieve only scores with &lt;operator&gt; value. | [optional]  |
| **scoreIds** | **string?** | Comma-separated list of score IDs to limit the results to. | [optional]  |
| **configId** | **string?** | Retrieve only scores with a specific configId. | [optional]  |
| **queueId** | **string?** | Retrieve only scores with a specific annotation queueId. | [optional]  |
| **dataType** | [**LfScoreDataType?**](LfScoreDataType?.md) | Retrieve only scores with a specific dataType. | [optional]  |
| **traceTags** | [**List&lt;string&gt;?**](string.md) | Only scores linked to traces that include all of these tags will be returned. | [optional]  |

### Return type

[**LfGetScoresResponse**](LfGetScoresResponse.md)

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

<a id="scorev2getbyid"></a>
# **ScoreV2GetById**
> LfScore ScoreV2GetById (string scoreId)



Get a score (supports both trace and session scores)

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
    public class ScoreV2GetByIdExample
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
            var apiInstance = new ScoreV2Api(httpClient, config, httpClientHandler);
            var scoreId = "scoreId_example";  // string | The unique langfuse identifier of a score

            try
            {
                LfScore result = apiInstance.ScoreV2GetById(scoreId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ScoreV2Api.ScoreV2GetById: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ScoreV2GetByIdWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<LfScore> response = apiInstance.ScoreV2GetByIdWithHttpInfo(scoreId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ScoreV2Api.ScoreV2GetByIdWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **scoreId** | **string** | The unique langfuse identifier of a score |  |

### Return type

[**LfScore**](LfScore.md)

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

