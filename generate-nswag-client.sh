#!/bin/bash

# Установка NSwag CLI (если не установлен)
echo "Installing NSwag CLI tool..."
dotnet tool install -g NSwag.ConsoleCore

# Генерация C# клиента
echo "Generating C# client from OpenAPI spec..."
nswag openapi2csclient \
    /input:langfuse-openapi.yml \
    /output:Langfuse.Client/LangfuseClient.cs \
    /namespace:Langfuse.Client \
    /className:LangfuseClient \
    /generateClientInterfaces:true \
    /generateDtoTypes:true \
    /generateOptionalPropertiesAsNullable:true \
    /generateNullableReferenceTypes:true \
    /dateType:System.DateTime \
    /dateTimeType:System.DateTime \
    /arrayType:System.Collections.Generic.List \
    /dictionaryType:System.Collections.Generic.Dictionary \
    /classStyle:Poco \
    /operationGenerationMode:MultipleClientsFromOperationId \
    /generateExceptionClasses:true \
    /generateResponseClasses:true \
    /wrapResponses:true \
    /httpClientType:System.Net.Http.HttpClient \
    /useBaseUrl:true \
    /generateBaseUrlProperty:true

echo "Client generation completed!"