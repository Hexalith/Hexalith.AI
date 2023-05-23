// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 05-01-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 05-01-2023
// ***********************************************************************
// <copyright file="ApplicationAdministrationQueryService.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Hexalith.AI.AzureBot.ApplicationAdministrations.Infrastructure.Services;

using Dapr.Actors;
using Dapr.Actors.Client;

using Hexalith.AI.AzureBot.ApplicationAdministrations.Application.Services;
using Hexalith.AI.AzureBot.ApplicationAdministrations.Domain;
using Hexalith.AI.AzureBot.ApplicationAdministrations.Infrastructure.Actors;

/// <summary>
/// Class ApplicationAdministrationQueryService.
/// Implements the <see cref="IApplicationAdministrationQueryService" />.
/// </summary>
/// <seealso cref="IApplicationAdministrationQueryService" />
public class ApplicationAdministrationQueryService : IApplicationAdministrationQueryService
{
    /// <summary>
    /// The global administration actor.
    /// </summary>
    private IApplicationAdministrationActor? _globalAdministrationActor;

    /// <summary>
    /// Gets the global administration actor.
    /// </summary>
    /// <value>The global administration actor.</value>
    private IApplicationAdministrationActor ApplicationAdministrationActor
                => _globalAdministrationActor
            ??= ActorProxy.Create<IApplicationAdministrationActor>(
                new ActorId(nameof(ApplicationAdministration)),
                nameof(ApplicationAdministrationActor));

    /// <summary>
    /// Is administrator as an asynchronous operation.
    /// </summary>
    /// <param name="email">The email.</param>
    /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A Task&lt;System.Boolean&gt; representing the asynchronous operation.</returns>
    public async Task<bool> IsAdministratorAsync(string email, CancellationToken cancellationToken)
                => await ApplicationAdministrationActor
                .IsAdministratorAsync(email)
                .ConfigureAwait(false);
}