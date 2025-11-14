# Langfuse.Client.Api.ObservationsApi

All URIs are relative to *http://localhost*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**ObservationsGet**](ObservationsApi.md#observationsget) | **GET** /api/public/observations/{observationId} |  |
| [**ObservationsGetMany**](ObservationsApi.md#observationsgetmany) | **GET** /api/public/observations |  |

<a id="observationsget"></a>
# **ObservationsGet**
> LfObservationsView ObservationsGet (string observationId)



Get a observation

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
    public class ObservationsGetExample
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
            var apiInstance = new ObservationsApi(httpClient, config, httpClientHandler);
            var observationId = "observationId_example";  // string | The unique langfuse identifier of an observation, can be an event, span or generation

            try
            {
                LfObservationsView result = apiInstance.ObservationsGet(observationId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ObservationsApi.ObservationsGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ObservationsGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<LfObservationsView> response = apiInstance.ObservationsGetWithHttpInfo(observationId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ObservationsApi.ObservationsGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **observationId** | **string** | The unique langfuse identifier of an observation, can be an event, span or generation |  |

### Return type

[**LfObservationsView**](LfObservationsView.md)

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

<a id="observationsgetmany"></a>
# **ObservationsGetMany**
> LfObservationsViews ObservationsGetMany (int? page = null, int? limit = null, string? name = null, string? userId = null, string? type = null, string? traceId = null, LfObservationLevel? level = null, string? parentObservationId = null, List<string>? environment = null, DateTime? fromStartTime = null, DateTime? toStartTime = null, string? version = null)



Get a list of observations

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
    public class ObservationsGetManyExample
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
            var apiInstance = new ObservationsApi(httpClient, config, httpClientHandler);
            var page = 56;  // int? | Page number, starts at 1. (optional) 
            var limit = 56;  // int? | Limit of items per page. If you encounter api issues due to too large page sizes, try to reduce the limit. (optional) 
            var name = "name_example";  // string? |  (optional) 
            var userId = "userId_example";  // string? |  (optional) 
            var type = "type_example";  // string? |  (optional) 
            var traceId = "traceId_example";  // string? |  (optional) 
            var level = new LfObservationLevel?(); // LfObservationLevel? | Optional filter for observations with a specific level (e.g. \"DEBUG\", \"DEFAULT\", \"WARNING\", \"ERROR\"). (optional) 
            var parentObservationId = "parentObservationId_example";  // string? |  (optional) 
            var environment = new List<string>?(); // List<string>? | Optional filter for observations where the environment is one of the provided values. (optional) 
            var fromStartTime = DateTime.Parse("2013-10-20T19:20:30+01:00");  // DateTime? | Retrieve only observations with a start_time on or after this datetime (ISO 8601). (optional) 
            var toStartTime = DateTime.Parse("2013-10-20T19:20:30+01:00");  // DateTime? | Retrieve only observations with a start_time before this datetime (ISO 8601). (optional) 
            var version = "version_example";  // string? | Optional filter to only include observations with a certain version. (optional) 

            try
            {
                LfObservationsViews result = apiInstance.ObservationsGetMany(page, limit, name, userId, type, traceId, level, parentObservationId, environment, fromStartTime, toStartTime, version);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ObservationsApi.ObservationsGetMany: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ObservationsGetManyWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<LfObservationsViews> response = apiInstance.ObservationsGetManyWithHttpInfo(page, limit, name, userId, type, traceId, level, parentObservationId, environment, fromStartTime, toStartTime, version);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ObservationsApi.ObservationsGetManyWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **page** | **int?** | Page number, starts at 1. | [optional]  |
| **limit** | **int?** | Limit of items per page. If you encounter api issues due to too large page sizes, try to reduce the limit. | [optional]  |
| **name** | **string?** |  | [optional]  |
| **userId** | **string?** |  | [optional]  |
| **type** | **string?** |  | [optional]  |
| **traceId** | **string?** |  | [optional]  |
| **level** | [**LfObservationLevel?**](LfObservationLevel?.md) | Optional filter for observations with a specific level (e.g. \&quot;DEBUG\&quot;, \&quot;DEFAULT\&quot;, \&quot;WARNING\&quot;, \&quot;ERROR\&quot;). | [optional]  |
| **parentObservationId** | **string?** |  | [optional]  |
| **environment** | [**List&lt;string&gt;?**](string.md) | Optional filter for observations where the environment is one of the provided values. | [optional]  |
| **fromStartTime** | **DateTime?** | Retrieve only observations with a start_time on or after this datetime (ISO 8601). | [optional]  |
| **toStartTime** | **DateTime?** | Retrieve only observations with a start_time before this datetime (ISO 8601). | [optional]  |
| **version** | **string?** | Optional filter to only include observations with a certain version. | [optional]  |

### Return type

[**LfObservationsViews**](LfObservationsViews.md)

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

