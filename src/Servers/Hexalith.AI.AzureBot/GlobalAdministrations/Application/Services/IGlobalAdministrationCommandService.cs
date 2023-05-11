// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 05-01-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 05-11-2023
// ***********************************************************************
// <copyright file="IGlobalAdministrationCommandService.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.GlobalAdministrations.Application.Services;

using Hexalith.AI.AzureBot.GlobalAdministrations.Application.Commands;
using Hexalith.Application.Abstractions.Metadatas;

/// <summary>
/// Interface IGlobalAdministrationCommandService.
/// </summary>
public interface IGlobalAdministrationCommandService
{
    /// <summary>
    /// Does the asynchronous.
    /// </summary>
    /// <param name="command">The command.</param>
    /// <param name="metadata">The metadata.</param>
    /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Task.</returns>
    Task DoAsync(RegisterGlobalAdministrator command, Metadata metadata, CancellationToken cancellationToken);

    /// <summary>
    /// Registers the global administrator asynchronous.
    /// </summary>
    /// <param name="email">The email.</param>
    /// <param name="userId">The user identifier.</param>
    /// <param name="messageId">The message identifier.</param>
    /// <param name="correlationId">The correlation identifier.</param>
    /// <param name="sessionId">The session identifier.</param>
    /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Task.</returns>
    Task RegisterGlobalAdministratorAsync(
        string email,
        string userId,
        string messageId,
        string correlationId,
        string sessionId,
        CancellationToken cancellationToken);

    /// <summary>
    /// Registers the global administrator asynchronous.
    /// </summary>
    /// <param name="email">The email.</param>
    /// <param name="userId">The user identifier.</param>
    /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Task.</returns>
    Task RegisterGlobalAdministratorAsync(
        string email,
        string userId,
        CancellationToken cancellationToken);
}