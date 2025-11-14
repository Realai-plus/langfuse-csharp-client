# Langfuse.Client.Api.CommentsApi

All URIs are relative to *http://localhost*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**CommentsCreate**](CommentsApi.md#commentscreate) | **POST** /api/public/comments |  |
| [**CommentsGet**](CommentsApi.md#commentsget) | **GET** /api/public/comments |  |
| [**CommentsGetById**](CommentsApi.md#commentsgetbyid) | **GET** /api/public/comments/{commentId} |  |

<a id="commentscreate"></a>
# **CommentsCreate**
> LfCreateCommentResponse CommentsCreate (LfCreateCommentRequest lfCreateCommentRequest)



Create a comment. Comments may be attached to different object types (trace, observation, session, prompt).

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
    public class CommentsCreateExample
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
            var apiInstance = new CommentsApi(httpClient, config, httpClientHandler);
            var lfCreateCommentRequest = new LfCreateCommentRequest(); // LfCreateCommentRequest | 

            try
            {
                LfCreateCommentResponse result = apiInstance.CommentsCreate(lfCreateCommentRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CommentsApi.CommentsCreate: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the CommentsCreateWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<LfCreateCommentResponse> response = apiInstance.CommentsCreateWithHttpInfo(lfCreateCommentRequest);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling CommentsApi.CommentsCreateWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **lfCreateCommentRequest** | [**LfCreateCommentRequest**](LfCreateCommentRequest.md) |  |  |

### Return type

[**LfCreateCommentResponse**](LfCreateCommentResponse.md)

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

<a id="commentsget"></a>
# **CommentsGet**
> LfGetCommentsResponse CommentsGet (int? page = null, int? limit = null, string? objectType = null, string? objectId = null, string? authorUserId = null)



Get all comments

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
    public class CommentsGetExample
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
            var apiInstance = new CommentsApi(httpClient, config, httpClientHandler);
            var page = 56;  // int? | Page number, starts at 1. (optional) 
            var limit = 56;  // int? | Limit of items per page. If you encounter api issues due to too large page sizes, try to reduce the limit (optional) 
            var objectType = "objectType_example";  // string? | Filter comments by object type (trace, observation, session, prompt). (optional) 
            var objectId = "objectId_example";  // string? | Filter comments by object id. If objectType is not provided, an error will be thrown. (optional) 
            var authorUserId = "authorUserId_example";  // string? | Filter comments by author user id. (optional) 

            try
            {
                LfGetCommentsResponse result = apiInstance.CommentsGet(page, limit, objectType, objectId, authorUserId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CommentsApi.CommentsGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the CommentsGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<LfGetCommentsResponse> response = apiInstance.CommentsGetWithHttpInfo(page, limit, objectType, objectId, authorUserId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling CommentsApi.CommentsGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **page** | **int?** | Page number, starts at 1. | [optional]  |
| **limit** | **int?** | Limit of items per page. If you encounter api issues due to too large page sizes, try to reduce the limit | [optional]  |
| **objectType** | **string?** | Filter comments by object type (trace, observation, session, prompt). | [optional]  |
| **objectId** | **string?** | Filter comments by object id. If objectType is not provided, an error will be thrown. | [optional]  |
| **authorUserId** | **string?** | Filter comments by author user id. | [optional]  |

### Return type

[**LfGetCommentsResponse**](LfGetCommentsResponse.md)

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

<a id="commentsgetbyid"></a>
# **CommentsGetById**
> LfComment CommentsGetById (string commentId)



Get a comment by id

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
    public class CommentsGetByIdExample
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
            var apiInstance = new CommentsApi(httpClient, config, httpClientHandler);
            var commentId = "commentId_example";  // string | The unique langfuse identifier of a comment

            try
            {
                LfComment result = apiInstance.CommentsGetById(commentId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CommentsApi.CommentsGetById: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the CommentsGetByIdWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<LfComment> response = apiInstance.CommentsGetByIdWithHttpInfo(commentId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling CommentsApi.CommentsGetByIdWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **commentId** | **string** | The unique langfuse identifier of a comment |  |

### Return type

[**LfComment**](LfComment.md)

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

