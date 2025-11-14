# Langfuse.Client.Model.LfGetMediaUploadUrlRequest

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**TraceId** | **string** | The trace ID associated with the media record | 
**ObservationId** | **string** | The observation ID associated with the media record. If the media record is associated directly with a trace, this will be null. | [optional] 
**ContentType** | **LfMediaContentType** |  | 
**ContentLength** | **int** | The size of the media record in bytes | 
**Sha256Hash** | **string** | The SHA-256 hash of the media record | 
**Field** | **string** | The trace / observation field the media record is associated with. This can be one of &#x60;input&#x60;, &#x60;output&#x60;, &#x60;metadata&#x60; | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

