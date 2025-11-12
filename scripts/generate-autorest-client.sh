#!/bin/bash

# Установка AutoRest
npm install -g autorest

# Генерация C# клиента
autorest --input-file=../langfuse-openapi.yml \
    --csharp \
    --output-folder=../generated/autorest-client \
    --namespace=Langfuse.Client \
    --add-credentials \
    --sync-methods=none \
    --client-side-validation=true \
    --generate-client-as-interface=true \
    --useDateTimeOffset=true

echo "AutoRest client generation completed!"