// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 04-29-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 05-02-2023
// ***********************************************************************
// <copyright file="TeamsBot.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.Bot.Infrastructure;

using Hexalith.AI.AzureBot.GlobalAdministrations.Application.Services;
using Hexalith.AI.AzureBot.SemanticKernel.Services;
using Hexalith.AI.AzureBot.Users.Application.Services;

using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Teams;
using Microsoft.Bot.Schema;
using Microsoft.SemanticKernel.AI.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.AI.OpenAI.ChatCompletion;

/// <summary>
/// An empty bot handler.
/// You can add your customization code here to extend your bot logic if needed.
/// </summary>
public class TeamsBot : TeamsActivityHandler
{
    /// <summary>
    /// The administration service.
    /// </summary>
    private readonly IGlobalAdministrationQueryService _administrationService;

    /// <summary>
    /// The artificial intelligence service.
    /// </summary>
    private readonly ArtificialIntelligenceService _artificialIntelligenceService;

    /// <summary>
    /// The user service.
    /// </summary>
    private readonly IUserQueryService _userService;

    /// <summary>
    /// Initializes a new instance of the <see cref="TeamsBot" /> class.
    /// </summary>
    /// <param name="artificialIntelligenceService">The artificial intelligence service.</param>
    /// <param name="administrationService">The administration service.</param>
    /// <param name="userService">The user service.</param>
    /// <exception cref="System.ArgumentNullException"></exception>
    public TeamsBot(
        ArtificialIntelligenceService artificialIntelligenceService,
        IGlobalAdministrationQueryService administrationService,
        IUserQueryService userService)
    {
        ArgumentNullException.ThrowIfNull(artificialIntelligenceService);
        _artificialIntelligenceService = artificialIntelligenceService;
        _administrationService = administrationService;
        _userService = userService;
    }

    /// <inheritdoc/>
    public override Task OnTurnAsync(ITurnContext turnContext, CancellationToken cancellationToken = default)
        => base.OnTurnAsync(turnContext, cancellationToken);

    /// <inheritdoc/>
    protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(turnContext);
        await base.OnMessageActivityAsync(turnContext, cancellationToken).ConfigureAwait(false);
        if (turnContext.Responded)
        {
            return;
        }

        if (await _userService.IsRegisteredAsync(string.Empty, cancellationToken).ConfigureAwait(false))
        {
        }

        // Read adaptive card template
        IChatCompletion chat = _artificialIntelligenceService.Kernel.GetService<IChatCompletion>("GPT");
        OpenAIChatHistory conversation = (OpenAIChatHistory)chat.CreateNewChat("The following is a conversation with Fority, the Fiveforty company AI assistant. The assistant is helpful, creative, clever, very friendly and a Microsoft Dynamics 365 for finance and operations ERP expert. The assistant thinks step by step.");
        conversation.AddUserMessage(turnContext.Activity.Text);
        string reply = await chat.GenerateMessageAsync(conversation, new ChatRequestSettings(), cancellationToken).ConfigureAwait(false);

        // Sends an activity to the sender of the incoming activity.
        _ = await turnContext
            .SendActivityAsync(MessageFactory.Text(reply), cancellationToken)
            .ConfigureAwait(false);
    }
}