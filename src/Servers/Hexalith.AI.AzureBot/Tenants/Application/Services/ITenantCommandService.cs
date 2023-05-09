// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 05-01-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 05-02-2023
// ***********************************************************************
// <copyright file="ITenantCommandService.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.Tenants.Application.Services;

using Hexalith.AI.AzureBot.Tenants.Application.Commands;
using Hexalith.Application.Abstractions.Metadatas;

/// <summary>
/// Interface ITenantCommandService.
/// </summary>
public interface ITenantCommandService
{
    /// <summary>
    /// Registers the tenant asynchronous.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <param name="domain">The domain.</param>
    /// <param name="id">The identifier.</param>
    /// <param name="messageId">The message identifier.</param>
    /// <param name="correlationId">The correlation identifier.</param>
    /// <param name="userId">The user identifier.</param>
    /// <param name="sessionId">The session identifier.</param>
    /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>System.Threading.Tasks.Task.</returns>
    Task RegisterTenantAsync(
            string name,
            string domain,
            string id,
            string messageId,
            string correlationId,
            string userId,
            string sessionId,
            CancellationToken cancellationToken);

    /// <summary>
    /// Registers the tenant asynchronous.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="metadata">The metadata.</param>
    /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>System.Threading.Tasks.Task.</returns>
    Task RegisterTenantAsync(
      RegisterTenant message,
      Metadata metadata,
      CancellationToken cancellationToken);
}