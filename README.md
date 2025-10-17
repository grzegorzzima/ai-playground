# AI Playground

[![.NET 9.0](https://img.shields.io/badge/.NET-9.0-512BD4?style=flat-square&logo=.net)](https://dotnet.microsoft.com/)
[![Azure AI](https://img.shields.io/badge/Azure-AI-0078D4?style=flat-square&logo=microsoft-azure)](https://azure.microsoft.com/en-us/products/ai-services)
[![Build Status](https://img.shields.io/badge/Build-Passing-brightgreen?style=flat-square)](https://github.com/grzegorzzima/ai-playground)

An experimental .NET 9.0 playground for exploring AI-related functionality, featuring text tokenization services and Microsoft Agent Framework integration for building intelligent applications.

## Overview

This repository serves as a testing ground for various AI technologies and patterns, currently focusing on:

- **Text Tokenization**: GPT-4 compatible tokenization using Microsoft.ML.Tokenizers
- **Agent Framework**: Experimental integration with Microsoft's Agent Framework for building AI agents
- **Azure AI Integration**: Working with Azure AI services and OpenAI models

The project demonstrates practical implementations of AI patterns while maintaining clean architecture and testing practices.

## Features

- **Advanced Tokenization**: Support for GPT-4 tokenizer with special tokens (`<|im_start|>`, `<|im_end|>`, `<|im_sep|>`)
- **Agent Framework Integration**: Experimental Microsoft Agent Framework implementation with Azure AI Projects
- **Azure AI Services**: Integration with Azure OpenAI, AI Projects, and monitoring capabilities
- **Testing Framework**: NUnit-based testing with console output for debugging
- **Modern .NET**: Built on .NET 9.0 with nullable reference types and implicit usings

## Project Structure

```text
src/
├── AI.Tokenizer/           # Text tokenization services
│   ├── TextService.cs      # Core tokenization functionality
│   ├── Tests.cs           # NUnit tests for tokenizer
│   └── AI.Tokenizer.csproj
├── AI.MsAgentFramework/    # Microsoft Agent Framework integration
│   ├── Program.cs         # Agent creation and workflow examples
│   └── AI.MsAgentFramework.csproj
└── AI.Copilot/            # Placeholder for future Copilot functionality
    ├── Class1.cs          # Minimal placeholder class
    └── AI.Copilot.csproj
```

## Technology Stack

### Core Technologies

- **.NET 9.0**: Latest .NET framework with performance improvements
- **C# 13**: Modern C# language features
- **Microsoft.ML.Tokenizers**: Official Microsoft tokenization library
- **NUnit**: Testing framework with console debugging support

### Azure AI Services

- **Azure.AI.Projects**: Project-based AI service management
- **Azure.AI.OpenAI**: Azure OpenAI service integration
- **Microsoft.Agents.AI**: Preview Microsoft Agent Framework
- **Azure.Identity**: Authentication and credential management
- **OpenTelemetry**: Distributed tracing and monitoring

### Development Tools

- **Azure Monitor**: Application performance monitoring
- **Azure CLI**: Command-line deployment and management
- **PowerShell**: Cross-platform scripting and automation

## Getting Started

### Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [Azure CLI](https://docs.microsoft.com/en-us/cli/azure/install-azure-cli) (for Azure integration)
- [PowerShell 7+](https://github.com/PowerShell/PowerShell) (recommended)
- Azure subscription with AI services access (for full functionality)

### Local Development

1. **Clone the repository**:

   ```bash
   git clone https://github.com/grzegorzzima/ai-playground.git
   cd ai-playground
   ```

2. **Build the solution**:

   ```bash
   dotnet build
   ```

3. **Run tests**:

   ```bash
   dotnet test
   ```

4. **Run individual projects**:

   ```bash
   # Run the Agent Framework example
   dotnet run --project src/AI.MsAgentFramework

   # Test tokenization services
   dotnet test src/AI.Tokenizer
   ```

## Configuration

### Azure AI Setup

For the Agent Framework integration, you'll need:

1. **Azure AI Project**: Create an AI project in Azure
2. **Environment Variables**: Set the following:

   ```bash
   export AZURE_OPENAI_DEPLOYMENT_NAME="your-model-deployment"
   ```

3. **Authentication**: Use Azure CLI authentication:

   ```bash
   az login
   ```

> [!NOTE]
> The current implementation uses Azure CLI credentials for authentication. Ensure you have appropriate permissions for Azure AI services.

### Local Testing

The tokenization services can be tested without Azure dependencies:

```bash
dotnet test src/AI.Tokenizer --logger "console;verbosity=detailed"
```

## Usage Examples

### Text Tokenization

```csharp
var textService = new TextService();

// Count tokens in text
int tokenCount = textService.CountTokens();
Console.WriteLine($"Token count: {tokenCount}");

// Get individual tokens
string tokens = textService.GetTokens();
Console.WriteLine($"Tokens: {tokens}");
```

### Agent Framework (Preview)

```csharp
// Create AI project client
var projectClient = new AIProjectClient(
    new Uri(endpoint),
    new AzureCliCredential());

// Create a persistent agent
var agentMetadata = await persistentAgentsClient.Administration.CreateAgentAsync(
    model: "gpt-4o-mini",
    name: "Assistant",
    instructions: "You are a helpful assistant.");
```

## Testing

The project uses NUnit for testing with console output for debugging:

```bash
# Run all tests
dotnet test

# Run specific test project
dotnet test src/AI.Tokenizer

# Run with detailed output
dotnet test --logger "console;verbosity=detailed"
```

> [!TIP]
> Tests output results to console for easy debugging during development.

## Architecture Notes

- **Experimental Nature**: This is a playground for testing AI concepts and patterns
- **Co-located Tests**: Tests are included in the same projects as implementation for rapid experimentation
- **Azure Integration**: Designed to work with Azure AI services but can run locally for basic functionality
- **Modular Design**: Each AI service is separated into its own project for independent development

## Roadmap

- [ ] Enhanced Agent Framework workflows
- [ ] Additional tokenization models support  
- [ ] Integration with more Azure AI services
- [ ] Performance benchmarking and optimization
- [ ] Advanced RAG (Retrieval-Augmented Generation) patterns
- [ ] Expand Copilot functionality implementation

## Resources

- [Microsoft Agent Framework Documentation](https://github.com/microsoft/agents)
- [Azure AI Services Documentation](https://docs.microsoft.com/azure/ai-services/)
- [Microsoft.ML.Tokenizers](https://www.nuget.org/packages/Microsoft.ML.Tokenizers)
- [.NET 9.0 Documentation](https://docs.microsoft.com/dotnet/core/whats-new/dotnet-9)
