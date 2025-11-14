# Langfuse.Client.Model.LfScoreBody

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Id** | **string** |  | [optional] 
**TraceId** | **string** |  | [optional] 
**SessionId** | **string** |  | [optional] 
**ObservationId** | **string** |  | [optional] 
**DatasetRunId** | **string** |  | [optional] 
**Name** | **string** |  | 
**VarEnvironment** | **string** |  | [optional] 
**Value** | [**LfCreateScoreValue**](LfCreateScoreValue.md) |  | 
**Comment** | **string** |  | [optional] 
**Metadata** | **Object** |  | [optional] 
**DataType** | **LfScoreDataType** |  | [optional] 
**ConfigId** | **string** | Reference a score config on a score. When set, the score name must equal the config name and scores must comply with the config&#39;s range and data type. For categorical scores, the value must map to a config category. Numeric scores might be constrained by the score config&#39;s max and min values | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

