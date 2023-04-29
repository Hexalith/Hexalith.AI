// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 04-25-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 04-25-2023
// ***********************************************************************
// <copyright file="GlobalAdministrationService.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.GlobalAdministrations.Infrastructure.Services;

using System.Threading;
using System.Threading.Tasks;

using Dapr.Actors;
using Dapr.Actors.Client;

using Hexalith.AI.AzureBot.GlobalAdministrations.Application;
using Hexalith.AI.AzureBot.GlobalAdministrations.Domain;
using Hexalith.AI.AzureBot.GlobalAdministrations.Infrastructure.Actors;

/// <summary>
/// Class GlobalAdministrationService.
/// Implements the <see cref="IGlobalAdministrationService" />.
/// </summary>
/// <seealso cref="IGlobalAdministrationService" />
public class GlobalAdministrationService : IGlobalAdministrationService
{
    /// <inheritdoc/>
    public async Task<bool> IsAdministratorAsync(string email, CancellationToken cancellationToken)
        => await GetActor().IsAdministratorAsync(email).ConfigureAwait(false);

    /// <inheritdoc/>
    public async Task<bool> IsRegisteredAsync(string email, CancellationToken cancellationToken)
        => await GetActor().IsRegisteredAsync(email).ConfigureAwait(false);

    /// <summary>
    /// Gets the actor.
    /// </summary>
    /// <returns>IGlobalAdministrationActor.</returns>
    private IGlobalAdministrationActor GetActor()
        => ActorProxy.Create<IGlobalAdministrationActor>(new ActorId(nameof(GlobalAdministration)), nameof(GlobalAdministration));
}