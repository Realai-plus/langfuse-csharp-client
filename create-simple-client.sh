#!/bin/bash

echo "Creating simplified Langfuse C# client..."

# Создаем новый проект библиотеки
dotnet new classlib -n Langfuse.Client -o Langfuse.Client

# Добавляем зависимости
cd Langfuse.Client
dotnet add package Newtonsoft.Json
dotnet add package System.ComponentModel.Annotations

# Генерируем клиент прямо в проект
echo "Generating client code..."
nswag openapi2csclient \
    /input:../langfuse-openapi.yml \
    /output:LangfuseClient.cs \
    /namespace:Langfuse.Client \
    /className:LangfuseApiClient \
    /generateClientInterfaces:false \
    /generateDtoTypes:true \
    /generateOptionalPropertiesAsNullable:true \
    /generateNullableReferenceTypes:false \
    /dateType:System.DateTime \
    /dateTimeType:System.DateTime \
    /arrayType:System.Collections.Generic.List \
    /dictionaryType:System.Collections.Generic.Dictionary \
    /classStyle:Poco \
    /operationGenerationMode:SingleClientFromPathSegments \
    /generateExceptionClasses:true \
    /generateResponseClasses:false \
    /wrapResponses:false \
    /httpClientType:System.Net.Http.HttpClient \
    /useBaseUrl:true \
    /generateBaseUrlProperty:true \
    /generateDataAnnotations:false \
    /generateDefaultValues:false

echo "Building library..."
dotnet build

echo "Done! Library created in Langfuse.Client/"