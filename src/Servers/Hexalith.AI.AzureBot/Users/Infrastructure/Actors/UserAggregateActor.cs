// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 04-25-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 05-02-2023
// ***********************************************************************
// <copyright file="UserActor.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.Users.Infrastructure.Actors;

using Dapr.Actors.Runtime;

using Hexalith.AI.AzureBot.Users.Domain;
using Hexalith.AI.AzureBot.Users.Domain.Events;
using Hexalith.AI.AzureBot.Users.Infrastructure.Configuration;
using Hexalith.Application.Aggregates;
using Hexalith.Application.Tasks;
using Hexalith.Infrastructure.DaprRuntime.Handlers;
using Hexalith.Infrastructure.DaprRuntime.States;

using Microsoft.Extensions.Options;

/// <summary>
/// Class UserActor.
/// Implements the <see cref="Actor" />
/// Implements the <see cref="IUserAggretageActor" />
/// Implements the <see cref="ICommandProcessorActor" />
/// Implements the <see cref="IRemindable" />.
/// </summary>
/// <seealso cref="Actor" />
/// <seealso cref="IUserAggretageActor" />
/// <seealso cref="ICommandProcessorActor" />
/// <seealso cref="IRemindable" />
public class UserAggregateActor : Actor, IUserAggretageActor, ICommandProcessorActor, IRemindable
{
    /// <summary>
    /// The settings.
    /// </summary>
    private readonly UserSettings _settings;

    /// <summary>
    /// The state manager.
    /// </summary>
    private readonly IAggregateStateManager _stateManager;

    /// <summary>
    /// The state provider.
    /// </summary>
    private readonly ActorStateStoreProvider _stateProvider;

    /// <summary>
    /// The aggregate.
    /// </summary>
    private User? _aggregate;

    /// <summary>
    /// Initializes a new instance of the <see cref="UserAggregateActor" /> class.
    /// </summary>
    /// <param name="host">The host.</param>
    /// <param name="settings">The settings.</param>
    /// <param name="stateManager">The state manager.</param>
    /// <exception cref="System.ArgumentNullException"></exception>
    public UserAggregateActor(
     ActorHost host,
     IOptions<UserSettings> settings,
     IAggregateStateManager stateManager)
     : base(host)
    {
        ArgumentNullException.ThrowIfNull(host);
        ArgumentNullException.ThrowIfNull(stateManager);
        ArgumentNullException.ThrowIfNull(settings?.Value);
        _stateManager = stateManager;
        _stateProvider = new ActorStateStoreProvider(StateManager);
        _settings = settings.Value;
    }

    /// <summary>
    /// Administrators the count asynchronous.
    /// </summary>
    /// <returns>Task&lt;System.Int32&gt;.</returns>
    /// <exception cref="System.NotImplementedException"></exception>
    public Task<int> AdministratorCountAsync() => throw new NotImplementedException();

    /// <inheritdoc/>
    public async Task DoAsync(ActorCommandEnvelope envelope)
    {
        ArgumentNullException.ThrowIfNull(envelope);
        await _stateManager
            .AddCommandAsync(
                _stateProvider,
                envelope.Commands.ToArray(),
                envelope.Metadatas.ToArray(),
                RegisterReminderAsync,
                CancellationToken.None)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<string>> GetAccountRolesAsync(string account)
    {
        User? user = await GetAggregateAsync(CancellationToken.None).ConfigureAwait(false);
        if (user is null)
        {
            return Array.Empty<string>();
        }

        UserAccount? userAccount = user.Accounts.Where(p => p.Name == account).SingleOrDefault();
        return userAccount is null ? Array.Empty<string>() : userAccount.Roles;
    }

    /// <inheritdoc/>
    public async Task<bool> HasCommandsAsync()
    {
        return await _stateManager
            .GetCommandCountAsync(_stateProvider, CancellationToken.None)
            .ConfigureAwait(false) > 0L;
    }

    /// <inheritdoc/>
    public Task<bool> IsRegisteredAsync() => throw new NotImplementedException();

    /// <inheritdoc/>
    public async Task ReceiveReminderAsync(string reminderName, byte[] state, TimeSpan dueTime, TimeSpan period)
    {
        _ = await _stateManager
            .ContinueAsync(
                _stateProvider,
                _settings.ExecuteCommandResiliencyPolicy ?? ResiliencyPolicy.CreateEternalExponentialRetry(),
                _aggregate,
                (e) => new User((UserRegistered)e),
                RegisterReminderAsync,
                UnregisterReminderAsync,
                CancellationToken.None)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Get aggregate as an asynchronous operation.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>A Task&lt;User&gt; representing the asynchronous operation.</returns>
    private async Task<User?> GetAggregateAsync(CancellationToken cancellationToken)
    {
        return _aggregate
            ??= (User?)await _stateManager
            .GetAggregateAsync(
                _stateProvider,
                (e) => new User((UserRegistered)e),
                cancellationToken)
            .ConfigureAwait(false);
    }
}