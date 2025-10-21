using Microsoft.Agents.AI;

using Azure.AI.Agents.Persistent;
using Azure.AI.Projects;
using Azure.Identity;

using OpenAI;

using Spectre.Console;

AnsiConsole.Write(
    new FigletText("01-simple-ai-foundry-agent")
        .LeftJustified()
        .Color(Color.Green));

var endpoint = "https://gz-open-ai-service.services.ai.azure.com/api/projects/gz-ai-fundry-simple-project";
var deploymentName = Environment.GetEnvironmentVariable("AZURE_OPENAI_DEPLOYMENT_NAME") ?? "gpt-4o-mini";

var projectClient = new AIProjectClient(
    new Uri(endpoint),
    new DefaultAzureCredential());

var persistentAgentsClient = projectClient.GetPersistentAgentsClient();
var writer = await GetOrCreateAgentAsync(
    persistentAgentsClient,
    "Writer",
    """
    You are a creative writing assistant who crafts vivid, 
    well-structured stories with compelling characters based on user prompts, 
    and formats them after writing.
    Limit story to 200 words.
    """);

var story = AnsiConsole.Prompt(new TextPrompt<string>("What story would you like to write?"));

await foreach (var update in writer.RunStreamingAsync(story))
{
    AnsiConsole.Write(update.Text);
}

async Task<AIAgent> GetOrCreateAgentAsync(PersistentAgentsClient client, string agentName, string instructions)
{
    await foreach (var agent in client.Administration.GetAgentsAsync())
    {
        if (agent.Name != agentName) continue;
        return await client.GetAIAgentAsync(agent.Id);
    }
    var agentMetadata = await client.Administration.CreateAgentAsync(
        model: deploymentName,
        name: agentName,
        instructions: instructions);
    return await client.GetAIAgentAsync(agentMetadata.Value.Id);
}