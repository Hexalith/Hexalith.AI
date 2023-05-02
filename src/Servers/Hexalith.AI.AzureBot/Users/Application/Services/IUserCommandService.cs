// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 05-01-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 05-01-2023
// ***********************************************************************
// <copyright file="IUserCommandService.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.Users.Application.Services;

/// <summary>
/// Interface IUserCommandService.
/// </summary>
public interface IUserCommandService
{
    /// <summary>
    /// Registers the asynchronous.
    /// </summary>
    /// <param name="email">The email.</param>
    /// <param name="name">The name.</param>
    /// <param name="userId">The user identifier.</param>
    /// <param name="messageId">The message identifier.</param>
    /// <param name="correlationId">The correlation identifier.</param>
    /// <param name="sessionId">The session identifier.</param>
    /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Task.</returns>
    Task RegisterAsync(
        string email,
        string name,
        string userId,
        string messageId,
        string correlationId,
        string sessionId,
        CancellationToken cancellationToken);
}