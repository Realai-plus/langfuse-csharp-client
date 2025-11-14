# Langfuse.Client.Api.OrganizationsApi

All URIs are relative to *http://localhost*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**OrganizationsDeleteOrganizationMembership**](OrganizationsApi.md#organizationsdeleteorganizationmembership) | **DELETE** /api/public/organizations/memberships |  |
| [**OrganizationsDeleteProjectMembership**](OrganizationsApi.md#organizationsdeleteprojectmembership) | **DELETE** /api/public/projects/{projectId}/memberships |  |
| [**OrganizationsGetOrganizationMemberships**](OrganizationsApi.md#organizationsgetorganizationmemberships) | **GET** /api/public/organizations/memberships |  |
| [**OrganizationsGetOrganizationProjects**](OrganizationsApi.md#organizationsgetorganizationprojects) | **GET** /api/public/organizations/projects |  |
| [**OrganizationsGetProjectMemberships**](OrganizationsApi.md#organizationsgetprojectmemberships) | **GET** /api/public/projects/{projectId}/memberships |  |
| [**OrganizationsUpdateOrganizationMembership**](OrganizationsApi.md#organizationsupdateorganizationmembership) | **PUT** /api/public/organizations/memberships |  |
| [**OrganizationsUpdateProjectMembership**](OrganizationsApi.md#organizationsupdateprojectmembership) | **PUT** /api/public/projects/{projectId}/memberships |  |

<a id="organizationsdeleteorganizationmembership"></a>
# **OrganizationsDeleteOrganizationMembership**
> LfMembershipDeletionResponse OrganizationsDeleteOrganizationMembership (LfDeleteMembershipRequest lfDeleteMembershipRequest)



Delete a membership from the organization associated with the API key (requires organization-scoped API key)

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
    public class OrganizationsDeleteOrganizationMembershipExample
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
            var apiInstance = new OrganizationsApi(httpClient, config, httpClientHandler);
            var lfDeleteMembershipRequest = new LfDeleteMembershipRequest(); // LfDeleteMembershipRequest | 

            try
            {
                LfMembershipDeletionResponse result = apiInstance.OrganizationsDeleteOrganizationMembership(lfDeleteMembershipRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling OrganizationsApi.OrganizationsDeleteOrganizationMembership: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the OrganizationsDeleteOrganizationMembershipWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<LfMembershipDeletionResponse> response = apiInstance.OrganizationsDeleteOrganizationMembershipWithHttpInfo(lfDeleteMembershipRequest);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling OrganizationsApi.OrganizationsDeleteOrganizationMembershipWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **lfDeleteMembershipRequest** | [**LfDeleteMembershipRequest**](LfDeleteMembershipRequest.md) |  |  |

### Return type

[**LfMembershipDeletionResponse**](LfMembershipDeletionResponse.md)

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

<a id="organizationsdeleteprojectmembership"></a>
# **OrganizationsDeleteProjectMembership**
> LfMembershipDeletionResponse OrganizationsDeleteProjectMembership (string projectId, LfDeleteMembershipRequest lfDeleteMembershipRequest)



Delete a membership from a specific project (requires organization-scoped API key). The user must be a member of the organization.

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
    public class OrganizationsDeleteProjectMembershipExample
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
            var apiInstance = new OrganizationsApi(httpClient, config, httpClientHandler);
            var projectId = "projectId_example";  // string | 
            var lfDeleteMembershipRequest = new LfDeleteMembershipRequest(); // LfDeleteMembershipRequest | 

            try
            {
                LfMembershipDeletionResponse result = apiInstance.OrganizationsDeleteProjectMembership(projectId, lfDeleteMembershipRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling OrganizationsApi.OrganizationsDeleteProjectMembership: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the OrganizationsDeleteProjectMembershipWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<LfMembershipDeletionResponse> response = apiInstance.OrganizationsDeleteProjectMembershipWithHttpInfo(projectId, lfDeleteMembershipRequest);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling OrganizationsApi.OrganizationsDeleteProjectMembershipWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **projectId** | **string** |  |  |
| **lfDeleteMembershipRequest** | [**LfDeleteMembershipRequest**](LfDeleteMembershipRequest.md) |  |  |

### Return type

[**LfMembershipDeletionResponse**](LfMembershipDeletionResponse.md)

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

<a id="organizationsgetorganizationmemberships"></a>
# **OrganizationsGetOrganizationMemberships**
> LfMembershipsResponse OrganizationsGetOrganizationMemberships ()



Get all memberships for the organization associated with the API key (requires organization-scoped API key)

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
    public class OrganizationsGetOrganizationMembershipsExample
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
            var apiInstance = new OrganizationsApi(httpClient, config, httpClientHandler);

            try
            {
                LfMembershipsResponse result = apiInstance.OrganizationsGetOrganizationMemberships();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling OrganizationsApi.OrganizationsGetOrganizationMemberships: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the OrganizationsGetOrganizationMembershipsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<LfMembershipsResponse> response = apiInstance.OrganizationsGetOrganizationMembershipsWithHttpInfo();
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling OrganizationsApi.OrganizationsGetOrganizationMembershipsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters
This endpoint does not need any parameter.
### Return type

[**LfMembershipsResponse**](LfMembershipsResponse.md)

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

<a id="organizationsgetorganizationprojects"></a>
# **OrganizationsGetOrganizationProjects**
> LfOrganizationProjectsResponse OrganizationsGetOrganizationProjects ()



Get all projects for the organization associated with the API key (requires organization-scoped API key)

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
    public class OrganizationsGetOrganizationProjectsExample
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
            var apiInstance = new OrganizationsApi(httpClient, config, httpClientHandler);

            try
            {
                LfOrganizationProjectsResponse result = apiInstance.OrganizationsGetOrganizationProjects();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling OrganizationsApi.OrganizationsGetOrganizationProjects: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the OrganizationsGetOrganizationProjectsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<LfOrganizationProjectsResponse> response = apiInstance.OrganizationsGetOrganizationProjectsWithHttpInfo();
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling OrganizationsApi.OrganizationsGetOrganizationProjectsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters
This endpoint does not need any parameter.
### Return type

[**LfOrganizationProjectsResponse**](LfOrganizationProjectsResponse.md)

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

<a id="organizationsgetprojectmemberships"></a>
# **OrganizationsGetProjectMemberships**
> LfMembershipsResponse OrganizationsGetProjectMemberships (string projectId)



Get all memberships for a specific project (requires organization-scoped API key)

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
    public class OrganizationsGetProjectMembershipsExample
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
            var apiInstance = new OrganizationsApi(httpClient, config, httpClientHandler);
            var projectId = "projectId_example";  // string | 

            try
            {
                LfMembershipsResponse result = apiInstance.OrganizationsGetProjectMemberships(projectId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling OrganizationsApi.OrganizationsGetProjectMemberships: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the OrganizationsGetProjectMembershipsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<LfMembershipsResponse> response = apiInstance.OrganizationsGetProjectMembershipsWithHttpInfo(projectId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling OrganizationsApi.OrganizationsGetProjectMembershipsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **projectId** | **string** |  |  |

### Return type

[**LfMembershipsResponse**](LfMembershipsResponse.md)

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

<a id="organizationsupdateorganizationmembership"></a>
# **OrganizationsUpdateOrganizationMembership**
> LfMembershipResponse OrganizationsUpdateOrganizationMembership (LfMembershipRequest lfMembershipRequest)



Create or update a membership for the organization associated with the API key (requires organization-scoped API key)

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
    public class OrganizationsUpdateOrganizationMembershipExample
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
            var apiInstance = new OrganizationsApi(httpClient, config, httpClientHandler);
            var lfMembershipRequest = new LfMembershipRequest(); // LfMembershipRequest | 

            try
            {
                LfMembershipResponse result = apiInstance.OrganizationsUpdateOrganizationMembership(lfMembershipRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling OrganizationsApi.OrganizationsUpdateOrganizationMembership: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the OrganizationsUpdateOrganizationMembershipWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<LfMembershipResponse> response = apiInstance.OrganizationsUpdateOrganizationMembershipWithHttpInfo(lfMembershipRequest);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling OrganizationsApi.OrganizationsUpdateOrganizationMembershipWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **lfMembershipRequest** | [**LfMembershipRequest**](LfMembershipRequest.md) |  |  |

### Return type

[**LfMembershipResponse**](LfMembershipResponse.md)

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

<a id="organizationsupdateprojectmembership"></a>
# **OrganizationsUpdateProjectMembership**
> LfMembershipResponse OrganizationsUpdateProjectMembership (string projectId, LfMembershipRequest lfMembershipRequest)



Create or update a membership for a specific project (requires organization-scoped API key). The user must already be a member of the organization.

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
    public class OrganizationsUpdateProjectMembershipExample
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
            var apiInstance = new OrganizationsApi(httpClient, config, httpClientHandler);
            var projectId = "projectId_example";  // string | 
            var lfMembershipRequest = new LfMembershipRequest(); // LfMembershipRequest | 

            try
            {
                LfMembershipResponse result = apiInstance.OrganizationsUpdateProjectMembership(projectId, lfMembershipRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling OrganizationsApi.OrganizationsUpdateProjectMembership: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the OrganizationsUpdateProjectMembershipWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<LfMembershipResponse> response = apiInstance.OrganizationsUpdateProjectMembershipWithHttpInfo(projectId, lfMembershipRequest);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling OrganizationsApi.OrganizationsUpdateProjectMembershipWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **projectId** | **string** |  |  |
| **lfMembershipRequest** | [**LfMembershipRequest**](LfMembershipRequest.md) |  |  |

### Return type

[**LfMembershipResponse**](LfMembershipResponse.md)

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

