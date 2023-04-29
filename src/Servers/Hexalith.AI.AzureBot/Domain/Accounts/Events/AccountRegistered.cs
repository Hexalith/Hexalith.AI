// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 04-24-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 04-25-2023
// ***********************************************************************
// <copyright file="AccountRegistered.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.Domain.Accounts.Events;

using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

using Hexalith.Domain.Abstractions.Events;

/// <summary>
/// Class AccountRegistered.
/// Implements the <see cref="BaseEvent" />.
/// </summary>
/// <seealso cref="BaseEvent" />
[DebuggerDisplay("{Name} ({Domain})")]
[DataContract]
public class AccountRegistered : BaseEvent
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AccountRegistered"/> class.
    /// </summary>
    /// <param name="domain">The domain.</param>
    /// <param name="name">The name.</param>
    /// <param name="administrators">The administrators.</param>
    [JsonConstructor]
    public AccountRegistered(string domain, string name, IEnumerable<string> administrators)
    {
        Domain = domain;
        Name = name;
        Administrators = administrators;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AccountRegistered"/> class.
    /// </summary>
    [Obsolete("For serialization only", true)]
    public AccountRegistered()
    {
        Domain = Name = string.Empty;
        Administrators = Array.Empty<string>();
    }

    /// <summary>
    /// Gets the administrators.
    /// </summary>
    /// <value>The administrators.</value>
    public IEnumerable<string> Administrators { get; internal set; }

    /// <summary>
    /// Gets the domain.
    /// </summary>
    /// <value>The domain.</value>
    public string Domain { get; internal set; }

    /// <summary>
    /// Gets the name.
    /// </summary>
    /// <value>The name.</value>
    public string Name { get; internal set; }
}