# Langfuse.Client.Model.LfCreateGenerationBody

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**TraceId** | **string** |  | [optional] 
**Name** | **string** |  | [optional] 
**StartTime** | **DateTime?** |  | [optional] 
**Metadata** | **Object** |  | [optional] 
**Input** | **Object** |  | [optional] 
**Output** | **Object** |  | [optional] 
**Level** | **LfObservationLevel** |  | [optional] 
**StatusMessage** | **string** |  | [optional] 
**ParentObservationId** | **string** |  | [optional] 
**VarVersion** | **string** |  | [optional] 
**VarEnvironment** | **string** |  | [optional] 
**Id** | **string** |  | [optional] 
**EndTime** | **DateTime?** |  | [optional] 
**CompletionStartTime** | **DateTime?** |  | [optional] 
**Model** | **string** |  | [optional] 
**ModelParameters** | [**Dictionary&lt;string, LfMapValue&gt;**](LfMapValue.md) |  | [optional] 
**Usage** | [**LfIngestionUsage**](LfIngestionUsage.md) |  | [optional] 
**UsageDetails** | [**LfUsageDetails**](LfUsageDetails.md) |  | [optional] 
**CostDetails** | **Dictionary&lt;string, double&gt;** |  | [optional] 
**PromptName** | **string** |  | [optional] 
**PromptVersion** | **int?** |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

