# Langfuse.Client.Api.AnnotationQueuesApi

All URIs are relative to *http://localhost*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**AnnotationQueuesCreateQueue**](AnnotationQueuesApi.md#annotationqueuescreatequeue) | **POST** /api/public/annotation-queues |  |
| [**AnnotationQueuesCreateQueueAssignment**](AnnotationQueuesApi.md#annotationqueuescreatequeueassignment) | **POST** /api/public/annotation-queues/{queueId}/assignments |  |
| [**AnnotationQueuesCreateQueueItem**](AnnotationQueuesApi.md#annotationqueuescreatequeueitem) | **POST** /api/public/annotation-queues/{queueId}/items |  |
| [**AnnotationQueuesDeleteQueueAssignment**](AnnotationQueuesApi.md#annotationqueuesdeletequeueassignment) | **DELETE** /api/public/annotation-queues/{queueId}/assignments |  |
| [**AnnotationQueuesDeleteQueueItem**](AnnotationQueuesApi.md#annotationqueuesdeletequeueitem) | **DELETE** /api/public/annotation-queues/{queueId}/items/{itemId} |  |
| [**AnnotationQueuesGetQueue**](AnnotationQueuesApi.md#annotationqueuesgetqueue) | **GET** /api/public/annotation-queues/{queueId} |  |
| [**AnnotationQueuesGetQueueItem**](AnnotationQueuesApi.md#annotationqueuesgetqueueitem) | **GET** /api/public/annotation-queues/{queueId}/items/{itemId} |  |
| [**AnnotationQueuesListQueueItems**](AnnotationQueuesApi.md#annotationqueueslistqueueitems) | **GET** /api/public/annotation-queues/{queueId}/items |  |
| [**AnnotationQueuesListQueues**](AnnotationQueuesApi.md#annotationqueueslistqueues) | **GET** /api/public/annotation-queues |  |
| [**AnnotationQueuesUpdateQueueItem**](AnnotationQueuesApi.md#annotationqueuesupdatequeueitem) | **PATCH** /api/public/annotation-queues/{queueId}/items/{itemId} |  |

<a id="annotationqueuescreatequeue"></a>
# **AnnotationQueuesCreateQueue**
> LfAnnotationQueue AnnotationQueuesCreateQueue (LfCreateAnnotationQueueRequest lfCreateAnnotationQueueRequest)



Create an annotation queue

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
    public class AnnotationQueuesCreateQueueExample
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
            var apiInstance = new AnnotationQueuesApi(httpClient, config, httpClientHandler);
            var lfCreateAnnotationQueueRequest = new LfCreateAnnotationQueueRequest(); // LfCreateAnnotationQueueRequest | 

            try
            {
                LfAnnotationQueue result = apiInstance.AnnotationQueuesCreateQueue(lfCreateAnnotationQueueRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AnnotationQueuesApi.AnnotationQueuesCreateQueue: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the AnnotationQueuesCreateQueueWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<LfAnnotationQueue> response = apiInstance.AnnotationQueuesCreateQueueWithHttpInfo(lfCreateAnnotationQueueRequest);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AnnotationQueuesApi.AnnotationQueuesCreateQueueWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **lfCreateAnnotationQueueRequest** | [**LfCreateAnnotationQueueRequest**](LfCreateAnnotationQueueRequest.md) |  |  |

### Return type

[**LfAnnotationQueue**](LfAnnotationQueue.md)

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

<a id="annotationqueuescreatequeueassignment"></a>
# **AnnotationQueuesCreateQueueAssignment**
> LfCreateAnnotationQueueAssignmentResponse AnnotationQueuesCreateQueueAssignment (string queueId, LfAnnotationQueueAssignmentRequest lfAnnotationQueueAssignmentRequest)



Create an assignment for a user to an annotation queue

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
    public class AnnotationQueuesCreateQueueAssignmentExample
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
            var apiInstance = new AnnotationQueuesApi(httpClient, config, httpClientHandler);
            var queueId = "queueId_example";  // string | The unique identifier of the annotation queue
            var lfAnnotationQueueAssignmentRequest = new LfAnnotationQueueAssignmentRequest(); // LfAnnotationQueueAssignmentRequest | 

            try
            {
                LfCreateAnnotationQueueAssignmentResponse result = apiInstance.AnnotationQueuesCreateQueueAssignment(queueId, lfAnnotationQueueAssignmentRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AnnotationQueuesApi.AnnotationQueuesCreateQueueAssignment: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the AnnotationQueuesCreateQueueAssignmentWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<LfCreateAnnotationQueueAssignmentResponse> response = apiInstance.AnnotationQueuesCreateQueueAssignmentWithHttpInfo(queueId, lfAnnotationQueueAssignmentRequest);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AnnotationQueuesApi.AnnotationQueuesCreateQueueAssignmentWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **queueId** | **string** | The unique identifier of the annotation queue |  |
| **lfAnnotationQueueAssignmentRequest** | [**LfAnnotationQueueAssignmentRequest**](LfAnnotationQueueAssignmentRequest.md) |  |  |

### Return type

[**LfCreateAnnotationQueueAssignmentResponse**](LfCreateAnnotationQueueAssignmentResponse.md)

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

<a id="annotationqueuescreatequeueitem"></a>
# **AnnotationQueuesCreateQueueItem**
> LfAnnotationQueueItem AnnotationQueuesCreateQueueItem (string queueId, LfCreateAnnotationQueueItemRequest lfCreateAnnotationQueueItemRequest)



Add an item to an annotation queue

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
    public class AnnotationQueuesCreateQueueItemExample
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
            var apiInstance = new AnnotationQueuesApi(httpClient, config, httpClientHandler);
            var queueId = "queueId_example";  // string | The unique identifier of the annotation queue
            var lfCreateAnnotationQueueItemRequest = new LfCreateAnnotationQueueItemRequest(); // LfCreateAnnotationQueueItemRequest | 

            try
            {
                LfAnnotationQueueItem result = apiInstance.AnnotationQueuesCreateQueueItem(queueId, lfCreateAnnotationQueueItemRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AnnotationQueuesApi.AnnotationQueuesCreateQueueItem: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the AnnotationQueuesCreateQueueItemWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<LfAnnotationQueueItem> response = apiInstance.AnnotationQueuesCreateQueueItemWithHttpInfo(queueId, lfCreateAnnotationQueueItemRequest);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AnnotationQueuesApi.AnnotationQueuesCreateQueueItemWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **queueId** | **string** | The unique identifier of the annotation queue |  |
| **lfCreateAnnotationQueueItemRequest** | [**LfCreateAnnotationQueueItemRequest**](LfCreateAnnotationQueueItemRequest.md) |  |  |

### Return type

[**LfAnnotationQueueItem**](LfAnnotationQueueItem.md)

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

<a id="annotationqueuesdeletequeueassignment"></a>
# **AnnotationQueuesDeleteQueueAssignment**
> LfDeleteAnnotationQueueAssignmentResponse AnnotationQueuesDeleteQueueAssignment (string queueId, LfAnnotationQueueAssignmentRequest lfAnnotationQueueAssignmentRequest)



Delete an assignment for a user to an annotation queue

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
    public class AnnotationQueuesDeleteQueueAssignmentExample
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
            var apiInstance = new AnnotationQueuesApi(httpClient, config, httpClientHandler);
            var queueId = "queueId_example";  // string | The unique identifier of the annotation queue
            var lfAnnotationQueueAssignmentRequest = new LfAnnotationQueueAssignmentRequest(); // LfAnnotationQueueAssignmentRequest | 

            try
            {
                LfDeleteAnnotationQueueAssignmentResponse result = apiInstance.AnnotationQueuesDeleteQueueAssignment(queueId, lfAnnotationQueueAssignmentRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AnnotationQueuesApi.AnnotationQueuesDeleteQueueAssignment: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the AnnotationQueuesDeleteQueueAssignmentWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<LfDeleteAnnotationQueueAssignmentResponse> response = apiInstance.AnnotationQueuesDeleteQueueAssignmentWithHttpInfo(queueId, lfAnnotationQueueAssignmentRequest);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AnnotationQueuesApi.AnnotationQueuesDeleteQueueAssignmentWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **queueId** | **string** | The unique identifier of the annotation queue |  |
| **lfAnnotationQueueAssignmentRequest** | [**LfAnnotationQueueAssignmentRequest**](LfAnnotationQueueAssignmentRequest.md) |  |  |

### Return type

[**LfDeleteAnnotationQueueAssignmentResponse**](LfDeleteAnnotationQueueAssignmentResponse.md)

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

<a id="annotationqueuesdeletequeueitem"></a>
# **AnnotationQueuesDeleteQueueItem**
> LfDeleteAnnotationQueueItemResponse AnnotationQueuesDeleteQueueItem (string queueId, string itemId)



Remove an item from an annotation queue

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
    public class AnnotationQueuesDeleteQueueItemExample
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
            var apiInstance = new AnnotationQueuesApi(httpClient, config, httpClientHandler);
            var queueId = "queueId_example";  // string | The unique identifier of the annotation queue
            var itemId = "itemId_example";  // string | The unique identifier of the annotation queue item

            try
            {
                LfDeleteAnnotationQueueItemResponse result = apiInstance.AnnotationQueuesDeleteQueueItem(queueId, itemId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AnnotationQueuesApi.AnnotationQueuesDeleteQueueItem: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the AnnotationQueuesDeleteQueueItemWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<LfDeleteAnnotationQueueItemResponse> response = apiInstance.AnnotationQueuesDeleteQueueItemWithHttpInfo(queueId, itemId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AnnotationQueuesApi.AnnotationQueuesDeleteQueueItemWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **queueId** | **string** | The unique identifier of the annotation queue |  |
| **itemId** | **string** | The unique identifier of the annotation queue item |  |

### Return type

[**LfDeleteAnnotationQueueItemResponse**](LfDeleteAnnotationQueueItemResponse.md)

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

<a id="annotationqueuesgetqueue"></a>
# **AnnotationQueuesGetQueue**
> LfAnnotationQueue AnnotationQueuesGetQueue (string queueId)



Get an annotation queue by ID

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
    public class AnnotationQueuesGetQueueExample
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
            var apiInstance = new AnnotationQueuesApi(httpClient, config, httpClientHandler);
            var queueId = "queueId_example";  // string | The unique identifier of the annotation queue

            try
            {
                LfAnnotationQueue result = apiInstance.AnnotationQueuesGetQueue(queueId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AnnotationQueuesApi.AnnotationQueuesGetQueue: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the AnnotationQueuesGetQueueWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<LfAnnotationQueue> response = apiInstance.AnnotationQueuesGetQueueWithHttpInfo(queueId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AnnotationQueuesApi.AnnotationQueuesGetQueueWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **queueId** | **string** | The unique identifier of the annotation queue |  |

### Return type

[**LfAnnotationQueue**](LfAnnotationQueue.md)

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

<a id="annotationqueuesgetqueueitem"></a>
# **AnnotationQueuesGetQueueItem**
> LfAnnotationQueueItem AnnotationQueuesGetQueueItem (string queueId, string itemId)



Get a specific item from an annotation queue

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
    public class AnnotationQueuesGetQueueItemExample
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
            var apiInstance = new AnnotationQueuesApi(httpClient, config, httpClientHandler);
            var queueId = "queueId_example";  // string | The unique identifier of the annotation queue
            var itemId = "itemId_example";  // string | The unique identifier of the annotation queue item

            try
            {
                LfAnnotationQueueItem result = apiInstance.AnnotationQueuesGetQueueItem(queueId, itemId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AnnotationQueuesApi.AnnotationQueuesGetQueueItem: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the AnnotationQueuesGetQueueItemWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<LfAnnotationQueueItem> response = apiInstance.AnnotationQueuesGetQueueItemWithHttpInfo(queueId, itemId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AnnotationQueuesApi.AnnotationQueuesGetQueueItemWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **queueId** | **string** | The unique identifier of the annotation queue |  |
| **itemId** | **string** | The unique identifier of the annotation queue item |  |

### Return type

[**LfAnnotationQueueItem**](LfAnnotationQueueItem.md)

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

<a id="annotationqueueslistqueueitems"></a>
# **AnnotationQueuesListQueueItems**
> LfPaginatedAnnotationQueueItems AnnotationQueuesListQueueItems (string queueId, LfAnnotationQueueStatus? status = null, int? page = null, int? limit = null)



Get items for a specific annotation queue

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
    public class AnnotationQueuesListQueueItemsExample
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
            var apiInstance = new AnnotationQueuesApi(httpClient, config, httpClientHandler);
            var queueId = "queueId_example";  // string | The unique identifier of the annotation queue
            var status = new LfAnnotationQueueStatus?(); // LfAnnotationQueueStatus? | Filter by status (optional) 
            var page = 56;  // int? | page number, starts at 1 (optional) 
            var limit = 56;  // int? | limit of items per page (optional) 

            try
            {
                LfPaginatedAnnotationQueueItems result = apiInstance.AnnotationQueuesListQueueItems(queueId, status, page, limit);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AnnotationQueuesApi.AnnotationQueuesListQueueItems: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the AnnotationQueuesListQueueItemsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<LfPaginatedAnnotationQueueItems> response = apiInstance.AnnotationQueuesListQueueItemsWithHttpInfo(queueId, status, page, limit);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AnnotationQueuesApi.AnnotationQueuesListQueueItemsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **queueId** | **string** | The unique identifier of the annotation queue |  |
| **status** | [**LfAnnotationQueueStatus?**](LfAnnotationQueueStatus?.md) | Filter by status | [optional]  |
| **page** | **int?** | page number, starts at 1 | [optional]  |
| **limit** | **int?** | limit of items per page | [optional]  |

### Return type

[**LfPaginatedAnnotationQueueItems**](LfPaginatedAnnotationQueueItems.md)

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

<a id="annotationqueueslistqueues"></a>
# **AnnotationQueuesListQueues**
> LfPaginatedAnnotationQueues AnnotationQueuesListQueues (int? page = null, int? limit = null)



Get all annotation queues

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
    public class AnnotationQueuesListQueuesExample
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
            var apiInstance = new AnnotationQueuesApi(httpClient, config, httpClientHandler);
            var page = 56;  // int? | page number, starts at 1 (optional) 
            var limit = 56;  // int? | limit of items per page (optional) 

            try
            {
                LfPaginatedAnnotationQueues result = apiInstance.AnnotationQueuesListQueues(page, limit);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AnnotationQueuesApi.AnnotationQueuesListQueues: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the AnnotationQueuesListQueuesWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<LfPaginatedAnnotationQueues> response = apiInstance.AnnotationQueuesListQueuesWithHttpInfo(page, limit);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AnnotationQueuesApi.AnnotationQueuesListQueuesWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **page** | **int?** | page number, starts at 1 | [optional]  |
| **limit** | **int?** | limit of items per page | [optional]  |

### Return type

[**LfPaginatedAnnotationQueues**](LfPaginatedAnnotationQueues.md)

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

<a id="annotationqueuesupdatequeueitem"></a>
# **AnnotationQueuesUpdateQueueItem**
> LfAnnotationQueueItem AnnotationQueuesUpdateQueueItem (string queueId, string itemId, LfUpdateAnnotationQueueItemRequest lfUpdateAnnotationQueueItemRequest)



Update an annotation queue item

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
    public class AnnotationQueuesUpdateQueueItemExample
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
            var apiInstance = new AnnotationQueuesApi(httpClient, config, httpClientHandler);
            var queueId = "queueId_example";  // string | The unique identifier of the annotation queue
            var itemId = "itemId_example";  // string | The unique identifier of the annotation queue item
            var lfUpdateAnnotationQueueItemRequest = new LfUpdateAnnotationQueueItemRequest(); // LfUpdateAnnotationQueueItemRequest | 

            try
            {
                LfAnnotationQueueItem result = apiInstance.AnnotationQueuesUpdateQueueItem(queueId, itemId, lfUpdateAnnotationQueueItemRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AnnotationQueuesApi.AnnotationQueuesUpdateQueueItem: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the AnnotationQueuesUpdateQueueItemWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<LfAnnotationQueueItem> response = apiInstance.AnnotationQueuesUpdateQueueItemWithHttpInfo(queueId, itemId, lfUpdateAnnotationQueueItemRequest);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AnnotationQueuesApi.AnnotationQueuesUpdateQueueItemWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **queueId** | **string** | The unique identifier of the annotation queue |  |
| **itemId** | **string** | The unique identifier of the annotation queue item |  |
| **lfUpdateAnnotationQueueItemRequest** | [**LfUpdateAnnotationQueueItemRequest**](LfUpdateAnnotationQueueItemRequest.md) |  |  |

### Return type

[**LfAnnotationQueueItem**](LfAnnotationQueueItem.md)

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

