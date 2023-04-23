// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 04-22-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 04-23-2023
// ***********************************************************************
// <copyright file="ForityCommandHandler.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.Commands;

using AdaptiveCards.Templating;

using Hexalith.AI.AzureBot.Infrastructure.SemanticKernel.Services;
using Hexalith.AI.AzureBot.Models;

using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using Microsoft.SemanticKernel.AI.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.AI.OpenAI.ChatCompletion;
using Microsoft.TeamsFx.Conversation;

using Newtonsoft.Json;

/// <summary>
/// The <see cref="ForityCommandHandler" /> registers a pattern with the <see cref="ITeamsCommandHandler" /> and
/// responds with an Adaptive Card if the user types the <see cref="TriggerPatterns" />.
/// </summary>
public class ForityCommandHandler : ITeamsCommandHandler
{
    /// <summary>
    /// The adaptive card file path.
    /// </summary>
    private readonly string _adaptiveCardFilePath = Path.Combine(".", "Resources", "ForityCard.json");

    /// <summary>
    /// The ai service.
    /// </summary>
    private readonly ArtificialIntelligenceService _aiService;

    /// <summary>
    /// The logger.
    /// </summary>
    private readonly ILogger<ForityCommandHandler> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="ForityCommandHandler" /> class.
    /// </summary>
    /// <param name="aiService">The ai service.</param>
    /// <param name="logger">The logger.</param>
    public ForityCommandHandler(ArtificialIntelligenceService aiService, ILogger<ForityCommandHandler> logger)
    {
        _aiService = aiService;
        _logger = logger;
    }

    /// <inheritdoc/>
    public IEnumerable<ITriggerPattern> TriggerPatterns => new List<ITriggerPattern>
    {
        // Used to trigger the command handler if the command text contains 'Fority'
        new RegExpTrigger("fority"),
    };

    /// <inheritdoc/>
    public async Task<ICommandResponse> HandleCommandAsync(ITurnContext turnContext, CommandMessage message, CancellationToken cancellationToken = default)
    {
        _logger?.LogInformation($"App received message: {message.Text}");

        // Read adaptive card template
        string cardTemplate = await File.ReadAllTextAsync(_adaptiveCardFilePath, cancellationToken).ConfigureAwait(false);
        IChatCompletion chat = _aiService.Kernel.GetService<IChatCompletion>("GPT");
        OpenAIChatHistory conversation = (OpenAIChatHistory)chat.CreateNewChat("The following is a conversation with Fority, the Fiveforty company AI assistant. The assistant is helpful, creative, clever, very friendly and a Microsoft Dynamics 365 for finance and operations ERP expert. The assistant thinks step by step.");
        conversation.AddUserMessage(message.Text);
        string reply = await chat.GenerateMessageAsync(conversation, new ChatRequestSettings(), cancellationToken).ConfigureAwait(false);

        // Render adaptive card content
        string cardContent = new AdaptiveCardTemplate(cardTemplate).Expand(
            new ForityModel
            {
                Title = "Fority AI service",
                Body = reply,
            });

        // Build attachment
        IMessageActivity activity = MessageFactory.Attachment(
            new Attachment
            {
                ContentType = "application/vnd.microsoft.card.adaptive",
                Content = JsonConvert.DeserializeObject(cardContent),
            });

        // send response
        return new ActivityCommandResponse(activity);
    }
}