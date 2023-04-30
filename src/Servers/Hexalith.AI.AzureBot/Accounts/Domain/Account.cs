﻿// ***********************************************************************
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
namespace Hexalith.AI.AzureBot.Accounts.Domain;

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

using Hexalith.AI.AzureBot.Accounts.Domain.Events;
using Hexalith.Domain.Abstractions.Aggregates;
using Hexalith.Domain.Abstractions.Events;
using Hexalith.Domain.Abstractions.Exceptions;
using Hexalith.Extensions.Helpers;

/// <summary>
/// Class Account.
/// Implements the <see cref="IAggregate" />
/// Implements the <see cref="IEquatable{Account}" />.
/// </summary>
/// <seealso cref="IAggregate" />
/// <seealso cref="IEquatable{Account}" />
[DebuggerDisplay("{Name} ({Domain})")]
[DataContract]
public record Account(
    string AggregateId,
    string AggregateName,
    string Name,
    IEnumerable<Domain> Domains,
    IEnumerable<Tenant> Tenants,
    IEnumerable<string> Administrators) : IAggregate
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Account" /> class.
    /// </summary>
    /// <param name="registered">The registered.</param>
    public Account(AccountRegistered registered)
        : this(
              nameof(Account),
              (registered ?? throw new ArgumentNullException(nameof(registered))).AggregateId,
              registered.Name,
              new Domain(registered.Domain).IntoArray(),
              Array.Empty<Tenant>(),
              Array.Empty<string>())
    {
    }

    /// <summary>
    /// Applies the specified domain event.
    /// </summary>
    /// <param name="domainEvent">The domain event.</param>
    /// <returns>Account.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    public IAggregate Apply([NotNull] BaseEvent domainEvent)
    {
        ArgumentNullException.ThrowIfNull(domainEvent);
        return domainEvent switch
        {
            AccountRegistered => throw new InvalidAggregateEventException(this, domainEvent, true),
            _ => throw new InvalidAggregateEventException(this, domainEvent, false),
        };
    }
}