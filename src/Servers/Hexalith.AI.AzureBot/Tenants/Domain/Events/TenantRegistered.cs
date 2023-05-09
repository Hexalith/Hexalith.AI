// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 04-24-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 05-08-2023
// ***********************************************************************
// <copyright file="TenantRegistered.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.Tenants.Domain.Events;

using System.Text.Json.Serialization;

/// <summary>
/// Class TenantRegistered.
/// Implements the <see cref="BaseEvent" />.
/// </summary>
/// <seealso cref="BaseEvent" />
public class TenantRegistered : TenantEvent
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TenantRegistered" /> class.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <param name="domain">The domain.</param>
    /// <param name="id">The identifier.</param>
    [JsonConstructor]
    public TenantRegistered(string name, string domain, string id)
        : base(name)
    {
        Domain = domain;
        Id = id;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="TenantRegistered" /> class.
    /// </summary>
    [Obsolete("For serialization only", true)]
    public TenantRegistered() => Id = Domain = string.Empty;

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