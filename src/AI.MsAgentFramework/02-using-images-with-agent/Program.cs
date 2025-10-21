using System.ClientModel;

using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using OpenAI;

using Spectre.Console;

AnsiConsole.Write(
    new FigletText("02-Using Images with Agent")
        .LeftJustified()
        .Color(Color.Green));

var endpoint = "https://gz-open-ai-service.services.ai.azure.com/openai/v1/";
var deploymentName = Environment.GetEnvironmentVariable("AZURE_OPENAI_DEPLOYMENT_NAME") ?? "gpt-4o-mini";
var apiKey = Environment.GetEnvironmentVariable("AZURE_OPENAI_API_KEY") 
    ?? new ConfigurationBuilder().AddUserSecrets<UserSecrets>().Build().GetSection("AI_API_KEY").Value!;
var configuration = new ConfigurationBuilder().AddUserSecrets<UserSecrets>().Build();

var clientOptions = new OpenAIClientOptions()
{
    Endpoint = new Uri(endpoint)
};

OpenAIClient client = new(
    new ApiKeyCredential(apiKey),
    clientOptions);

var chatCompletionClient = client.GetChatClient(deploymentName);

var visionAgent = chatCompletionClient.CreateAIAgent(
    instructions: "You are a helpful agent that can analyze images.",
    name: "VisionAgent");

var imageUrl = AnsiConsole.Prompt(new TextPrompt<string>("Paste the image URL you want to analyze:"));

var message = new ChatMessage(ChatRole.User, [
    new TextContent("What do you see on the provided image? Use maximum 50 words to describe."),
    new UriContent(imageUrl, "image/jpeg")
]);

await foreach (var update in visionAgent.RunStreamingAsync(message))
{
    AnsiConsole.Write(update.Text);
}

record UserSecrets(string AI_API_KEY);