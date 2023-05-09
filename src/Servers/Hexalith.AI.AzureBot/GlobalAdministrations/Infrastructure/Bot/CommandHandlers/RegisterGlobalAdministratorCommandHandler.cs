// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 04-29-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 04-29-2023
// ***********************************************************************
// <copyright file="EchoCommandHandler.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.Bot.Application.Commands;

using AdaptiveCards.Templating;

using Hexalith.AI.AzureBot.Bot.Application.Models;

using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using Microsoft.TeamsFx.Conversation;

using Newtonsoft.Json;

/// <summary>
/// The <see cref="RegisterGlobalAdministratorCommandHandler" /> registers a pattern with the <see cref="ITeamsCommandHandler" /> and
/// responds with an Adaptive Card if the user types the <see cref="TriggerPatterns" />.
/// </summary>
public partial class RegisterGlobalAdministratorCommandHandler : ITeamsCommandHandler
{
    /// <summary>
    /// The adaptive card file path.
    /// </summary>
    private readonly string _card = $$"""
        {
        	"type": "AdaptiveCard",
        	"body": [
        		{
        			"type": "TextBlock",
        			"size": "Medium",
        			"weight": "Bolder",
        			"text": "${title}"
        		},
        		{
        			"type": "TextBlock",
        			"text": "${body}",
        			"wrap": true
        		}
        	],
        	"$schema": "http://adaptivecards.io/schemas/adaptive-card.json",
        	"version": "1.4"
        }
        """;

    /// <summary>
    /// The logger.
    /// </summary>
    private readonly ILogger _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="RegisterGlobalAdministratorCommandHandler" /> class.
    /// </summary>
    /// <param name="logger">The logger.</param>
    public RegisterGlobalAdministratorCommandHandler(ILogger<RegisterGlobalAdministratorCommandHandler> logger) => _logger = logger;

    /// <inheritdoc/>
    public IEnumerable<ITriggerPattern> TriggerPatterns => new List<ITriggerPattern>
    {
        // Used to trigger the command handler if the command text contains 'Register global administrator'
        new RegExpTrigger("Register global administrator"),
    };

    [LoggerMessage(
    EventId = 1,
    Level = LogLevel.Information,
    Message = "Received command ({matches}): {commandText}")]
    public static partial void CommandReceived(ILogger logger, string? commandText, string? matches);

    /// <inheritdoc/>
    public Task<ICommandResponse> HandleCommandAsync(ITurnContext turnContext, CommandMessage message, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(message?.Text))
        {
            return Task.FromResult<ICommandResponse>(new ActivityCommandResponse(MessageFactory.Text("Please enter a message.")));
        }

        CommandReceived(_logger, message.Text, string.Join(", ", message.Matches));

        // Render adaptive card content
        string cardContent = new AdaptiveCardTemplate(_card).Expand(
            new EchoModel
            {
                Title = "Echo, the Fiveforty AI Assistant",
                Body = $"Hello.\n{message.Text}",
            });

        // Build attachment
        IMessageActivity activity = MessageFactory.Attachment(
            new Attachment
            {
                ContentType = "application/vnd.microsoft.card.adaptive",
                Content = JsonConvert.DeserializeObject(cardContent),
            });

        // send response
        return Task.FromResult<ICommandResponse>(new ActivityCommandResponse(activity));
    }
}