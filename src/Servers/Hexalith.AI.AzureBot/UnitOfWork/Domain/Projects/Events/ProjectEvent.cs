// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 04-30-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 04-30-2023
// ***********************************************************************
// <copyright file="ProjectEvent.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.UnitOfWork.Domain.Projects.Events;

using Hexalith.Domain.Events;

/// <summary>
/// Class ProjectEvent.
/// Implements the <see cref="BaseEvent" />.
/// </summary>
/// <seealso cref="BaseEvent" />
public class ProjectEvent : BaseEvent
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ProjectEvent" /> class.
    /// </summary>
    /// <param name="name">The name.</param>
    public ProjectEvent(string name)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        Name = name;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ProjectEvent"/> class.
    /// </summary>
    [Obsolete("For serialization only", true)]
    public ProjectEvent() => Name = string.Empty;

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>The name.</value>
    public string Name { get; set; }

    /// <summary>
    /// Defaults the aggregate identifier.
    /// </summary>
    /// <returns>System.String.</returns>
    protected override string DefaultAggregateId() => Name;

    /// <inheritdoc/>
    protected override string DefaultAggregateName() => nameof(Project);
}