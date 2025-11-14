# Langfuse.Client.Model.LfCreateCommentRequest

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ProjectId** | **string** | The id of the project to attach the comment to. | 
**ObjectType** | **string** | The type of the object to attach the comment to (trace, observation, session, prompt). | 
**ObjectId** | **string** | The id of the object to attach the comment to. If this does not reference a valid existing object, an error will be thrown. | 
**Content** | **string** | The content of the comment. May include markdown. Currently limited to 3000 characters. | 
**AuthorUserId** | **string** | The id of the user who created the comment. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

