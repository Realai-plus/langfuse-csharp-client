# Langfuse.Client.Model.LfCreateDatasetRunItemRequest

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**RunName** | **string** |  | 
**RunDescription** | **string** | Description of the run. If run exists, description will be updated. | [optional] 
**Metadata** | **Object** | Metadata of the dataset run, updates run if run already exists | [optional] 
**DatasetItemId** | **string** |  | 
**ObservationId** | **string** |  | [optional] 
**TraceId** | **string** | traceId should always be provided. For compatibility with older SDK versions it can also be inferred from the provided observationId. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

