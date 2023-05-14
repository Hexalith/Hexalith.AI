// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 04-25-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 04-25-2023
// ***********************************************************************
// <copyright file="ApplicationAdministrationActor.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.ApplicationAdministrations.Infrastructure.Actors;

using Dapr.Actors.Runtime;

using Hexalith.AI.AzureBot.ApplicationAdministrations.Domain;
using Hexalith.AI.AzureBot.ApplicationAdministrations.Domain.Events;
using Hexalith.Application.Aggregates;
using Hexalith.Application.Tasks;
using Hexalith.Infrastructure.DaprRuntime.Handlers;
using Hexalith.Infrastructure.DaprRuntime.States;

using Microsoft.Extensions.Options;

/// <summary>
/// Class ApplicationAdministrationActor.
/// Implements the <see cref="Actor" />
/// Implements the <see cref="IApplicationAdministrationActor" />
/// Implements the <see cref="ICommandProcessorActor" />
/// Implements the <see cref="IRemindable" />.
/// </summary>
/// <seealso cref="Actor" />
/// <seealso cref="IApplicationAdministrationActor" />
/// <seealso cref="ICommandProcessorActor" />
/// <seealso cref="IRemindable" />
public class ApplicationAdministrationActor : Actor, IApplicationAdministrationActor, ICommandProcessorActor, IRemindable
{
    /// <summary>
    /// The settings.
    /// </summary>
    private readonly ApplicationAdministrationSettings _settings;

    /// <summary>
    /// The state manager.
    /// </summary>
    private readonly IAggregateStateManager _stateManager;

    /// <summary>
    /// The state provider.
    /// </summary>
    private readonly ActorStateStoreProvider _stateProvider;

    private ApplicationAdministration? _aggregate;

    /// <summary>
    /// Initializes a new instance of the <see cref="ApplicationAdministrationActor"/> class.
    /// </summary>
    /// <param name="host">The host.</param>
    /// <param name="settings">The settings.</param>
    /// <param name="stateManager">The state manager.</param>
    /// <exception cref="ArgumentNullException"></exception>
    public ApplicationAdministrationActor(
     ActorHost host,
     IOptions<ApplicationAdministrationSettings> settings,
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

    /// <inheritdoc/>
    public async Task<int> AdministratorCountAsync()
        => (await GetAggregateAsync(CancellationToken.None).ConfigureAwait(false))?.Administrators.Count() ?? 0;

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
    public async Task<bool> HasCommandsAsync()
    {
        return await _stateManager
            .GetCommandCountAsync(_stateProvider, CancellationToken.None)
            .ConfigureAwait(false) > 0L;
    }

    /// <inheritdoc/>
    public async Task<bool> IsAdministratorAsync(string email)
        => (await GetAggregateAsync(CancellationToken.None).ConfigureAwait(false))?.IsAdministrator(email) == true;

    /// <inheritdoc/>
    public async Task ReceiveReminderAsync(string reminderName, byte[] state, TimeSpan dueTime, TimeSpan period)
    {
        _ = await _stateManager
            .ContinueAsync(
                _stateProvider,
                _settings.ExecuteCommandResiliencyPolicy ?? ResiliencyPolicy.CreateEternalExponentialRetry(),
                _aggregate,
                (e) => new ApplicationAdministration((GlobalAdministratorRegistered)e),
                RegisterReminderAsync,
                UnregisterReminderAsync,
                CancellationToken.None)
            .ConfigureAwait(false);
    }

    private async Task<ApplicationAdministration?> GetAggregateAsync(CancellationToken cancellationToken)
    {
        return _aggregate
            ??= (ApplicationAdministration?)await _stateManager
            .GetAggregateAsync(
                _stateProvider,
                (e) => new ApplicationAdministration((GlobalAdministratorRegistered)e),
                cancellationToken)
            .ConfigureAwait(false);
    }
}