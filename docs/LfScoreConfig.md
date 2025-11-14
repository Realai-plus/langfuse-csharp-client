# Langfuse.Client.Model.LfScoreConfig
Configuration for a score

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Id** | **string** |  | 
**Name** | **string** |  | 
**CreatedAt** | **DateTime** |  | 
**UpdatedAt** | **DateTime** |  | 
**ProjectId** | **string** |  | 
**DataType** | **LfScoreDataType** |  | 
**IsArchived** | **bool** | Whether the score config is archived. Defaults to false | 
**MinValue** | **double?** | Sets minimum value for numerical scores. If not set, the minimum value defaults to -∞ | [optional] 
**MaxValue** | **double?** | Sets maximum value for numerical scores. If not set, the maximum value defaults to +∞ | [optional] 
**Categories** | [**List&lt;LfConfigCategory&gt;**](LfConfigCategory.md) | Configures custom categories for categorical scores | [optional] 
**Description** | **string** |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

