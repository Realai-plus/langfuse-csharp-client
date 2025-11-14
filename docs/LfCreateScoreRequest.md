# Langfuse.Client.Model.LfCreateScoreRequest

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Id** | **string** |  | [optional] 
**TraceId** | **string** |  | [optional] 
**SessionId** | **string** |  | [optional] 
**ObservationId** | **string** |  | [optional] 
**DatasetRunId** | **string** |  | [optional] 
**Name** | **string** |  | 
**Value** | [**LfCreateScoreValue**](LfCreateScoreValue.md) |  | 
**Comment** | **string** |  | [optional] 
**Metadata** | **Object** |  | [optional] 
**VarEnvironment** | **string** | The environment of the score. Can be any lowercase alphanumeric string with hyphens and underscores that does not start with &#39;langfuse&#39;. | [optional] 
**DataType** | **LfScoreDataType** |  | [optional] 
**ConfigId** | **string** | Reference a score config on a score. The unique langfuse identifier of a score config. When passing this field, the dataType and stringValue fields are automatically populated. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

