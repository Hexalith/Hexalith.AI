// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 05-01-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 05-02-2023
// ***********************************************************************
// <copyright file="IConversationCommandService.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.Conversations.Application.Services;

/// <summary>
/// Interface IConversationCommandService.
/// </summary>
public interface IConversationCommandService
{
    /// <summary>
    /// Starts the conversation asynchronous.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="email">The email.</param>
    /// <param name="account">The account.</param>
    /// <param name="text">The text.</param>
    /// <param name="startedDate">The started date.</param>
    /// <param name="messageId">The message identifier.</param>
    /// <param name="correlationId">The correlation identifier.</param>
    /// <param name="sessionId">The session identifier.</param>
    /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>System.Threading.Tasks.Task.</returns>
    Task StartConversationAsync(
            string id,
            string email,
            string account,
            string text,
            DateTimeOffset startedDate,
            string messageId,
            string correlationId,
            string sessionId,
            CancellationToken cancellationToken);
}