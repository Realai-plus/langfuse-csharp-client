# Langfuse.Client.Model.LfModel
Model definition used for transforming usage into USD cost and/or tokenization.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Id** | **string** |  | 
**ModelName** | **string** | Name of the model definition. If multiple with the same name exist, they are applied in the following order: (1) custom over built-in, (2) newest according to startTime where model.startTime&lt;observation.startTime | 
**MatchPattern** | **string** | Regex pattern which matches this model definition to generation.model. Useful in case of fine-tuned models. If you want to exact match, use &#x60;(?i)^modelname$&#x60; | 
**StartDate** | **DateTime?** | Apply only to generations which are newer than this ISO date. | [optional] 
**Unit** | **LfModelUsageUnit** |  | [optional] 
**InputPrice** | **double?** | Deprecated. See &#39;prices&#39; instead. Price (USD) per input unit | [optional] 
**OutputPrice** | **double?** | Deprecated. See &#39;prices&#39; instead. Price (USD) per output unit | [optional] 
**TotalPrice** | **double?** | Deprecated. See &#39;prices&#39; instead. Price (USD) per total unit. Cannot be set if input or output price is set. | [optional] 
**TokenizerId** | **string** | Optional. Tokenizer to be applied to observations which match to this model. See docs for more details. | [optional] 
**TokenizerConfig** | **Object** | Optional. Configuration for the selected tokenizer. Needs to be JSON. See docs for more details. | [optional] 
**IsLangfuseManaged** | **bool** |  | 
**Prices** | [**Dictionary&lt;string, LfModelPrice&gt;**](LfModelPrice.md) | Price (USD) by usage type | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

