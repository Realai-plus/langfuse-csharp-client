# Langfuse.Client.Api.SessionsApi

All URIs are relative to *http://localhost*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**SessionsGet**](SessionsApi.md#sessionsget) | **GET** /api/public/sessions/{sessionId} |  |
| [**SessionsList**](SessionsApi.md#sessionslist) | **GET** /api/public/sessions |  |

<a id="sessionsget"></a>
# **SessionsGet**
> LfSessionWithTraces SessionsGet (string sessionId)



Get a session. Please note that `traces` on this endpoint are not paginated, if you plan to fetch large sessions, consider `GET /api/public/traces?sessionId=<sessionId>`

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
    public class SessionsGetExample
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
            var apiInstance = new SessionsApi(httpClient, config, httpClientHandler);
            var sessionId = "sessionId_example";  // string | The unique id of a session

            try
            {
                LfSessionWithTraces result = apiInstance.SessionsGet(sessionId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SessionsApi.SessionsGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the SessionsGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<LfSessionWithTraces> response = apiInstance.SessionsGetWithHttpInfo(sessionId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling SessionsApi.SessionsGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **sessionId** | **string** | The unique id of a session |  |

### Return type

[**LfSessionWithTraces**](LfSessionWithTraces.md)

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

<a id="sessionslist"></a>
# **SessionsList**
> LfPaginatedSessions SessionsList (int? page = null, int? limit = null, DateTime? fromTimestamp = null, DateTime? toTimestamp = null, List<string>? environment = null)



Get sessions

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
    public class SessionsListExample
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
            var apiInstance = new SessionsApi(httpClient, config, httpClientHandler);
            var page = 56;  // int? | Page number, starts at 1 (optional) 
            var limit = 56;  // int? | Limit of items per page. If you encounter api issues due to too large page sizes, try to reduce the limit. (optional) 
            var fromTimestamp = DateTime.Parse("2013-10-20T19:20:30+01:00");  // DateTime? | Optional filter to only include sessions created on or after a certain datetime (ISO 8601) (optional) 
            var toTimestamp = DateTime.Parse("2013-10-20T19:20:30+01:00");  // DateTime? | Optional filter to only include sessions created before a certain datetime (ISO 8601) (optional) 
            var environment = new List<string>?(); // List<string>? | Optional filter for sessions where the environment is one of the provided values. (optional) 

            try
            {
                LfPaginatedSessions result = apiInstance.SessionsList(page, limit, fromTimestamp, toTimestamp, environment);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SessionsApi.SessionsList: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the SessionsListWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<LfPaginatedSessions> response = apiInstance.SessionsListWithHttpInfo(page, limit, fromTimestamp, toTimestamp, environment);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling SessionsApi.SessionsListWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **page** | **int?** | Page number, starts at 1 | [optional]  |
| **limit** | **int?** | Limit of items per page. If you encounter api issues due to too large page sizes, try to reduce the limit. | [optional]  |
| **fromTimestamp** | **DateTime?** | Optional filter to only include sessions created on or after a certain datetime (ISO 8601) | [optional]  |
| **toTimestamp** | **DateTime?** | Optional filter to only include sessions created before a certain datetime (ISO 8601) | [optional]  |
| **environment** | [**List&lt;string&gt;?**](string.md) | Optional filter for sessions where the environment is one of the provided values. | [optional]  |

### Return type

[**LfPaginatedSessions**](LfPaginatedSessions.md)

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

