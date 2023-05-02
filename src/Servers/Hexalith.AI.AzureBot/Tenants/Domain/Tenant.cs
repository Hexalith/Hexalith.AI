// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 04-24-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 05-02-2023
// ***********************************************************************
// <copyright file="Tenant.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.Tenants.Domain;

using System.Diagnostics.CodeAnalysis;

using Hexalith.AI.AzureBot.Tenants.Domain.Events;
using Hexalith.Domain.Abstractions.Aggregates;
using Hexalith.Domain.Abstractions.Events;
using Hexalith.Domain.Abstractions.Exceptions;

/// <summary>
/// Class Tenant.
/// Implements the <see cref="IAggregate" />
/// Implements the <see cref="IEquatable{Tenant}" />.
/// </summary>
/// <seealso cref="IAggregate" />
/// <seealso cref="IEquatable{Tenant}" />
public record Tenant(
    string Id,
    string Name,
    IEnumerable<TenantDomain> Domains,
    IEnumerable<TenantUser> Users) : Aggregate
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Tenant" /> class.
    /// </summary>
    /// <param name="registered">The registered.</param>
    public Tenant(TenantRegistered registered)
        : this(
              (registered ?? throw new ArgumentNullException(nameof(registered))).Id,
              registered.Name,
              Array.Empty<TenantDomain>(),
              Array.Empty<TenantUser>())
    {
    }

    /// <summary>
    /// Applies the specified domain event.
    /// </summary>
    /// <param name="domainEvent">The domain event.</param>
    /// <returns>Tenant.</returns>
    /// <exception cref="System.ArgumentNullException"></exception>
    public override IAggregate Apply([NotNull] BaseEvent domainEvent)
    {
        ArgumentNullException.ThrowIfNull(domainEvent);
        return domainEvent switch
        {
            TenantDomainRegistered domain => this with
            {
                Domains = Domains.Append(new TenantDomain(domain.Domain)),
            },
            TenantUserRegistered user => this with
            {
                Users = Users.Append(new TenantUser(user.ObjectId, user.Name, user.Email)),
            },
            TenantRegistered => throw new InvalidAggregateEventException(this, domainEvent, true),
            _ => throw new InvalidAggregateEventException(this, domainEvent, false),
        };
    }

    /// <inheritdoc/>
    protected override string DefaultAggregateId() => Id;

    /// <inheritdoc/>
    protected override string DefaultAggregateName() => nameof(Tenant);
}