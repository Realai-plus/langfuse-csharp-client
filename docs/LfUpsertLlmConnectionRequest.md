# Langfuse.Client.Model.LfUpsertLlmConnectionRequest
Request to create or update an LLM connection (upsert)

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Provider** | **string** | Provider name (e.g., &#39;openai&#39;, &#39;my-gateway&#39;). Must be unique in project, used for upserting. | 
**Adapter** | **LfLlmAdapter** |  | 
**SecretKey** | **string** | Secret key for the LLM API. | 
**BaseURL** | **string** | Custom base URL for the LLM API | [optional] 
**CustomModels** | **List&lt;string&gt;** | List of custom model names | [optional] 
**WithDefaultModels** | **bool?** | Whether to include default models. Default is true. | [optional] 
**ExtraHeaders** | **Dictionary&lt;string, string&gt;** | Extra headers to send with requests | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

