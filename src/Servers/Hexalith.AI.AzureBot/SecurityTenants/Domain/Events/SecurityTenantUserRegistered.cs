// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 04-24-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 05-02-2023
// ***********************************************************************
// <copyright file="SecurityTenantUserRegistered.cs" company="Fiveforty">
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
public class SecurityTenantUserRegistered : SecurityTenantEvent
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SecurityTenantUserRegistered" /> class.
    /// </summary>
    /// <param name="objectId">The object identifier.</param>
    /// <param name="name">The name.</param>
    /// <param name="email">The email.</param>
    [JsonConstructor]
    public SecurityTenantUserRegistered(string objectId, string name, string email)
        : base(name)
    {
        ObjectId = objectId;
        Name = name;
        Email = email;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SecurityTenantUserRegistered" /> class.
    /// </summary>
    [Obsolete("For serialization only", true)]
    public SecurityTenantUserRegistered() => Name = ObjectId = Email = string.Empty;

    /// <summary>
    /// Gets the email.
    /// </summary>
    /// <value>The email.</value>
    public string Email { get; }

    /// <summary>
    /// Gets the name.
    /// </summary>
    /// <value>The name.</value>
    public new string Name { get; }

    /// <summary>
    /// Gets the object identifier.
    /// </summary>
    /// <value>The object identifier.</value>
    public string ObjectId { get; }
}