// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 05-01-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 05-01-2023
// ***********************************************************************
// <copyright file="UserQueryService.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.Users.Application.Services;

using System.Threading.Tasks;

using Dapr.Actors;
using Dapr.Actors.Client;

using Hexalith.AI.AzureBot.Users.Infrastructure.Actors;

/// <summary>
/// Class UserQueryService.
/// Implements the <see cref="Hexalith.AI.AzureBot.Users.Application.Services.IUserQueryService" />.
/// </summary>
/// <seealso cref="Hexalith.AI.AzureBot.Users.Application.Services.IUserQueryService" />
public class UserQueryService : IUserQueryService
{
    /// <summary>
    /// Is registered as an asynchronous operation.
    /// </summary>
    /// <param name="email">The email.</param>
    /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A Task&lt;System.Boolean&gt; representing the asynchronous operation.</returns>
    public async Task<bool> IsRegisteredAsync(string email, CancellationToken cancellationToken)
        => await GetUserActor(email).IsRegisteredAsync().ConfigureAwait(false);

    /// <summary>
    /// Gets the user actor.
    /// </summary>
    /// <param name="email">The email.</param>
    /// <returns>IUserActor.</returns>
    private IUserActor GetUserActor(string email) => ActorProxy.Create<IUserActor>(new ActorId(email), nameof(UserActor));
}