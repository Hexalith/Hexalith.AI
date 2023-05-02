// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 05-02-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 05-02-2023
// ***********************************************************************
// <copyright file="ConversationQueryService.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.Conversations.Infrastructure.Services;

using System.Threading.Tasks;

using Dapr.Actors;
using Dapr.Actors.Client;

using Hexalith.AI.AzureBot.Conversations.Application.Services;
using Hexalith.AI.AzureBot.Conversations.Infrastructure.Actors;

/// <summary>
/// Class ConversationQueryService.
/// Implements the <see cref="IConversationQueryService" />.
/// </summary>
/// <seealso cref="IConversationQueryService" />
public class ConversationQueryService : IConversationQueryService
{
    /// <inheritdoc/>
    public async Task<string> GetConversationTextAsync(string id, CancellationToken cancellationToken)
        => await GetConversationActor(id).GetConversationTextAsync().ConfigureAwait(false);

    /// <summary>
    /// Gets the conversation actor.
    /// </summary>
    /// <param name="email">The email.</param>
    /// <returns>IConversationActor.</returns>
    private IConversationActor GetConversationActor(string email) => ActorProxy.Create<IConversationActor>(new ActorId(email), nameof(ConversationActor));
}