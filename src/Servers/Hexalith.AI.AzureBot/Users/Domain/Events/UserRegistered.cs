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
namespace Hexalith.AI.AzureBot.Users.Domain.Events;

using System.Text.Json.Serialization;

/// <summary>
/// Class UserRegistered.
/// Implements the <see cref="BaseEvent" />.
/// </summary>
/// <seealso cref="BaseEvent" />
public class UserRegistered : UserEvent
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UserRegistered" /> class.
    /// </summary>
    /// <param name="email">The email.</param>
    [JsonConstructor]
    public UserRegistered(string email)
        : base(email)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="UserRegistered" /> class.
    /// </summary>
    [Obsolete("For serialization only", true)]
    public UserRegistered()
    {
    }
}