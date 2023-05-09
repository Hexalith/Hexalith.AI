// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 05-01-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 05-02-2023
// ***********************************************************************
// <copyright file="ITenantQueryService.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.Tenants.Application.Services;

using Hexalith.AI.AzureBot.Tenants.Application.Models;

/// <summary>
/// Interface ITenantQueryService.
/// </summary>
public interface ITenantQueryService
{
    /// <summary>
    /// Check if tenant exists.
    /// </summary>
    /// <param name="id">The tenant identifier.</param>
    /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Task&lt;System.Boolean&gt;.</returns>
    Task<bool> ExistsAsync(string id, CancellationToken cancellationToken);

    /// <summary>
    /// Gets the tenant user.
    /// </summary>
    /// <param name="id">The tenant identifier.</param>
    /// <param name="objectId">The object identifier.</param>
    /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Task&lt;TenantUserInformation&gt;.</returns>
    Task<TenantUserInformation> GetTenantUserAsync(string id, string objectId, CancellationToken cancellationToken);

    /// <summary>
    /// Check if user exists in tenant.
    /// </summary>
    /// <param name="id">The tenant identifier.</param>
    /// <param name="objectId">The object identifier.</param>
    /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Task&lt;System.Boolean&gt;.</returns>
    Task<bool> UserExistsInTenantAsync(string id, string objectId, CancellationToken cancellationToken);
}