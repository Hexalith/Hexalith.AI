// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 04-24-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 05-08-2023
// ***********************************************************************
// <copyright file="AccountDomainRegistered.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Hexalith.AI.AzureBot.Accounts.Domain.Events;

using System.Text.Json.Serialization;

using Hexalith.Domain.Abstractions.Events;

/// <summary>
/// Class AccountRegistered.
/// Implements the <see cref="BaseEvent" />.
/// </summary>
/// <seealso cref="BaseEvent" />
public class AccountTenantRegistered : AccountEvent
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AccountTenantRegistered" /> class.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <param name="tenantId">The tenant identifier.</param>
    [JsonConstructor]
    public AccountTenantRegistered(string name, string tenantId)
        : base(name) => TenantId = tenantId;

    /// <summary>
    /// Initializes a new instance of the <see cref="AccountTenantRegistered" /> class.
    /// </summary>
    [Obsolete("For serialization only", true)]
    public AccountTenantRegistered() => TenantId = string.Empty;

    /// <summary>
    /// Gets the tenant identifier.
    /// </summary>
    /// <value>The tenant identifier.</value>
    public string TenantId { get; }
}