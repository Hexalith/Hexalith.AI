// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 04-30-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 05-11-2023
// ***********************************************************************
// <copyright file="Project.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.UnitOfWork.Domain.Projects;

using Hexalith.AI.AzureBot.UnitOfWork.Domain.Projects.Events;
using Hexalith.Domain.Aggregates;
using Hexalith.Domain.Events;

/// <summary>
/// Class Project.
/// Implements the <see cref="IAggregate" />
/// Implements the <see cref="System.IEquatable{Hexalith.AI.AzureBot.UnitOfWork.Domain.Projects.Project}" />.
/// </summary>
/// <seealso cref="IAggregate" />
/// <seealso cref="System.IEquatable{Hexalith.AI.AzureBot.UnitOfWork.Domain.Projects.Project}" />
public record Project(
    string AggregateName,
    string AggregateId,
    string Name,
    IEnumerable<string> Administrators,
    IEnumerable<string> Contributors,
    IEnumerable<ProjectSource> Sources) : IAggregate
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Project" /> class.
    /// </summary>
    /// <param name="projectAdded">The project added.</param>
    public Project(ProjectStarted projectAdded)
        : this(
              nameof(Project),
              (projectAdded ?? throw new ArgumentNullException(nameof(projectAdded))).AggregateId,
              projectAdded.Name,
              Array.Empty<string>(),
              Array.Empty<string>(),
              Array.Empty<ProjectSource>())
    {
    }

    /// <inheritdoc/>
    public IAggregate Apply(BaseEvent domainEvent) => throw new NotImplementedException();
}