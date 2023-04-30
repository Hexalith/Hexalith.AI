// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 04-29-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 04-29-2023
// ***********************************************************************
// <copyright file="AdapterWithErrorHandler.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.Bot.Infrastructure;

using Microsoft.Bot.Builder.Integration.AspNet.Core;
using Microsoft.Bot.Builder.TraceExtensions;
using Microsoft.Bot.Connector.Authentication;

/// <summary>
/// Class AdapterWithErrorHandler.
/// Implements the <see cref="CloudAdapter" />.
/// </summary>
/// <seealso cref="CloudAdapter" />
public class AdapterWithErrorHandler : CloudAdapter
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AdapterWithErrorHandler"/> class.
    /// </summary>
    /// <param name="auth">The authentication.</param>
    /// <param name="logger">The logger.</param>
    public AdapterWithErrorHandler(BotFrameworkAuthentication auth, ILogger<CloudAdapter> logger)
        : base(auth, logger)
    {
        OnTurnError = async (turnContext, exception) =>
        {
            // Log any leaked exception from the application.
            // NOTE: In production environment, you should consider logging this to
            // Azure Application Insights. Visit https://aka.ms/bottelemetry to see how
            // to add telemetry capture to your bot.
            logger.LogError(exception, $"[OnTurnError] unhandled error : {exception.Message}");

            // Send a message to the user
            _ = await turnContext.SendActivityAsync($"The bot encountered an unhandled error: {exception.Message}").ConfigureAwait(false);
            _ = await turnContext.SendActivityAsync("To continue to run this bot, please fix the bot source code.").ConfigureAwait(false);

            // Send a trace activity
            _ = await turnContext.TraceActivityAsync("OnTurnError Trace", exception.Message, "https://www.botframework.com/schemas/error", "TurnError").ConfigureAwait(false);
        };
    }
}