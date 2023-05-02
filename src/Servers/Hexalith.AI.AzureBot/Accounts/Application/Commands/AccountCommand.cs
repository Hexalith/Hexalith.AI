// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 04-24-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 05-02-2023
// ***********************************************************************
// <copyright file="AccountCommand.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Hexalith.AI.AzureBot.Accounts.Application.Commands;

using System.Text.Json.Serialization;

using Hexalith.AI.AzureBot.Accounts.Domain;
using Hexalith.Application.Abstractions.Commands;
using Hexalith.Domain.Abstractions.Events;

/// <summary>
/// Class AccountRegistered.
/// Implements the <see cref="BaseEvent" />.
/// </summary>
/// <seealso cref="BaseEvent" />
public abstract class AccountCommand : BaseCommand
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AccountCommand" /> class.
    /// </summary>
    /// <param name="name">The name.</param>
    [JsonConstructor]
    protected AccountCommand(string name) => Name = name;

    /// <summary>
    /// Initializes a new instance of the <see cref="AccountCommand" /> class.
    /// </summary>
    [Obsolete("For serialization only", true)]
    protected AccountCommand() => Name = string.Empty;

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>The name.</value>
    public string Name { get; set; }

    /// <inheritdoc/>
    protected override string DefaultAggregateId() => Name;

    /// <inheritdoc/>
    protected override string DefaultAggregateName() => nameof(Account);
}