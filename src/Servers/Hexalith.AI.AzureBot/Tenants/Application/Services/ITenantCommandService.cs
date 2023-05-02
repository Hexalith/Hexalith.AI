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
namespace Hexalith.AI.AzureBot.Tenants.Application.Services;

/// <summary>
/// Interface ITenantCommandService.
/// </summary>
public interface ITenantCommandService
{
    /// <summary>
    /// Adds the user role asynchronous.
    /// </summary>
    /// <param name="account">The account.</param>
    /// <param name="email">The email.</param>
    /// <param name="role">The role.</param>
    /// <param name="messageId">The message identifier.</param>
    /// <param name="correlationId">The correlation identifier.</param>
    /// <param name="sessionId">The session identifier.</param>
    /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Task.</returns>
    Task AddUserRoleAsync(
            string account,
            string email,
            string role,
            string messageId,
            string correlationId,
            string sessionId,
            CancellationToken cancellationToken);
}