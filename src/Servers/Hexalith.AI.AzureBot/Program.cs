// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 04-19-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 05-22-2023
// ***********************************************************************
// <copyright file="Program.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Hexalith.AI.AzureBot.Accounts.Infrastructure.Helpers;
using Hexalith.AI.AzureBot.ApplicationAdministrations.Infrastructure.Helpers;
using Hexalith.AI.AzureBot.Conversations.Infrastructure.Helpers;
using Hexalith.AI.AzureBot.Users.Infrastructure.Helpers;
using Hexalith.Infrastructure.TeamsBot.Helpers;
using Hexalith.Infrastructure.WebApis.Helpers;

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
            .AddApplicationAdministration()
            .AddConversation()
            .AddUser()
            .AddAccount(),
    args);

// Add the Hexalith Semantic Bot.
builder.Services.AddSemanticBot(builder.Configuration);

builder.Services.AddApplicationAdministration(builder.Configuration);
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