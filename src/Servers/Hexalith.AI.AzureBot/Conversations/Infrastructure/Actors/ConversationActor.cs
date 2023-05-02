// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 04-25-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 04-25-2023
// ***********************************************************************
// <copyright file="ConversationActor.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.Conversations.Infrastructure.Actors;

using Dapr.Actors.Runtime;

using Hexalith.AI.AzureBot.Conversations.Domain;
using Hexalith.AI.AzureBot.Conversations.Domain.Events;
using Hexalith.Application.Abstractions.Aggregates;
using Hexalith.Application.Abstractions.Tasks;
using Hexalith.Infrastructure.DaprRuntime.Handlers;
using Hexalith.Infrastructure.DaprRuntime.States;

using Microsoft.Extensions.Options;

/// <summary>
/// Class ConversationActor.
/// Implements the <see cref="Actor" />
/// Implements the <see cref="IConversationActor" />
/// Implements the <see cref="ICommandProcessorActor" />
/// Implements the <see cref="IRemindable" />.
/// </summary>
/// <seealso cref="Actor" />
/// <seealso cref="IConversationActor" />
/// <seealso cref="ICommandProcessorActor" />
/// <seealso cref="IRemindable" />
public class ConversationActor : Actor, IConversationActor, ICommandProcessorActor, IRemindable
{
    /// <summary>
    /// The settings.
    /// </summary>
    private readonly ConversationSettings _settings;

    /// <summary>
    /// The state manager.
    /// </summary>
    private readonly IAggregateStateManager _stateManager;

    /// <summary>
    /// The state provider.
    /// </summary>
    private readonly ActorStateStoreProvider _stateProvider;

    private Conversation? _aggregate;

    /// <summary>
    /// Initializes a new instance of the <see cref="ConversationActor"/> class.
    /// </summary>
    /// <param name="host">The host.</param>
    /// <param name="settings">The settings.</param>
    /// <param name="stateManager">The state manager.</param>
    /// <exception cref="ArgumentNullException"></exception>
    public ConversationActor(
     ActorHost host,
     IOptions<ConversationSettings> settings,
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
        Conversation? user = await GetAggregateAsync(CancellationToken.None).ConfigureAwait(false);
        if (user is null)
        {
            return Array.Empty<string>();
        }
        ConversationAccount? userAccount = user.Accounts.Where(p => p.Name == account).SingleOrDefault();
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
                (e) => new Conversation((ConversationRegistered)e),
                RegisterReminderAsync,
                UnregisterReminderAsync,
                CancellationToken.None)
            .ConfigureAwait(false);
    }

    private async Task<Conversation?> GetAggregateAsync(CancellationToken cancellationToken)
    {
        return _aggregate
            ??= (Conversation?)await _stateManager
            .GetAggregateAsync(
                _stateProvider,
                (e) => new Conversation((ConversationRegistered)e),
                cancellationToken)
            .ConfigureAwait(false);
    }
}