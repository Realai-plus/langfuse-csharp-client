# Langfuse.Client.Api.PromptVersionApi

All URIs are relative to *http://localhost*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**PromptVersionUpdate**](PromptVersionApi.md#promptversionupdate) | **PATCH** /api/public/v2/prompts/{name}/versions/{version} |  |

<a id="promptversionupdate"></a>
# **PromptVersionUpdate**
> LfPrompt PromptVersionUpdate (string name, int version, LfPromptVersionUpdateRequest lfPromptVersionUpdateRequest)



Update labels for a specific prompt version

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
    public class PromptVersionUpdateExample
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
            var apiInstance = new PromptVersionApi(httpClient, config, httpClientHandler);
            var name = "name_example";  // string | The name of the prompt
            var version = 56;  // int | Version of the prompt to update
            var lfPromptVersionUpdateRequest = new LfPromptVersionUpdateRequest(); // LfPromptVersionUpdateRequest | 

            try
            {
                LfPrompt result = apiInstance.PromptVersionUpdate(name, version, lfPromptVersionUpdateRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling PromptVersionApi.PromptVersionUpdate: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the PromptVersionUpdateWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<LfPrompt> response = apiInstance.PromptVersionUpdateWithHttpInfo(name, version, lfPromptVersionUpdateRequest);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling PromptVersionApi.PromptVersionUpdateWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **name** | **string** | The name of the prompt |  |
| **version** | **int** | Version of the prompt to update |  |
| **lfPromptVersionUpdateRequest** | [**LfPromptVersionUpdateRequest**](LfPromptVersionUpdateRequest.md) |  |  |

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

