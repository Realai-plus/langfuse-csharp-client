# Langfuse.Client.Api.PromptsApi

All URIs are relative to *http://localhost*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**PromptsCreate**](PromptsApi.md#promptscreate) | **POST** /api/public/v2/prompts |  |
| [**PromptsGet**](PromptsApi.md#promptsget) | **GET** /api/public/v2/prompts/{promptName} |  |
| [**PromptsList**](PromptsApi.md#promptslist) | **GET** /api/public/v2/prompts |  |

<a id="promptscreate"></a>
# **PromptsCreate**
> LfPrompt PromptsCreate (LfCreatePromptRequest lfCreatePromptRequest)



Create a new version for the prompt with the given `name`

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
    public class PromptsCreateExample
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
            var apiInstance = new PromptsApi(httpClient, config, httpClientHandler);
            var lfCreatePromptRequest = new LfCreatePromptRequest(); // LfCreatePromptRequest | 

            try
            {
                LfPrompt result = apiInstance.PromptsCreate(lfCreatePromptRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling PromptsApi.PromptsCreate: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the PromptsCreateWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<LfPrompt> response = apiInstance.PromptsCreateWithHttpInfo(lfCreatePromptRequest);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling PromptsApi.PromptsCreateWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **lfCreatePromptRequest** | [**LfCreatePromptRequest**](LfCreatePromptRequest.md) |  |  |

### Return type

[**LfPrompt**](LfPrompt.md)

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

<a id="promptsget"></a>
# **PromptsGet**
> LfPrompt PromptsGet (string promptName, int? version = null, string? label = null)



Get a prompt

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
    public class PromptsGetExample
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
            var apiInstance = new PromptsApi(httpClient, config, httpClientHandler);
            var promptName = "promptName_example";  // string | The name of the prompt
            var version = 56;  // int? | Version of the prompt to be retrieved. (optional) 
            var label = "label_example";  // string? | Label of the prompt to be retrieved. Defaults to \"production\" if no label or version is set. (optional) 

            try
            {
                LfPrompt result = apiInstance.PromptsGet(promptName, version, label);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling PromptsApi.PromptsGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the PromptsGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<LfPrompt> response = apiInstance.PromptsGetWithHttpInfo(promptName, version, label);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling PromptsApi.PromptsGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **promptName** | **string** | The name of the prompt |  |
| **version** | **int?** | Version of the prompt to be retrieved. | [optional]  |
| **label** | **string?** | Label of the prompt to be retrieved. Defaults to \&quot;production\&quot; if no label or version is set. | [optional]  |

### Return type

[**LfPrompt**](LfPrompt.md)

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

<a id="promptslist"></a>
# **PromptsList**
> LfPromptMetaListResponse PromptsList (string? name = null, string? label = null, string? tag = null, int? page = null, int? limit = null, DateTime? fromUpdatedAt = null, DateTime? toUpdatedAt = null)



Get a list of prompt names with versions and labels

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
    public class PromptsListExample
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
            var apiInstance = new PromptsApi(httpClient, config, httpClientHandler);
            var name = "name_example";  // string? |  (optional) 
            var label = "label_example";  // string? |  (optional) 
            var tag = "tag_example";  // string? |  (optional) 
            var page = 56;  // int? | page number, starts at 1 (optional) 
            var limit = 56;  // int? | limit of items per page (optional) 
            var fromUpdatedAt = DateTime.Parse("2013-10-20T19:20:30+01:00");  // DateTime? | Optional filter to only include prompt versions created/updated on or after a certain datetime (ISO 8601) (optional) 
            var toUpdatedAt = DateTime.Parse("2013-10-20T19:20:30+01:00");  // DateTime? | Optional filter to only include prompt versions created/updated before a certain datetime (ISO 8601) (optional) 

            try
            {
                LfPromptMetaListResponse result = apiInstance.PromptsList(name, label, tag, page, limit, fromUpdatedAt, toUpdatedAt);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling PromptsApi.PromptsList: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the PromptsListWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<LfPromptMetaListResponse> response = apiInstance.PromptsListWithHttpInfo(name, label, tag, page, limit, fromUpdatedAt, toUpdatedAt);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling PromptsApi.PromptsListWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **name** | **string?** |  | [optional]  |
| **label** | **string?** |  | [optional]  |
| **tag** | **string?** |  | [optional]  |
| **page** | **int?** | page number, starts at 1 | [optional]  |
| **limit** | **int?** | limit of items per page | [optional]  |
| **fromUpdatedAt** | **DateTime?** | Optional filter to only include prompt versions created/updated on or after a certain datetime (ISO 8601) | [optional]  |
| **toUpdatedAt** | **DateTime?** | Optional filter to only include prompt versions created/updated before a certain datetime (ISO 8601) | [optional]  |

### Return type

[**LfPromptMetaListResponse**](LfPromptMetaListResponse.md)

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

