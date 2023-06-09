﻿// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 04-24-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 04-30-2023
// ***********************************************************************
// <copyright file="AccountRegistered.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.Accounts.Domain.Events;

using System.Text.Json.Serialization;

/// <summary>
/// Class AccountRegistered.
/// Implements the <see cref="BaseEvent" />.
/// </summary>
/// <seealso cref="BaseEvent" />
public class AccountRegistered : AccountEvent
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AccountRegistered" /> class.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <param name="domain">The domain.</param>
    [JsonConstructor]
    public AccountRegistered(string name, string domain)
        : base(name) => Domain = domain;

    /// <summary>
    /// Initializes a new instance of the <see cref="AccountRegistered" /> class.
    /// </summary>
    [Obsolete("For serialization only", true)]
    public AccountRegistered() => Domain = string.Empty;

    /// <summary>
    /// Gets or sets the domain.
    /// </summary>
    /// <value>The domain.</value>
    public string Domain { get; set; }
}