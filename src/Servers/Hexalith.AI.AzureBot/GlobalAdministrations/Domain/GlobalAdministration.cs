// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 04-25-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 04-25-2023
// ***********************************************************************
// <copyright file="ApplicationAdministration.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.ApplicationAdministrations.Domain;

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

using Hexalith.AI.AzureBot.ApplicationAdministrations.Domain.Entities;
using Hexalith.AI.AzureBot.ApplicationAdministrations.Domain.Events;
using Hexalith.Domain.Aggregates;
using Hexalith.Domain.Events;
using Hexalith.Domain.Exceptions;

/// <summary>
/// Class ApplicationAdministration.
/// Implements the <see cref="IEquatable{ApplicationAdministration}" />.
/// </summary>
/// <seealso cref="IEquatable{ApplicationAdministration}" />
///
[DebuggerDisplay("{Administrators.Count} administrators")]
[DataContract]
public record ApplicationAdministration(string AggregateName, string AggregateId, IEnumerable<GlobalAdministrator> Administrators) : IAggregate
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ApplicationAdministration"/> class.
    /// </summary>
    /// <param name="registered">The registered.</param>
    public ApplicationAdministration(GlobalAdministratorRegistered registered)
        : this()
    {
        ApplicationAdministration admin = Apply(registered);
        Administrators = admin.Administrators;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ApplicationAdministration"/> class.
    /// </summary>
    public ApplicationAdministration()
        : this(nameof(ApplicationAdministration), nameof(ApplicationAdministration), Array.Empty<GlobalAdministrator>())
    {
    }

    /// <summary>
    /// Applies the specified domain event.
    /// </summary>
    /// <param name="domainEvent">The domain event.</param>
    /// <returns>ApplicationAdministration.</returns>
    /// <exception cref="System.ArgumentNullException"></exception>
    public IAggregate Apply([NotNull] BaseEvent domainEvent)
    {
        ArgumentNullException.ThrowIfNull(domainEvent);
        _ = new ApplicationAdministration();
        return domainEvent switch
        {
            GlobalAdministratorRegistered e => Apply(e),
            _ => throw new InvalidAggregateEventException(this, domainEvent, false),
        };
    }

    /// <summary>
    /// Applies the specified domain event.
    /// </summary>
    /// <param name="domainEvent">The domain event.</param>
    /// <returns>ApplicationAdministration.</returns>
    /// <exception cref="InvalidOperationException">The global administrator with email '{domainEvent.Email}' cannot be registered as it already exists in the system.</exception>
    private ApplicationAdministration Apply(GlobalAdministratorRegistered domainEvent)
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
            .Where(p => p.Email == email.ToUpperInvariant() && p.Enabled)
            .Any();
}