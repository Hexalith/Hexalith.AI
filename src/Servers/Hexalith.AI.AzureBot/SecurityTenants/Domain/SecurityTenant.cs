// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 04-24-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 05-02-2023
// ***********************************************************************
// <copyright file="SecurityTenant.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.SecurityTenants.Domain;

using System.Diagnostics.CodeAnalysis;

using Hexalith.AI.AzureBot.SecurityTenants.Domain.Events;
using Hexalith.Domain.Aggregates;
using Hexalith.Domain.Events;
using Hexalith.Domain.Exceptions;

/// <summary>
/// Class SecurityTenant.
/// Implements the <see cref="IAggregate" />
/// Implements the <see cref="IEquatable{SecurityTenant}" />.
/// </summary>
/// <seealso cref="IAggregate" />
/// <seealso cref="IEquatable{SecurityTenant}" />
public record SecurityTenant(
    string Id,
    string Name,
    IEnumerable<SecurityTenantDomain> Domains,
    IEnumerable<SecurityTenantUser> Users) : Aggregate
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SecurityTenant" /> class.
    /// </summary>
    /// <param name="registered">The registered.</param>
    public SecurityTenant(SecurityTenantRegistered registered)
        : this(
              (registered ?? throw new ArgumentNullException(nameof(registered))).Id,
              registered.Name,
              Array.Empty<SecurityTenantDomain>(),
              Array.Empty<SecurityTenantUser>())
    {
    }

    /// <summary>
    /// Applies the specified domain event.
    /// </summary>
    /// <param name="domainEvent">The domain event.</param>
    /// <returns>SecurityTenant.</returns>
    /// <exception cref="System.ArgumentNullException"></exception>
    public override IAggregate Apply([NotNull] BaseEvent domainEvent)
    {
        ArgumentNullException.ThrowIfNull(domainEvent);
        return domainEvent switch
        {
            SecurityTenantDomainRegistered domain => this with
            {
                Domains = Domains.Append(new SecurityTenantDomain(domain.Domain)),
            },
            SecurityTenantUserRegistered user => this with
            {
                Users = Users.Append(new SecurityTenantUser(user.ObjectId, user.Name, user.Email)),
            },
            SecurityTenantRegistered => throw new InvalidAggregateEventException(this, domainEvent, true),
            _ => throw new InvalidAggregateEventException(this, domainEvent, false),
        };
    }

    /// <inheritdoc/>
    protected override string DefaultAggregateId() => Id;

    /// <inheritdoc/>
    protected override string DefaultAggregateName() => nameof(SecurityTenant);
}