namespace Hexalith.AI.AzureBot.UnitOfWork.Domain.Projects;

using Hexalith.AI.AzureBot.UnitOfWork.Domain.Projects.Events;
using Hexalith.Domain.Abstractions.Aggregates;
using Hexalith.Domain.Abstractions.Events;

public record Project(
    string AggregateName,
    string AggregateId,
    string Name,
    IEnumerable<string> Administrators,
    IEnumerable<string> Contributors,
    IEnumerable<ProjectSource> Sources) : IAggregate
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Project"/> class.
    /// </summary>
    /// <param name="projectAdded"></param>
    public Project(ProjectStarted projectAdded)
        : this(
              nameof(Project),
              projectAdded.AggregateId,
              projectAdded.Name,
              Array.Empty<string>(),
              Array.Empty<string>(),
              Array.Empty<ProjectSource>())
    {
    }

    /// <inheritdoc/>
    public IAggregate Apply(BaseEvent domainEvent) => throw new NotImplementedException();
}