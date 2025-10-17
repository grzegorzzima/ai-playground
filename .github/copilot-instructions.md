# AI Playground - Copilot Instructions

## Project Architecture

This is a .NET 9.0 experimental playground for AI-related functionality consisting of two main components:

- **AI.Tokenizer** (`src/AI.Tokenizer/`): Text tokenization services using Microsoft.ML.Tokenizers
- **AI.Copilot** (`src/AI.Copilot/`): Currently minimal AI copilot functionality (placeholder)

## Key Patterns & Conventions

### Tokenization Service Pattern
The `TextService` class in `AI.Tokenizer/Class1.cs` demonstrates the project's approach to AI text processing:

```csharp
// Special tokens are defined as class-level dictionary
private readonly Dictionary<string, int> _specialTokens = new()
{
    {"<|im_start|>", 100264},
    { "<|im_end|>", 100265},
    {"<|im_sep|>", 100266}
};

// GPT-4 model is used as the default tokenizer model
_tokenizer = TiktokenTokenizer.CreateForModel("gpt-4", _specialTokens);
```

### Testing Structure
- Tests are co-located with implementation files (not in separate test projects)
- Uses NUnit framework with `[TestFixture]` and `[Test]` attributes
- Test classes follow `{ClassName}Test` or `{ClassName}Tests` naming pattern
- Tests output results to Console for debugging: `Console.WriteLine(result)`

### Project Configuration
- All projects target `.NET 9.0` with `ImplicitUsings` and `Nullable` enabled
- Solution uses folder structure with `src/` containing all project folders
- No external dependencies beyond Microsoft.ML.Tokenizers and NUnit

## Development Workflows

### Building
```bash
dotnet build          # Build entire solution
dotnet build src/AI.Tokenizer/  # Build specific project
```

### Testing
```bash
dotnet test           # Run all tests in solution
dotnet test src/AI.Tokenizer/   # Run tests for specific project
```

Note: The current test setup has discovery issues - tests are defined but not being found by the test runner. When adding new tests, ensure proper NUnit attribute usage.

### Project Structure Guidelines
- Keep implementation and tests in the same project for experimental code
- Use meaningful class names rather than generic `Class1.cs`
- Place core functionality in dedicated service classes (e.g., `TextService`)

## Integration Points

- **Microsoft.ML.Tokenizers**: Primary dependency for text tokenization using Tiktoken models
- **NUnit**: Testing framework with console output for debugging
- **Solution-level**: Multi-project solution with shared .NET 9.0 configuration

## AI/ML Specific Notes

- Default to GPT-4 tokenizer model for compatibility
- Special tokens are pre-configured for common chat completion patterns (`<|im_start|>`, `<|im_end|>`, `<|im_sep|>`)
- Token counting and encoding operations are the primary use cases demonstrated