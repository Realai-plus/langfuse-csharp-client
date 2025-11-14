# Langfuse.Client.Model.LfCreateModelRequest

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ModelName** | **string** | Name of the model definition. If multiple with the same name exist, they are applied in the following order: (1) custom over built-in, (2) newest according to startTime where model.startTime&lt;observation.startTime | 
**MatchPattern** | **string** | Regex pattern which matches this model definition to generation.model. Useful in case of fine-tuned models. If you want to exact match, use &#x60;(?i)^modelname$&#x60; | 
**StartDate** | **DateTime?** | Apply only to generations which are newer than this ISO date. | [optional] 
**Unit** | **LfModelUsageUnit** |  | [optional] 
**InputPrice** | **double?** | Price (USD) per input unit | [optional] 
**OutputPrice** | **double?** | Price (USD) per output unit | [optional] 
**TotalPrice** | **double?** | Price (USD) per total units. Cannot be set if input or output price is set. | [optional] 
**TokenizerId** | **string** | Optional. Tokenizer to be applied to observations which match to this model. See docs for more details. | [optional] 
**TokenizerConfig** | **Object** | Optional. Configuration for the selected tokenizer. Needs to be JSON. See docs for more details. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

