// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 05-02-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 05-02-2023
// ***********************************************************************
// <copyright file="AccountQueryService.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.Accounts.Infrastructure.Services;

using System.Threading.Tasks;

using Dapr.Actors;
using Dapr.Actors.Client;

using Hexalith.AI.AzureBot.Accounts.Application.Services;

/// <summary>
/// Class AccountQueryService.
/// Implements the <see cref="IAccountQueryService" />.
/// </summary>
/// <seealso cref="IAccountQueryService" />
public class AccountQueryService : IAccountQueryService
{
    /// <inheritdoc/>
    public async Task<bool> IsAccountUserAsync(string account, string email, CancellationToken cancellationToken)
        => await GetAccountActor(account).IsAccountUserAsync().ConfigureAwait(false);

    /// <summary>
    /// Gets the conversation actor.
    /// </summary>
    /// <param name="email">The email.</param>
    /// <returns>IAccountActor.</returns>
    private static IAccountAggregateActor GetAccountActor(string email) => ActorProxy.Create<IAccountAggregateActor>(new ActorId(email), nameof(AccountAggregateActor));
}