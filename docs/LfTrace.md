# Langfuse.Client.Model.LfTrace

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Id** | **string** | The unique identifier of a trace | 
**Timestamp** | **DateTime** | The timestamp when the trace was created | 
**Name** | **string** | The name of the trace | [optional] 
**Input** | **Object** | The input data of the trace. Can be any JSON. | [optional] 
**Output** | **Object** | The output data of the trace. Can be any JSON. | [optional] 
**SessionId** | **string** | The session identifier associated with the trace | [optional] 
**Release** | **string** | The release version of the application when the trace was created | [optional] 
**VarVersion** | **string** | The version of the trace | [optional] 
**UserId** | **string** | The user identifier associated with the trace | [optional] 
**Metadata** | **Object** | The metadata associated with the trace. Can be any JSON. | [optional] 
**Tags** | **List&lt;string&gt;** | The tags associated with the trace. Can be an array of strings or null. | [optional] 
**Public** | **bool?** | Public traces are accessible via url without login | [optional] 
**VarEnvironment** | **string** | The environment from which this trace originated. Can be any lowercase alphanumeric string with hyphens and underscores that does not start with &#39;langfuse&#39;. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

