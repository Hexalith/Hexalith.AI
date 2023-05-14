// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 05-02-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 05-02-2023
// ***********************************************************************
// <copyright file="SecurityTenantQueryService.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.SecurityTenants.Infrastructure.Services;

using System.Threading.Tasks;

using Dapr.Actors;
using Dapr.Actors.Client;

using Hexalith.AI.AzureBot.SecurityTenants.Application.Models;
using Hexalith.AI.AzureBot.SecurityTenants.Application.Services;
using Hexalith.AI.AzureBot.SecurityTenants.Infrastructure.Actors;

/// <summary>
/// Class SecurityTenantQueryService.
/// Implements the <see cref="ISecurityTenantQueryService" />.
/// </summary>
/// <seealso cref="ISecurityTenantQueryService" />
public class SecurityTenantQueryService : ISecurityTenantQueryService
{
    /// <inheritdoc/>
    public async Task<bool> ExistsAsync(string id, CancellationToken cancellationToken)
        => await GetSecurityTenantActor(id)
            .IsRegisteredAsync()
            .ConfigureAwait(false);

    /// <inheritdoc/>
    public async Task<SecurityTenantUserInformation> GetSecurityTenantUserAsync(string id, string objectId, CancellationToken cancellationToken)
        => await GetSecurityTenantActor(id)
            .GetTenantUserAsync(objectId)
            .ConfigureAwait(false);

    /// <inheritdoc/>
    public async Task<bool> UserExistsInSecurityTenantAsync(string id, string objectId, CancellationToken cancellationToken)
        => await GetSecurityTenantActor(id)
            .UserExistsInTenantAsync(objectId)
            .ConfigureAwait(false);

    /// <summary>
    /// Gets the conversation actor.
    /// </summary>
    /// <param name="email">The email.</param>
    /// <returns>ISecurityTenantActor.</returns>
    private static ISecurityTenantAggregateActor GetSecurityTenantActor(string email)
        => ActorProxy.Create<ISecurityTenantAggregateActor>(
            new ActorId(email),
            nameof(SecurityTenantAggregateActor));
}