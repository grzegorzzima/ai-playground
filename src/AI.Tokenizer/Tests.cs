using NUnit.Framework;

namespace AI.Tokenizer;

[TestFixture]
public class TokenizeTests
{
    [Test]
    public void TestCountTokens()
    {
        var service = new TextService();
        var count = service.CountTokens();
        Console.WriteLine(count);
    }

    [Test]
    public void TestGetTokens()
    {
        var service = new TextService();
        var tokens = service.GetTokens();
        Console.WriteLine(tokens);
    }
}