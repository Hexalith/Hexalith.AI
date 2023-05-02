// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 05-01-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 05-01-2023
// ***********************************************************************
// <copyright file="GlobalAdministrationQueryService.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Hexalith.AI.AzureBot.GlobalAdministrations.Infrastructure.Services;

using Dapr.Actors;
using Dapr.Actors.Client;

using Hexalith.AI.AzureBot.GlobalAdministrations.Application.Services;
using Hexalith.AI.AzureBot.GlobalAdministrations.Domain;
using Hexalith.AI.AzureBot.GlobalAdministrations.Infrastructure.Actors;

/// <summary>
/// Class GlobalAdministrationQueryService.
/// Implements the <see cref="IGlobalAdministrationQueryService" />.
/// </summary>
/// <seealso cref="IGlobalAdministrationQueryService" />
public class GlobalAdministrationQueryService : IGlobalAdministrationQueryService
{
    /// <summary>
    /// The global administration actor.
    /// </summary>
    private IGlobalAdministrationActor? _globalAdministrationActor;

    /// <summary>
    /// Gets the global administration actor.
    /// </summary>
    /// <value>The global administration actor.</value>
    private IGlobalAdministrationActor GlobalAdministrationActor
                => _globalAdministrationActor
            ??= ActorProxy.Create<IGlobalAdministrationActor>(
                new ActorId(nameof(GlobalAdministration)),
                nameof(GlobalAdministrationActor));

    /// <summary>
    /// Is administrator as an asynchronous operation.
    /// </summary>
    /// <param name="email">The email.</param>
    /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A Task&lt;System.Boolean&gt; representing the asynchronous operation.</returns>
    public async Task<bool> IsAdministratorAsync(string email, CancellationToken cancellationToken)
                => await GlobalAdministrationActor
                .IsAdministratorAsync(email)
                .ConfigureAwait(false);
}