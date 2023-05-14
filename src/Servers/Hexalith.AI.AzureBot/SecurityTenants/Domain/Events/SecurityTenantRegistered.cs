// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 04-24-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 05-08-2023
// ***********************************************************************
// <copyright file="SecurityTenantRegistered.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.SecurityTenants.Domain.Events;

using System.Text.Json.Serialization;

/// <summary>
/// Class SecurityTenantRegistered.
/// Implements the <see cref="BaseEvent" />.
/// </summary>
/// <seealso cref="BaseEvent" />
public class SecurityTenantRegistered : SecurityTenantEvent
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SecurityTenantRegistered" /> class.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <param name="domain">The domain.</param>
    /// <param name="id">The identifier.</param>
    [JsonConstructor]
    public SecurityTenantRegistered(string name, string domain, string id)
        : base(name)
    {
        Domain = domain;
        Id = id;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SecurityTenantRegistered" /> class.
    /// </summary>
    [Obsolete("For serialization only", true)]
    public SecurityTenantRegistered() => Id = Domain = string.Empty;

    /// <summary>
    /// Gets or sets the domain.
    /// </summary>
    /// <value>The domain.</value>
    public string Domain { get; set; }

    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    /// <value>The identifier.</value>
    public string Id { get; set; }
}