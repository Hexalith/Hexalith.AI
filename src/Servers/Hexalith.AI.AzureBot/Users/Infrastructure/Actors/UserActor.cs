// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 04-25-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 04-25-2023
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
using Hexalith.Application.Abstractions.Aggregates;
using Hexalith.Application.Abstractions.Tasks;
using Hexalith.Infrastructure.DaprRuntime.Handlers;
using Hexalith.Infrastructure.DaprRuntime.States;

using Microsoft.Extensions.Options;

/// <summary>
/// Class UserActor.
/// Implements the <see cref="Actor" />
/// Implements the <see cref="IUserActor" />
/// Implements the <see cref="ICommandProcessorActor" />
/// Implements the <see cref="IRemindable" />.
/// </summary>
/// <seealso cref="Actor" />
/// <seealso cref="IUserActor" />
/// <seealso cref="ICommandProcessorActor" />
/// <seealso cref="IRemindable" />
public class UserActor : Actor, IUserActor, ICommandProcessorActor, IRemindable
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

    private User? _aggregate;

    /// <summary>
    /// Initializes a new instance of the <see cref="UserActor"/> class.
    /// </summary>
    /// <param name="host">The host.</param>
    /// <param name="settings">The settings.</param>
    /// <param name="stateManager">The state manager.</param>
    /// <exception cref="ArgumentNullException"></exception>
    public UserActor(
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
    public async Task<IEnumerable<string>> GetAccountRoles(string account)
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

    public Task<bool> IsAdministratorAsync(string email) => throw new NotImplementedException();

    /// <inheritdoc/>
    public async Task<bool> IsGlobalAdministratorAsync()
        => (await GetAggregateAsync(CancellationToken.None)
            .ConfigureAwait(false))?.IsGlobalAdministrator == true;

    public Task<bool> IsRegisteredAsync(string email) => throw new NotImplementedException();

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