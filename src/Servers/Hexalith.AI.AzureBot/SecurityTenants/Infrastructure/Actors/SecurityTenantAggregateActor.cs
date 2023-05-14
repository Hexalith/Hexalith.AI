// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 04-25-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 04-25-2023
// ***********************************************************************
// <copyright file="TenantAggregateActor.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.SecurityTenants.Infrastructure.Actors;

using System.Threading.Tasks;

using Dapr.Actors.Runtime;

using Hexalith.AI.AzureBot.SecurityTenants.Application.Models;

/// <summary>
/// Class TenantAggregateActor.
/// Implements the <see cref="Actor" />
/// Implements the <see cref="ITenantAggregateActor" />.
/// </summary>
/// <seealso cref="Actor" />
/// <seealso cref="ITenantAggregateActor" />
public class SecurityTenantAggregateActor : Actor, ISecurityTenantAggregateActor
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SecurityTenantAggregateActor"/> class.
    /// </summary>
    /// <param name="host">The <see cref="T:Dapr.Actors.Runtime.ActorHost" /> that will host this actor instance.</param>
    public SecurityTenantAggregateActor(ActorHost host)
        : base(host)
    {
    }

    /// <inheritdoc/>
    public Task<SecurityTenantUserInformation> GetTenantUserAsync(string objectId) => throw new NotImplementedException();

    public Task<bool> IsRegisteredAsync() => throw new NotImplementedException();

    /// <inheritdoc/>
    public Task<bool> UserExistsInTenantAsync(string objectId) => throw new NotImplementedException();
}