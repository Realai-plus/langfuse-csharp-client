# Langfuse.Client.Model.LfLlmConnection
LLM API connection configuration (secrets excluded)

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Id** | **string** |  | 
**Provider** | **string** | Provider name (e.g., &#39;openai&#39;, &#39;my-gateway&#39;). Must be unique in project, used for upserting. | 
**Adapter** | **string** | The adapter used to interface with the LLM | 
**DisplaySecretKey** | **string** | Masked version of the secret key for display purposes | 
**BaseURL** | **string** | Custom base URL for the LLM API | [optional] 
**CustomModels** | **List&lt;string&gt;** | List of custom model names available for this connection | 
**WithDefaultModels** | **bool** | Whether to include default models for this adapter | 
**ExtraHeaderKeys** | **List&lt;string&gt;** | Keys of extra headers sent with requests (values excluded for security) | 
**CreatedAt** | **DateTime** |  | 
**UpdatedAt** | **DateTime** |  | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

