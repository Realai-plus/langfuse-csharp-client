# Langfuse.Client.Model.LfTextPrompt

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Name** | **string** |  | 
**VarVersion** | **int** |  | 
**Config** | **Object** |  | 
**Labels** | **List&lt;string&gt;** | List of deployment labels of this prompt version. | 
**Tags** | **List&lt;string&gt;** | List of tags. Used to filter via UI and API. The same across versions of a prompt. | 
**CommitMessage** | **string** | Commit message for this prompt version. | [optional] 
**ResolutionGraph** | **Dictionary&lt;string, Object&gt;** | The dependency resolution graph for the current prompt. Null if prompt has no dependencies. | [optional] 
**Prompt** | **string** |  | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

