// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 04-24-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 04-25-2023
// ***********************************************************************
// <copyright file="AccountEvent.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.Accounts.Domain.Events;

using System.Text.Json.Serialization;

using Hexalith.Domain.Abstractions.Events;

/// <summary>
/// Class AccountEvent.
/// Implements the <see cref="BaseEvent" />.
/// </summary>
/// <seealso cref="BaseEvent" />
public class AccountEvent : BaseEvent
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AccountEvent"/> class.
    /// </summary>
    /// <param name="domain">The domain.</param>
    /// <param name="name">The name.</param>
    /// <param name="administrators">The administrators.</param>
    [JsonConstructor]
    protected AccountEvent(string name) => Name = name;

    /// <summary>
    /// Initializes a new instance of the <see cref="AccountEvent"/> class.
    /// </summary>
    [Obsolete("For serialization only", true)]
    protected AccountEvent() => Name = string.Empty;

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>The name.</value>
    public string Name { get; set; }

    /// <inheritdoc/>
    protected override string DefaultAggregateId() => Name;

    /// <inheritdoc/>
    protected override string DefaultAggregateName() => nameof(AccountEvent);
}