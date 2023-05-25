// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 04-24-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 05-02-2023
// ***********************************************************************
// <copyright file="RegisterTenant.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Hexalith.AI.AzureBot.SecurityTenants.Application.Commands;

using System.ComponentModel;
using System.Text.Json.Serialization;

using Hexalith.Domain.Events;

/// <summary>
/// Class TenantRegistered.
/// Implements the <see cref="BaseEvent" />.
/// </summary>
/// <seealso cref="BaseEvent" />
[Description("Register security tenant")]
public class RegisterSecurityTenant : SecurityTenantCommand
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RegisterSecurityTenant"/> class.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <param name="domain">The domain.</param>
    /// <param name="id">The identifier.</param>
    [JsonConstructor]
    public RegisterSecurityTenant(string name, string domain, string id)
        : base(name)
    {
        Domain = domain;
        Id = id;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="RegisterSecurityTenant"/> class.
    /// </summary>
    [Obsolete("For serialization only", true)]
    public RegisterSecurityTenant() => Name = Domain = Id = string.Empty;

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