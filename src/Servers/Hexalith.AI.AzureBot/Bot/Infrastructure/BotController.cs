﻿// ***********************************************************************
// Assembly         : Hexalith.AI.Teams.Bot
// Author           : Jérôme Piquot
// Created          : 04-19-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 04-19-2023
// ***********************************************************************
// <copyright file="BotController.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Hexalith.AI.AzureBot.Bot.Infrastructure;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Integration.AspNet.Core;
using Microsoft.TeamsFx.Conversation;

/// <summary>
/// Class BotController.
/// Implements the <see cref="ControllerBase" />.
/// </summary>
/// <seealso cref="ControllerBase" />
[Route("api/messages")]
[ApiController]
public class BotController : ControllerBase
{
    /// <summary>
    /// The bot.
    /// </summary>
    private readonly IBot _bot;

    /// <summary>
    /// The conversation.
    /// </summary>
    private readonly ConversationBot _conversation;

    /// <summary>
    /// Initializes a new instance of the <see cref="BotController"/> class.
    /// </summary>
    /// <param name="conversation">The conversation.</param>
    /// <param name="bot">The bot.</param>
    public BotController(ConversationBot conversation, IBot bot)
    {
        _conversation = conversation;
        _bot = bot;
    }

    /// <summary>
    /// Post as an asynchronous operation.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A Task representing the asynchronous operation.</returns>
    [HttpPost]
    public async Task PostAsync(CancellationToken cancellationToken = default)
    {
        CloudAdapter adapter = _conversation.Adapter as CloudAdapter
            ?? throw new InvalidOperationException("The adapter is not a CloudAdapter");

        await adapter
            .ProcessAsync(
                Request,
                Response,
                _bot,
                cancellationToken)
            .ConfigureAwait(false);
    }
}