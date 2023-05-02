// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 04-24-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 05-01-2023
// ***********************************************************************
// <copyright file="UserRegistered.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.Users.Application.Commands;

using System.Text.Json.Serialization;

using Hexalith.AI.AzureBot.Users.Domain.Commands;

/// <summary>
/// Class UserRegistered.
/// Implements the <see cref="BaseCommand" />.
/// </summary>
/// <seealso cref="BaseCommand" />
public class RegisterUser : UserCommand
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RegisterUser" /> class.
    /// </summary>
    /// <param name="email">The email.</param>
    [JsonConstructor]
    public RegisterUser(string email)
        : base(email)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="RegisterUser" /> class.
    /// </summary>
    [Obsolete("For serialization only", true)]
    public RegisterUser()
    {
    }
}