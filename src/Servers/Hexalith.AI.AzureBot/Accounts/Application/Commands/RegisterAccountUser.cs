// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 04-24-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 05-02-2023
// ***********************************************************************
// <copyright file="RegisterAccountDomain - Copy.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Hexalith.AI.AzureBot.Accounts.Application.Commands;

using System.Text.Json.Serialization;

/// <summary>
/// Class AccountRegistered.
/// Implements the <see cref="BaseEvent" />.
/// </summary>
/// <seealso cref="BaseEvent" />
public class RegisterAccountUser : AccountCommand
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RegisterAccountUser" /> class.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <param name="email">The email.</param>
    [JsonConstructor]
    public RegisterAccountUser(string name, string email)
        : base(name) => Email = email;

    /// <summary>
    /// Initializes a new instance of the <see cref="RegisterAccountUser" /> class.
    /// </summary>
    [Obsolete("For serialization only", true)]
    public RegisterAccountUser() => Email = string.Empty;

    /// <summary>
    /// Gets the email.
    /// </summary>
    /// <value>The email.</value>
    public string Email { get; }
}