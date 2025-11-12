#!/bin/bash

set -e  # Exit on error

echo "╔════════════════════════════════════════════════╗"
echo "║  Langfuse C# Client Generator                 ║"
echo "║  Using OpenAPI Generator with fixes            ║"
echo "╚════════════════════════════════════════════════╝"
echo ""

# Определяем корневую директорию проекта
SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
PROJECT_ROOT="$(dirname "$SCRIPT_DIR")"
CLIENT_DIR="$PROJECT_ROOT/src/Langfuse.Client"

echo "📁 Project root: $PROJECT_ROOT"
echo "📁 Output directory: $PROJECT_ROOT"
echo ""

# Проверяем наличие OpenAPI спецификации
if [ ! -f "$PROJECT_ROOT/langfuse-openapi.yml" ]; then
    echo "❌ OpenAPI spec not found: $PROJECT_ROOT/langfuse-openapi.yml"
    echo "   Download it first:"
    echo "   wget https://cloud.langfuse.com/generated/api/openapi.yml -O langfuse-openapi.yml"
    exit 1
fi

echo "✓ Found OpenAPI spec: langfuse-openapi.yml"
echo ""

# Удаляем старую версию если существует
if [ -d "$CLIENT_DIR" ]; then
    echo "🗑️  Removing old generated client..."
    rm -rf "$CLIENT_DIR"
fi

# Создаем .openapi-generator-ignore чтобы не перезаписывать наши файлы
cat > "$PROJECT_ROOT/.openapi-generator-ignore" <<EOF
# Не перезаписывать наши файлы
README.md
langfuse-csharp-client.sln
SimpleExample/
Example/
scripts/
config/
examples/
EOF

echo "✓ Created .openapi-generator-ignore"
echo ""

# Генерируем клиент
echo "⚙️  Generating client with OpenAPI Generator..."
echo ""

# Проверяем метод запуска
if command -v openapi-generator-cli &> /dev/null; then
    echo "Using openapi-generator-cli (npm)"
    openapi-generator-cli generate \
        -i "$PROJECT_ROOT/langfuse-openapi.yml" \
        -g csharp \
        -o "$PROJECT_ROOT" \
        --model-name-prefix Lf \
        --additional-properties=targetFramework=net8.0,packageName=Langfuse.Client,packageVersion=1.0.0,netCoreProjectFile=true,library=httpclient
elif command -v docker &> /dev/null; then
    echo "Using Docker"
    docker run --rm \
        -v "$PROJECT_ROOT:/local" openapitools/openapi-generator-cli generate \
        -i /local/langfuse-openapi.yml \
        -g csharp \
        -o /local \
        --model-name-prefix Lf \
        --additional-properties=targetFramework=net8.0,packageName=Langfuse.Client,packageVersion=1.0.0,netCoreProjectFile=true,library=httpclient
else
    echo "❌ Neither openapi-generator-cli nor Docker found!"
    echo "   Install one of them:"
    echo "   - npm install @openapitools/openapi-generator-cli -g"
    echo "   - or install Docker"
    exit 1
fi

echo ""
echo "✅ Client generated successfully!"
echo ""

# Применяем исправления
echo "🔧 Applying fixes..."
echo ""

MODEL_DIR="$CLIENT_DIR/Model"

if [ -d "$MODEL_DIR" ]; then
    echo "1️⃣  Fixing invalid method names (GetInt?() → GetIntNullable())..."

    # Исправляем GetInt?()
    find "$MODEL_DIR" -name "*.cs" -type f -exec sed -i 's/public int? GetInt?()/public int? GetIntNullable()/g' {} +

    # Исправляем GetBool?()
    find "$MODEL_DIR" -name "*.cs" -type f -exec sed -i 's/public bool? GetBool?()/public bool? GetBoolNullable()/g' {} +

    echo "   ✓ Fixed GetInt?() methods"
    echo "   ✓ Fixed GetBool?() methods"
else
    echo "⚠️  Model directory not found, skipping fixes"
fi

echo ""

# Собираем клиент
echo "🔨 Building generated client..."
echo ""

CLIENT_PROJECT="$CLIENT_DIR/Langfuse.Client.csproj"

if [ -f "$CLIENT_PROJECT" ]; then
    cd "$CLIENT_DIR"
    dotnet build

    if [ $? -eq 0 ]; then
        echo ""
        echo "╔════════════════════════════════════════════════╗"
        echo "║           ✅ SUCCESS!                         ║"
        echo "╚════════════════════════════════════════════════╝"
        echo ""
        echo "📦 Generated files:"
        echo "   src/Langfuse.Client/    - Main library"
        echo "   docs/                   - API documentation"
        echo "   api/                    - OpenAPI spec copy"
        echo ""
        echo "🚀 Next steps:"
        echo "   1. Run the example:"
        echo "      cd $PROJECT_ROOT/Example/Example"
        echo "      dotnet run"
        echo ""
        echo "   2. Or use in your project:"
        echo "      <ProjectReference Include=\"../../src/Langfuse.Client/Langfuse.Client.csproj\" />"
        echo ""
        echo "💡 All models use 'Lf' prefix:"
        echo "   new LfTraceBody(...)"
        echo "   new LfCreateGenerationBody(...)"
        echo "   new LfScoreBody(...)"
    else
        echo ""
        echo "❌ Build failed! Check errors above."
        exit 1
    fi
else
    echo "⚠️  Project file not found: $CLIENT_PROJECT"
    echo "   Generation might have failed, check output above."
    exit 1
fi