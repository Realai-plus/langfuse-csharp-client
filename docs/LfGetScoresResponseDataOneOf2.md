# Langfuse.Client.Model.LfGetScoresResponseDataOneOf2

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Id** | **string** |  | 
**TraceId** | **string** |  | [optional] 
**SessionId** | **string** |  | [optional] 
**ObservationId** | **string** |  | [optional] 
**DatasetRunId** | **string** |  | [optional] 
**Name** | **string** |  | 
**Source** | **LfScoreSource** |  | 
**Timestamp** | **DateTime** |  | 
**CreatedAt** | **DateTime** |  | 
**UpdatedAt** | **DateTime** |  | 
**AuthorUserId** | **string** |  | [optional] 
**Comment** | **string** |  | [optional] 
**Metadata** | **Object** |  | [optional] 
**ConfigId** | **string** | Reference a score config on a score. When set, config and score name must be equal and value must comply to optionally defined numerical range | [optional] 
**QueueId** | **string** | Reference an annotation queue on a score. Populated if the score was initially created in an annotation queue. | [optional] 
**VarEnvironment** | **string** | The environment from which this score originated. Can be any lowercase alphanumeric string with hyphens and underscores that does not start with &#39;langfuse&#39;. | [optional] 
**Value** | **double** | The numeric value of the score. Equals 1 for \&quot;True\&quot; and 0 for \&quot;False\&quot; | 
**StringValue** | **string** | The string representation of the score value. Is inferred from the numeric value and equals \&quot;True\&quot; or \&quot;False\&quot; | 
**Trace** | [**LfGetScoresResponseTraceData**](LfGetScoresResponseTraceData.md) |  | [optional] 
**DataType** | **string** |  | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

