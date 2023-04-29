// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 04-24-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 04-29-2023
// ***********************************************************************
// <copyright file="Account.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.Domain.Accounts;

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

using Hexalith.AI.AzureBot.Domain.Accounts.Events;
using Hexalith.Domain.Abstractions.Aggregates;
using Hexalith.Domain.Abstractions.Events;

/// <summary>
/// Class Account.
/// Implements the <see cref="IAggregate" />
/// Implements the <see cref="System.IEquatable{Hexalith.AI.AzureBot.Domain.Accounts.Account}" />.
/// </summary>
/// <seealso cref="IAggregate" />
/// <seealso cref="System.IEquatable{Hexalith.AI.AzureBot.Domain.Accounts.Account}" />
[DebuggerDisplay("{Name} ({Domain})")]
[DataContract]
public record Account(string AggregateId, string Domain, string Name, IEnumerable<string> Administrators) : IAggregate
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Account" /> class.
    /// </summary>
    /// <param name="registered">The registered.</param>
    public Account(AccountRegistered registered)
        : this(
              (registered ?? throw new ArgumentNullException(nameof(registered))).AggregateId,
              registered.Domain,
              registered.Name,
              registered.Administrators)
    {
    }

    /// <summary>
    /// Validates the specified registered.
    /// </summary>
    /// <param name="registered">The registered.</param>
    /// <returns>AccountRegistered.</returns>
    /// <exception cref="System.ArgumentNullException"></exception>
    private static AccountRegistered Validate(AccountRegistered? registered)
    {
        ArgumentNullException.ThrowIfNull(registered);
        return registered;
    }

    /// <summary>
    /// Applies the specified domain event.
    /// </summary>
    /// <param name="domainEvent">The domain event.</param>
    /// <returns>Account.</returns>
    /// <exception cref="System.ArgumentNullException"></exception>
    public IAggregate Apply([NotNull] BaseEvent domainEvent)
    {
        ArgumentNullException.ThrowIfNull(domainEvent);
        return domainEvent switch
        {
            AccountRegistered e => Apply(e),
            _ => throw new InvalidOperationException($"The event {domainEvent.TypeName} is not supported by aggregate {nameof(Account)}."),
        };
    }

    /// <inheritdoc/>
    [IgnoreDataMember]
    [JsonIgnore]
    public string AggregateName => nameof(Account);
}