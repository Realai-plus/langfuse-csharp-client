# Langfuse.Client.Api.DatasetItemsApi

All URIs are relative to *http://localhost*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**DatasetItemsCreate**](DatasetItemsApi.md#datasetitemscreate) | **POST** /api/public/dataset-items |  |
| [**DatasetItemsDelete**](DatasetItemsApi.md#datasetitemsdelete) | **DELETE** /api/public/dataset-items/{id} |  |
| [**DatasetItemsGet**](DatasetItemsApi.md#datasetitemsget) | **GET** /api/public/dataset-items/{id} |  |
| [**DatasetItemsList**](DatasetItemsApi.md#datasetitemslist) | **GET** /api/public/dataset-items |  |

<a id="datasetitemscreate"></a>
# **DatasetItemsCreate**
> LfDatasetItem DatasetItemsCreate (LfCreateDatasetItemRequest lfCreateDatasetItemRequest)



Create a dataset item

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
    public class DatasetItemsCreateExample
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
            var apiInstance = new DatasetItemsApi(httpClient, config, httpClientHandler);
            var lfCreateDatasetItemRequest = new LfCreateDatasetItemRequest(); // LfCreateDatasetItemRequest | 

            try
            {
                LfDatasetItem result = apiInstance.DatasetItemsCreate(lfCreateDatasetItemRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DatasetItemsApi.DatasetItemsCreate: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the DatasetItemsCreateWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<LfDatasetItem> response = apiInstance.DatasetItemsCreateWithHttpInfo(lfCreateDatasetItemRequest);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling DatasetItemsApi.DatasetItemsCreateWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **lfCreateDatasetItemRequest** | [**LfCreateDatasetItemRequest**](LfCreateDatasetItemRequest.md) |  |  |

### Return type

[**LfDatasetItem**](LfDatasetItem.md)

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

<a id="datasetitemsdelete"></a>
# **DatasetItemsDelete**
> LfDeleteDatasetItemResponse DatasetItemsDelete (string id)



Delete a dataset item and all its run items. This action is irreversible.

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
    public class DatasetItemsDeleteExample
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
            var apiInstance = new DatasetItemsApi(httpClient, config, httpClientHandler);
            var id = "id_example";  // string | 

            try
            {
                LfDeleteDatasetItemResponse result = apiInstance.DatasetItemsDelete(id);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DatasetItemsApi.DatasetItemsDelete: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the DatasetItemsDeleteWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<LfDeleteDatasetItemResponse> response = apiInstance.DatasetItemsDeleteWithHttpInfo(id);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling DatasetItemsApi.DatasetItemsDeleteWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **string** |  |  |

### Return type

[**LfDeleteDatasetItemResponse**](LfDeleteDatasetItemResponse.md)

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

<a id="datasetitemsget"></a>
# **DatasetItemsGet**
> LfDatasetItem DatasetItemsGet (string id)



Get a dataset item

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
    public class DatasetItemsGetExample
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
            var apiInstance = new DatasetItemsApi(httpClient, config, httpClientHandler);
            var id = "id_example";  // string | 

            try
            {
                LfDatasetItem result = apiInstance.DatasetItemsGet(id);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DatasetItemsApi.DatasetItemsGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the DatasetItemsGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<LfDatasetItem> response = apiInstance.DatasetItemsGetWithHttpInfo(id);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling DatasetItemsApi.DatasetItemsGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **string** |  |  |

### Return type

[**LfDatasetItem**](LfDatasetItem.md)

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

<a id="datasetitemslist"></a>
# **DatasetItemsList**
> LfPaginatedDatasetItems DatasetItemsList (string? datasetName = null, string? sourceTraceId = null, string? sourceObservationId = null, int? page = null, int? limit = null)



Get dataset items

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
    public class DatasetItemsListExample
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
            var apiInstance = new DatasetItemsApi(httpClient, config, httpClientHandler);
            var datasetName = "datasetName_example";  // string? |  (optional) 
            var sourceTraceId = "sourceTraceId_example";  // string? |  (optional) 
            var sourceObservationId = "sourceObservationId_example";  // string? |  (optional) 
            var page = 56;  // int? | page number, starts at 1 (optional) 
            var limit = 56;  // int? | limit of items per page (optional) 

            try
            {
                LfPaginatedDatasetItems result = apiInstance.DatasetItemsList(datasetName, sourceTraceId, sourceObservationId, page, limit);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DatasetItemsApi.DatasetItemsList: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the DatasetItemsListWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<LfPaginatedDatasetItems> response = apiInstance.DatasetItemsListWithHttpInfo(datasetName, sourceTraceId, sourceObservationId, page, limit);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling DatasetItemsApi.DatasetItemsListWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **datasetName** | **string?** |  | [optional]  |
| **sourceTraceId** | **string?** |  | [optional]  |
| **sourceObservationId** | **string?** |  | [optional]  |
| **page** | **int?** | page number, starts at 1 | [optional]  |
| **limit** | **int?** | limit of items per page | [optional]  |

### Return type

[**LfPaginatedDatasetItems**](LfPaginatedDatasetItems.md)

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

