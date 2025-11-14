# Langfuse.Client.Model.LfUsage
(Deprecated. Use usageDetails and costDetails instead.) Standard interface for usage and cost

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Input** | **int?** | Number of input units (e.g. tokens) | [optional] 
**Output** | **int?** | Number of output units (e.g. tokens) | [optional] 
**Total** | **int?** | Defaults to input+output if not set | [optional] 
**Unit** | **LfModelUsageUnit** |  | [optional] 
**InputCost** | **double?** | USD input cost | [optional] 
**OutputCost** | **double?** | USD output cost | [optional] 
**TotalCost** | **double?** | USD total cost, defaults to input+output | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

