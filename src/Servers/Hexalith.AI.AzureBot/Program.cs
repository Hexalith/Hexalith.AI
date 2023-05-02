using Hexalith.AI.AzureBot.Accounts.Infrastructure.Helpers;
using Hexalith.AI.AzureBot.Bot.Application.Commands;
using Hexalith.AI.AzureBot.Bot.Infrastructure;
using Hexalith.AI.AzureBot.Conversations.Infrastructure.Helpers;
using Hexalith.AI.AzureBot.GlobalAdministrations.Infrastructure.Helpers;
using Hexalith.AI.AzureBot.SemanticKernel.Configurations;
using Hexalith.AI.AzureBot.SemanticKernel.Services;
using Hexalith.AI.AzureBot.Users.Infrastructure.Helpers;
using Hexalith.Extensions.Configuration;
using Hexalith.Infrastructure.WebApis.Helpers;

using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Integration.AspNet.Core;
using Microsoft.Bot.Connector.Authentication;
using Microsoft.TeamsFx.Conversation;

using Serilog;

const string appName = "Hexalith AI Azure Bot";

#if DEBUG
bool debugInVisualStudio = true;
#else
bool debugInVisualStudio = false;
#endif

WebApplicationBuilder builder = HexalithWebApi.CreateApplication(
    appName,
    "v1",
    debugInVisualStudio,
    (actors)
        => actors
            .AddGlobalAdministration()
            .AddConversation()
            .AddUser()
            .AddAccount(),
    args);

builder.Services.AddHttpClient("WebClient", client => client.Timeout = TimeSpan.FromSeconds(600));
builder.Services.AddHttpContextAccessor();

// Create the Bot Framework Authentication to be used with the Bot Adapter.
builder.Services.AddSingleton<BotFrameworkAuthentication, ConfigurationBotFrameworkAuthentication>();

// Create the Cloud Adapter with error handling enabled.
// Note: some classes expect a BotAdapter and some expect a BotFrameworkHttpAdapter, so
// register the same adapter instance for both types.
builder.Services.AddSingleton<CloudAdapter, AdapterWithErrorHandler>();
builder.Services.AddSingleton<IBotFrameworkHttpAdapter>(sp => sp.GetRequiredService<CloudAdapter>());
builder.Services.AddSingleton<BotAdapter>(sp => sp.GetRequiredService<CloudAdapter>());

// Create command handlers and the Conversation with command-response feature enabled.
builder.Services.AddSingleton<EchoCommandHandler>();
builder.Services.AddSingleton<ForityCommandHandler>();
builder.Services.AddSingleton(sp =>
{
    ConversationOptions options = new()
    {
        Adapter = sp.GetService<CloudAdapter>(),
        Command = new CommandOptions()
        {
            Commands = new List<ITeamsCommandHandler>
            {
                sp.GetRequiredService<EchoCommandHandler>(),
                sp.GetRequiredService<ForityCommandHandler>(),
            },
        },
    };

    return new ConversationBot(options);
});

// Create the bot as a transient. In this case the ASP Controller is expecting an IBot.
builder.Services.AddTransient<IBot, TeamsBot>();

builder.Services.AddSingleton<ArtificialIntelligenceService>();
builder.Services.ConfigureSettings<ArtificialIntelligenceServiceSettings>(builder.Configuration);

builder.Services.AddGlobalAdministration(builder.Configuration);
builder.Services.AddAccount(builder.Configuration);
builder.Services.AddUser(builder.Configuration);
builder.Services.AddConversation(builder.Configuration);

WebApplication app = builder.Build();

app.UseHexalith();
app.UseStaticFiles();

Log.Logger.Information("Starting {AppName}.", appName);

try
{
    await app.RunAsync().ConfigureAwait(false);
}
catch (Exception ex)
{
    Log.Logger.Fatal(ex, "Error starting {AppName}.", appName);
    throw;
}
finally
{
    Log.Logger.Information("{AppName}, is stopped.", appName);
}