// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 04-25-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 05-02-2023
// ***********************************************************************
// <copyright file="ITenantAggregateActor.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Hexalith.AI.AzureBot.Tenants.Infrastructure.Actors;

using System.Threading.Tasks;

using Dapr.Actors;

using Hexalith.AI.AzureBot.Tenants.Application.Models;

/// <summary>
/// Interface ITenantAggregateActor
/// Extends the <see cref="IActor" />.
/// </summary>
/// <seealso cref="IActor" />
public interface ITenantAggregateActor : IActor
{
    /// <summary>
    /// Exist.
    /// </summary>
    /// <returns>Task&lt;System.Boolean&gt;.</returns>
    Task<bool> ExistsAsync();

    /// <summary>
    /// Gets the tenant user asynchronous.
    /// </summary>
    /// <param name="objectId">The object identifier.</param>
    /// <returns>Task&lt;TenantUserInformation&gt;.</returns>
    Task<TenantUserInformation> GetTenantUserAsync(string objectId);

    /// <summary>
    /// Users the exists in tenant asynchronous.
    /// </summary>
    /// <param name="objectId">The object identifier.</param>
    /// <returns>Task&lt;System.Boolean&gt;.</returns>
    Task<bool> UserExistsInTenantAsync(string objectId);
}