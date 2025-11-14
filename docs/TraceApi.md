# Langfuse.Client.Api.TraceApi

All URIs are relative to *http://localhost*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**TraceDelete**](TraceApi.md#tracedelete) | **DELETE** /api/public/traces/{traceId} |  |
| [**TraceDeleteMultiple**](TraceApi.md#tracedeletemultiple) | **DELETE** /api/public/traces |  |
| [**TraceGet**](TraceApi.md#traceget) | **GET** /api/public/traces/{traceId} |  |
| [**TraceList**](TraceApi.md#tracelist) | **GET** /api/public/traces |  |

<a id="tracedelete"></a>
# **TraceDelete**
> LfDeleteTraceResponse TraceDelete (string traceId)



Delete a specific trace

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
    public class TraceDeleteExample
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
            var apiInstance = new TraceApi(httpClient, config, httpClientHandler);
            var traceId = "traceId_example";  // string | The unique langfuse identifier of the trace to delete

            try
            {
                LfDeleteTraceResponse result = apiInstance.TraceDelete(traceId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling TraceApi.TraceDelete: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the TraceDeleteWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<LfDeleteTraceResponse> response = apiInstance.TraceDeleteWithHttpInfo(traceId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling TraceApi.TraceDeleteWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **traceId** | **string** | The unique langfuse identifier of the trace to delete |  |

### Return type

[**LfDeleteTraceResponse**](LfDeleteTraceResponse.md)

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

<a id="tracedeletemultiple"></a>
# **TraceDeleteMultiple**
> LfDeleteTraceResponse TraceDeleteMultiple (LfTraceDeleteMultipleRequest lfTraceDeleteMultipleRequest)



Delete multiple traces

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
    public class TraceDeleteMultipleExample
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
            var apiInstance = new TraceApi(httpClient, config, httpClientHandler);
            var lfTraceDeleteMultipleRequest = new LfTraceDeleteMultipleRequest(); // LfTraceDeleteMultipleRequest | 

            try
            {
                LfDeleteTraceResponse result = apiInstance.TraceDeleteMultiple(lfTraceDeleteMultipleRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling TraceApi.TraceDeleteMultiple: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the TraceDeleteMultipleWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<LfDeleteTraceResponse> response = apiInstance.TraceDeleteMultipleWithHttpInfo(lfTraceDeleteMultipleRequest);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling TraceApi.TraceDeleteMultipleWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **lfTraceDeleteMultipleRequest** | [**LfTraceDeleteMultipleRequest**](LfTraceDeleteMultipleRequest.md) |  |  |

### Return type

[**LfDeleteTraceResponse**](LfDeleteTraceResponse.md)

### Authorization

[BasicAuth](../README.md#BasicAuth)

### HTTP request headers

 - **Content-Type**: application/json
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

<a id="traceget"></a>
# **TraceGet**
> LfTraceWithFullDetails TraceGet (string traceId)



Get a specific trace

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
    public class TraceGetExample
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
            var apiInstance = new TraceApi(httpClient, config, httpClientHandler);
            var traceId = "traceId_example";  // string | The unique langfuse identifier of a trace

            try
            {
                LfTraceWithFullDetails result = apiInstance.TraceGet(traceId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling TraceApi.TraceGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the TraceGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<LfTraceWithFullDetails> response = apiInstance.TraceGetWithHttpInfo(traceId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling TraceApi.TraceGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **traceId** | **string** | The unique langfuse identifier of a trace |  |

### Return type

[**LfTraceWithFullDetails**](LfTraceWithFullDetails.md)

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

<a id="tracelist"></a>
# **TraceList**
> LfTraces TraceList (int? page = null, int? limit = null, string? userId = null, string? name = null, string? sessionId = null, DateTime? fromTimestamp = null, DateTime? toTimestamp = null, string? orderBy = null, List<string>? tags = null, string? version = null, string? release = null, List<string>? environment = null, string? fields = null)



Get list of traces

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
    public class TraceListExample
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
            var apiInstance = new TraceApi(httpClient, config, httpClientHandler);
            var page = 56;  // int? | Page number, starts at 1 (optional) 
            var limit = 56;  // int? | Limit of items per page. If you encounter api issues due to too large page sizes, try to reduce the limit. (optional) 
            var userId = "userId_example";  // string? |  (optional) 
            var name = "name_example";  // string? |  (optional) 
            var sessionId = "sessionId_example";  // string? |  (optional) 
            var fromTimestamp = DateTime.Parse("2013-10-20T19:20:30+01:00");  // DateTime? | Optional filter to only include traces with a trace.timestamp on or after a certain datetime (ISO 8601) (optional) 
            var toTimestamp = DateTime.Parse("2013-10-20T19:20:30+01:00");  // DateTime? | Optional filter to only include traces with a trace.timestamp before a certain datetime (ISO 8601) (optional) 
            var orderBy = "orderBy_example";  // string? | Format of the string [field].[asc/desc]. Fields: id, timestamp, name, userId, release, version, public, bookmarked, sessionId. Example: timestamp.asc (optional) 
            var tags = new List<string>?(); // List<string>? | Only traces that include all of these tags will be returned. (optional) 
            var version = "version_example";  // string? | Optional filter to only include traces with a certain version. (optional) 
            var release = "release_example";  // string? | Optional filter to only include traces with a certain release. (optional) 
            var environment = new List<string>?(); // List<string>? | Optional filter for traces where the environment is one of the provided values. (optional) 
            var fields = "fields_example";  // string? | Comma-separated list of fields to include in the response. Available field groups are 'core' (always included), 'io' (input, output, metadata), 'scores', 'observations', 'metrics'. If not provided, all fields are included. Example: 'core,scores,metrics' (optional) 

            try
            {
                LfTraces result = apiInstance.TraceList(page, limit, userId, name, sessionId, fromTimestamp, toTimestamp, orderBy, tags, version, release, environment, fields);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling TraceApi.TraceList: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the TraceListWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<LfTraces> response = apiInstance.TraceListWithHttpInfo(page, limit, userId, name, sessionId, fromTimestamp, toTimestamp, orderBy, tags, version, release, environment, fields);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling TraceApi.TraceListWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **page** | **int?** | Page number, starts at 1 | [optional]  |
| **limit** | **int?** | Limit of items per page. If you encounter api issues due to too large page sizes, try to reduce the limit. | [optional]  |
| **userId** | **string?** |  | [optional]  |
| **name** | **string?** |  | [optional]  |
| **sessionId** | **string?** |  | [optional]  |
| **fromTimestamp** | **DateTime?** | Optional filter to only include traces with a trace.timestamp on or after a certain datetime (ISO 8601) | [optional]  |
| **toTimestamp** | **DateTime?** | Optional filter to only include traces with a trace.timestamp before a certain datetime (ISO 8601) | [optional]  |
| **orderBy** | **string?** | Format of the string [field].[asc/desc]. Fields: id, timestamp, name, userId, release, version, public, bookmarked, sessionId. Example: timestamp.asc | [optional]  |
| **tags** | [**List&lt;string&gt;?**](string.md) | Only traces that include all of these tags will be returned. | [optional]  |
| **version** | **string?** | Optional filter to only include traces with a certain version. | [optional]  |
| **release** | **string?** | Optional filter to only include traces with a certain release. | [optional]  |
| **environment** | [**List&lt;string&gt;?**](string.md) | Optional filter for traces where the environment is one of the provided values. | [optional]  |
| **fields** | **string?** | Comma-separated list of fields to include in the response. Available field groups are &#39;core&#39; (always included), &#39;io&#39; (input, output, metadata), &#39;scores&#39;, &#39;observations&#39;, &#39;metrics&#39;. If not provided, all fields are included. Example: &#39;core,scores,metrics&#39; | [optional]  |

### Return type

[**LfTraces**](LfTraces.md)

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

