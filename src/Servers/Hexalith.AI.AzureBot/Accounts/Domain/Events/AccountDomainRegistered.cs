// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 04-24-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 05-02-2023
// ***********************************************************************
// <copyright file="RegisterAccount - Copy.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Hexalith.AI.AzureBot.Accounts.Application.Events;

using System.Text.Json.Serialization;

using Hexalith.AI.AzureBot.Accounts.Domain.Events;
using Hexalith.Domain.Abstractions.Events;

/// <summary>
/// Class AccountRegistered.
/// Implements the <see cref="BaseEvent" />.
/// </summary>
/// <seealso cref="BaseEvent" />
public class AccountDomainRegistered : AccountEvent
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AccountDomainRegistered"/> class.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <param name="domain">The domain.</param>
    [JsonConstructor]
    public AccountDomainRegistered(string name, string domain)
        : base(name) => Domain = domain;

    /// <summary>
    /// Initializes a new instance of the <see cref="AccountDomainRegistered"/> class.
    /// </summary>
    [Obsolete("For serialization only", true)]
    public AccountDomainRegistered() => Domain = string.Empty;

    /// <summary>
    /// Gets the domain.
    /// </summary>
    /// <value>The domain.</value>
    public string Domain { get; }
}