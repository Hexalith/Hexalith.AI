// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 04-30-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 04-30-2023
// ***********************************************************************
// <copyright file="ProjectStarted.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.UnitOfWork.Domain.Projects.Events;

using Hexalith.Domain.Events;

/// <summary>
/// Class ProjectStarted.
/// Implements the <see cref="BaseEvent" />.
/// </summary>
/// <seealso cref="BaseEvent" />
public class ProjectStarted : BaseEvent
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ProjectStarted"/> class.
    /// </summary>
    /// <param name="name">The name.</param>
    public ProjectStarted(string name)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        Name = name;
    }

    /// <summary>
    /// Gets the name.
    /// </summary>
    /// <value>The name.</value>
    public string Name { get; }
}