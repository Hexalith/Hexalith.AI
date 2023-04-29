// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 04-24-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 04-25-2023
// ***********************************************************************
// <copyright file="RegisterAccount.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Hexalith.AI.AzureBot.Application.Accounts.Commands;

using System.Collections.Generic;
using System.Text.Json.Serialization;

using Hexalith.Application.Abstractions.Commands;
using Hexalith.Domain.Abstractions.Events;

/// <summary>
/// Class AccountRegistered.
/// Implements the <see cref="BaseEvent" />.
/// </summary>
/// <seealso cref="BaseEvent" />
public class RegisterAccount : BaseCommand
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RegisterAccount"/> class.
    /// </summary>
    /// <param name="domain">The domain.</param>
    /// <param name="name">The name.</param>
    /// <param name="administrators">The administrators.</param>
    [JsonConstructor]
    public RegisterAccount(string domain, string name, IEnumerable<string> administrators)
    {
        Domain = domain;
        Name = name;
        Administrators = administrators;
    }

    /// <summary>
    /// Gets or sets the administrators.
    /// </summary>
    /// <value>The administrators.</value>
    public IEnumerable<string> Administrators { get; set; }

    /// <summary>
    /// Gets or sets the domain.
    /// </summary>
    /// <value>The domain.</value>
    public string Domain { get; set; }

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>The name.</value>
    public string Name { get; set; }
}