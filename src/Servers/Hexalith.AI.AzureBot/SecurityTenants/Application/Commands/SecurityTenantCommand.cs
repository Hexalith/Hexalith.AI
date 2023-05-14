// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 04-24-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 05-02-2023
// ***********************************************************************
// <copyright file="SecurityTenantCommand.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Hexalith.AI.AzureBot.SecurityTenants.Application.Commands;

using System.Text.Json.Serialization;

using Hexalith.AI.AzureBot.SecurityTenants.Domain;
using Hexalith.Application.Commands;
using Hexalith.Domain.Events;

/// <summary>
/// Class SecurityTenantRegistered.
/// Implements the <see cref="BaseEvent" />.
/// </summary>
/// <seealso cref="BaseEvent" />
public abstract class SecurityTenantCommand : BaseCommand
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SecurityTenantCommand" /> class.
    /// </summary>
    /// <param name="name">The name.</param>
    [JsonConstructor]
    protected SecurityTenantCommand(string name) => Name = name;

    /// <summary>
    /// Initializes a new instance of the <see cref="SecurityTenantCommand" /> class.
    /// </summary>
    [Obsolete("For serialization only", true)]
    protected SecurityTenantCommand() => Name = string.Empty;

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>The name.</value>
    public string Name { get; set; }

    /// <inheritdoc/>
    protected override string DefaultAggregateId() => Name;

    /// <inheritdoc/>
    protected override string DefaultAggregateName() => nameof(SecurityTenant);
}