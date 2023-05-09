// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 05-02-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 05-02-2023
// ***********************************************************************
// <copyright file="TenantQueryService.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.Tenants.Infrastructure.Services;

using System.Threading.Tasks;

using Dapr.Actors;
using Dapr.Actors.Client;

using Hexalith.AI.AzureBot.Tenants.Application.Models;
using Hexalith.AI.AzureBot.Tenants.Application.Services;
using Hexalith.AI.AzureBot.Tenants.Infrastructure.Actors;

/// <summary>
/// Class TenantQueryService.
/// Implements the <see cref="ITenantQueryService" />.
/// </summary>
/// <seealso cref="ITenantQueryService" />
public class TenantQueryService : ITenantQueryService
{
    /// <inheritdoc/>
    public async Task<bool> ExistsAsync(string id, CancellationToken cancellationToken)
        => await GetTenantActor(id)
            .ExistsAsync()
            .ConfigureAwait(false);

    /// <inheritdoc/>
    public async Task<TenantUserInformation> GetTenantUserAsync(string id, string objectId, CancellationToken cancellationToken)
        => await GetTenantActor(id)
            .GetTenantUserAsync(objectId)
            .ConfigureAwait(false);

    /// <inheritdoc/>
    public async Task<bool> UserExistsInTenantAsync(string id, string objectId, CancellationToken cancellationToken)
        => await GetTenantActor(id)
            .UserExistsInTenantAsync(objectId)
            .ConfigureAwait(false);

    /// <summary>
    /// Gets the conversation actor.
    /// </summary>
    /// <param name="email">The email.</param>
    /// <returns>ITenantActor.</returns>
    private static ITenantAggregateActor GetTenantActor(string email)
        => ActorProxy.Create<ITenantAggregateActor>(
            new ActorId(email),
            nameof(TenantAggregateActor));
}