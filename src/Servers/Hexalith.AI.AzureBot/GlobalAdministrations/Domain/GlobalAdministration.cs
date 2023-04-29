// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 04-25-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 04-25-2023
// ***********************************************************************
// <copyright file="GlobalAdministration.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.GlobalAdministrations.Domain;

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

using Hexalith.AI.AzureBot.GlobalAdministrations.Domain.Entities;
using Hexalith.AI.AzureBot.GlobalAdministrations.Domain.Events;
using Hexalith.Domain.Abstractions.Aggregates;
using Hexalith.Domain.Abstractions.Events;

/// <summary>
/// Class GlobalAdministration.
/// Implements the <see cref="IEquatable{GlobalAdministration}" />.
/// </summary>
/// <seealso cref="IEquatable{GlobalAdministration}" />
///
[DebuggerDisplay("{Administrators.Count} administrators")]
[DataContract]
public record GlobalAdministration(string AggregateName, string AggregateId, IEnumerable<GlobalAdministrator> Administrators) : IAggregate
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GlobalAdministration"/> class.
    /// </summary>
    /// <param name="registered">The registered.</param>
    public GlobalAdministration(GlobalAdministratorRegistered registered)
        : this()
    {
        GlobalAdministration admin = Apply(registered);
        Administrators = admin.Administrators;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="GlobalAdministration"/> class.
    /// </summary>
    public GlobalAdministration()
        : this(nameof(GlobalAdministration), nameof(GlobalAdministration), Array.Empty<GlobalAdministrator>())
    {
    }

    /// <summary>
    /// Applies the specified domain event.
    /// </summary>
    /// <param name="domainEvent">The domain event.</param>
    /// <returns>GlobalAdministration.</returns>
    /// <exception cref="System.ArgumentNullException"></exception>
    public IAggregate Apply([NotNull] BaseEvent domainEvent)
    {
        ArgumentNullException.ThrowIfNull(domainEvent);
        GlobalAdministration globalAdministration = new();
        return domainEvent switch
        {
            GlobalAdministratorRegistered e => Apply(e),
            _ => throw new InvalidOperationException($"The event {domainEvent.TypeName} is not supported by aggregate {nameof(GlobalAdministration)}."),
        };
    }

    /// <summary>
    /// Applies the specified domain event.
    /// </summary>
    /// <param name="domainEvent">The domain event.</param>
    /// <returns>GlobalAdministration.</returns>
    /// <exception cref="InvalidOperationException">The global administrator with email '{domainEvent.Email}' cannot be registered as it already exists in the system.</exception>
    private GlobalAdministration Apply(GlobalAdministratorRegistered domainEvent)
    {
        Dictionary<string, GlobalAdministrator> administrators = Administrators.ToDictionary(p => p.Email);
        if (administrators.ContainsKey(domainEvent.Email.ToUpperInvariant()))
        {
            throw new InvalidOperationException($"The global administrator with email '{domainEvent.Email}' cannot be registered as it already exists in the system.");
        }

        administrators.Add(domainEvent.Email.ToUpperInvariant(), GlobalAdministrator.Apply(domainEvent));
        return this with { Administrators = administrators.Values };
    }

    /// <summary>
    /// Determines whether the specified email is administrator.
    /// </summary>
    /// <param name="email">The email.</param>
    /// <returns><c>true</c> if the specified email is administrator; otherwise, <c>false</c>.</returns>
    public bool IsAdministrator(string email)
        => Administrators
            .Where(p => p.Name == email.ToUpperInvariant() && p.Enabled)
            .Any();

    /// <summary>
    /// Determines whether the specified email is registered.
    /// </summary>
    /// <param name="email">The email.</param>
    /// <returns><c>true</c> if the specified email is registered; otherwise, <c>false</c>.</returns>
    public bool IsRegistered(string email)
        => Administrators
            .Where(p => p.Name == email.ToUpperInvariant())
            .Any();
}