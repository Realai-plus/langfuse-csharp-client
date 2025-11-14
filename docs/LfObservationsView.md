# Langfuse.Client.Model.LfObservationsView

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Id** | **string** | The unique identifier of the observation | 
**TraceId** | **string** | The trace ID associated with the observation | [optional] 
**Type** | **string** | The type of the observation | 
**Name** | **string** | The name of the observation | [optional] 
**StartTime** | **DateTime** | The start time of the observation | 
**EndTime** | **DateTime?** | The end time of the observation. | [optional] 
**CompletionStartTime** | **DateTime?** | The completion start time of the observation | [optional] 
**Model** | **string** | The model used for the observation | [optional] 
**ModelParameters** | [**Dictionary&lt;string, LfMapValue&gt;**](LfMapValue.md) | The parameters of the model used for the observation | [optional] 
**Input** | **Object** | The input data of the observation | [optional] 
**VarVersion** | **string** | The version of the observation | [optional] 
**Metadata** | **Object** | Additional metadata of the observation | [optional] 
**Output** | **Object** | The output data of the observation | [optional] 
**Usage** | [**LfUsage**](LfUsage.md) |  | [optional] 
**Level** | **LfObservationLevel** |  | 
**StatusMessage** | **string** | The status message of the observation | [optional] 
**ParentObservationId** | **string** | The parent observation ID | [optional] 
**PromptId** | **string** | The prompt ID associated with the observation | [optional] 
**UsageDetails** | **Dictionary&lt;string, int&gt;** | The usage details of the observation. Key is the name of the usage metric, value is the number of units consumed. The total key is the sum of all (non-total) usage metrics or the total value ingested. | [optional] 
**CostDetails** | **Dictionary&lt;string, double&gt;** | The cost details of the observation. Key is the name of the cost metric, value is the cost in USD. The total key is the sum of all (non-total) cost metrics or the total value ingested. | [optional] 
**VarEnvironment** | **string** | The environment from which this observation originated. Can be any lowercase alphanumeric string with hyphens and underscores that does not start with &#39;langfuse&#39;. | [optional] 
**PromptName** | **string** | The name of the prompt associated with the observation | [optional] 
**PromptVersion** | **int?** | The version of the prompt associated with the observation | [optional] 
**ModelId** | **string** | The unique identifier of the model | [optional] 
**InputPrice** | **double?** | The price of the input in USD | [optional] 
**OutputPrice** | **double?** | The price of the output in USD. | [optional] 
**TotalPrice** | **double?** | The total price in USD. | [optional] 
**CalculatedInputCost** | **double?** | (Deprecated. Use usageDetails and costDetails instead.) The calculated cost of the input in USD | [optional] 
**CalculatedOutputCost** | **double?** | (Deprecated. Use usageDetails and costDetails instead.) The calculated cost of the output in USD | [optional] 
**CalculatedTotalCost** | **double?** | (Deprecated. Use usageDetails and costDetails instead.) The calculated total cost in USD | [optional] 
**Latency** | **double?** | The latency in seconds. | [optional] 
**TimeToFirstToken** | **double?** | The time to the first token in seconds | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

