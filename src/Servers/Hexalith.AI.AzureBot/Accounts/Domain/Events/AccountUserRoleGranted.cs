// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 04-24-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 05-02-2023
// ***********************************************************************
// <copyright file="RegisterAccountUserRole.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Hexalith.AI.AzureBot.Accounts.Domain.Events;

using System.Text.Json.Serialization;

/// <summary>
/// Class AccountGranted.
/// Implements the <see cref="BaseEvent" />.
/// </summary>
/// <seealso cref="BaseEvent" />
public class AccountUserRoleGranted : AccountEvent
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AccountUserRoleGranted" /> class.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <param name="email">The email.</param>
    /// <param name="role">The role.</param>
    [JsonConstructor]
    public AccountUserRoleGranted(string name, string email, string role)
        : base(name)
    {
        Email = email;
        Role = role;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AccountUserRoleGranted" /> class.
    /// </summary>
    [Obsolete("For serialization only", true)]
    public AccountUserRoleGranted() => Role = Email = string.Empty;

    /// <summary>
    /// Gets the email.
    /// </summary>
    /// <value>The email.</value>
    public string Email { get; }

    /// <summary>
    /// Gets the role.
    /// </summary>
    /// <value>The role.</value>
    public string Role { get; }
}