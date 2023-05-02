// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 04-24-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 05-02-2023
// ***********************************************************************
// <copyright file="RegisterTenant - Copy.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Hexalith.AI.AzureBot.Tenants.Domain.Events;

using System.Text.Json.Serialization;

using Hexalith.Domain.Abstractions.Events;

/// <summary>
/// Class TenantRegistered.
/// Implements the <see cref="BaseEvent" />.
/// </summary>
/// <seealso cref="BaseEvent" />
public class TenantDomainRegistered : TenantEvent
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TenantDomainRegistered"/> class.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <param name="domain">The domain.</param>
    [JsonConstructor]
    public TenantDomainRegistered(string name, string domain)
        : base(name) => Domain = domain;

    /// <summary>
    /// Initializes a new instance of the <see cref="TenantDomainRegistered"/> class.
    /// </summary>
    [Obsolete("For serialization only", true)]
    public TenantDomainRegistered() => Domain = string.Empty;

    /// <summary>
    /// Gets the domain.
    /// </summary>
    /// <value>The domain.</value>
    public string Domain { get; }
}