using Microsoft.ML.Tokenizers;

namespace AI.Tokenizer;

public class TextService
{
    private readonly Dictionary<string, int> _specialTokens = new()
    {
        {"<|im_start|>", 100264},
        { "<|im_end|>", 100265},
        {"<|im_sep|>", 100266}
    };

    private Microsoft.ML.Tokenizers.Tokenizer _tokenizer = default!;

    public int CountTokens()
    {
        _tokenizer = TiktokenTokenizer.CreateForModel("gpt-4", _specialTokens);
        return _tokenizer.CountTokens("Hello, World!");
    }

    public string GetTokens()
    {
        _tokenizer = TiktokenTokenizer.CreateForModel("gpt-4", _specialTokens);
        var tokens = _tokenizer.EncodeToTokens("Hello, World!", out var normalizedText);
        return string.Join(", ", tokens.Select(t => t.Value));
    }
}