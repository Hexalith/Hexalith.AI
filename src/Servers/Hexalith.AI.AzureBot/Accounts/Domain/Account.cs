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
namespace Hexalith.AI.AzureBot.Accounts.Domain;

using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.Serialization;

using Hexalith.AI.AzureBot.Accounts.Domain.Events;
using Hexalith.Domain.Abstractions.Aggregates;
using Hexalith.Domain.Abstractions.Events;
using Hexalith.Domain.Abstractions.Exceptions;

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
    IEnumerable<Tenant> Tenants,
    IEnumerable<AccountUser> Users) : IAggregate
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
              Array.Empty<Tenant>(),
              Array.Empty<AccountUser>())
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
            AccountTenantRegistered tenant => this with
            {
                Tenants = AddTenant(tenant),
            },
            AccountUserRegistered user => this with
            {
                Users = Users.Append(new AccountUser(user.Email, Array.Empty<string>())),
            },
            AccountUserRoleGranted role => this with
            {
                Users = AddRole(role.Email, role.Role),
            },
            AccountRegistered => throw new InvalidAggregateEventException(this, domainEvent, true),
            _ => throw new InvalidAggregateEventException(this, domainEvent, false),
        };
    }

    private IEnumerable<Tenant> AddTenant(AccountTenantRegistered tenant)
    {
        Dictionary<string, Tenant> dict = Tenants.ToDictionary(k => k.Id, v => v);
        bool result = dict.TryAdd(tenant.TenantId, new Tenant(tenant.TenantId));
        return !result
            ? throw new InvalidOperationException($"Duplicate tenant '{tenant.TenantId}' added to account '{tenant.Name}'.")
            : (IEnumerable<Tenant>)dict.Values;
    }

    private IEnumerable<AccountUser> AddRole(string email, string role)
    {
        AccountUser user = Users.Single(u => u.Email == email);
        AccountUser newUser = user with { Roles = user.Roles.Append(role) };
        return Users.Where(u => u.Email != email).Append(newUser);
    }
}