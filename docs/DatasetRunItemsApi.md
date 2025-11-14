# Langfuse.Client.Api.DatasetRunItemsApi

All URIs are relative to *http://localhost*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**DatasetRunItemsCreate**](DatasetRunItemsApi.md#datasetrunitemscreate) | **POST** /api/public/dataset-run-items |  |
| [**DatasetRunItemsList**](DatasetRunItemsApi.md#datasetrunitemslist) | **GET** /api/public/dataset-run-items |  |

<a id="datasetrunitemscreate"></a>
# **DatasetRunItemsCreate**
> LfDatasetRunItem DatasetRunItemsCreate (LfCreateDatasetRunItemRequest lfCreateDatasetRunItemRequest)



Create a dataset run item

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
    public class DatasetRunItemsCreateExample
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
            var apiInstance = new DatasetRunItemsApi(httpClient, config, httpClientHandler);
            var lfCreateDatasetRunItemRequest = new LfCreateDatasetRunItemRequest(); // LfCreateDatasetRunItemRequest | 

            try
            {
                LfDatasetRunItem result = apiInstance.DatasetRunItemsCreate(lfCreateDatasetRunItemRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DatasetRunItemsApi.DatasetRunItemsCreate: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the DatasetRunItemsCreateWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<LfDatasetRunItem> response = apiInstance.DatasetRunItemsCreateWithHttpInfo(lfCreateDatasetRunItemRequest);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling DatasetRunItemsApi.DatasetRunItemsCreateWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **lfCreateDatasetRunItemRequest** | [**LfCreateDatasetRunItemRequest**](LfCreateDatasetRunItemRequest.md) |  |  |

### Return type

[**LfDatasetRunItem**](LfDatasetRunItem.md)

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

<a id="datasetrunitemslist"></a>
# **DatasetRunItemsList**
> LfPaginatedDatasetRunItems DatasetRunItemsList (string datasetId, string runName, int? page = null, int? limit = null)



List dataset run items

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
    public class DatasetRunItemsListExample
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
            var apiInstance = new DatasetRunItemsApi(httpClient, config, httpClientHandler);
            var datasetId = "datasetId_example";  // string | 
            var runName = "runName_example";  // string | 
            var page = 56;  // int? | page number, starts at 1 (optional) 
            var limit = 56;  // int? | limit of items per page (optional) 

            try
            {
                LfPaginatedDatasetRunItems result = apiInstance.DatasetRunItemsList(datasetId, runName, page, limit);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DatasetRunItemsApi.DatasetRunItemsList: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the DatasetRunItemsListWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<LfPaginatedDatasetRunItems> response = apiInstance.DatasetRunItemsListWithHttpInfo(datasetId, runName, page, limit);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling DatasetRunItemsApi.DatasetRunItemsListWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **datasetId** | **string** |  |  |
| **runName** | **string** |  |  |
| **page** | **int?** | page number, starts at 1 | [optional]  |
| **limit** | **int?** | limit of items per page | [optional]  |

### Return type

[**LfPaginatedDatasetRunItems**](LfPaginatedDatasetRunItems.md)

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

