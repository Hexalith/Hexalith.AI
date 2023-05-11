namespace Hexalith.AI.AzureBot.UnitOfWork.Application.Services;

using Hexalith.AI.AzureBot.UnitOfWork.Application.Providers;

public interface IUnitOfWorkService
{
    Task CreateAsync(string project, string title, string description, CancellationToken cancellationToken = default);

    Task SynchronizeProjectsAsync(IUnitOfWorkProvider source, CancellationToken cancellationToken = default);

    Task SynchronizeUnitOfWorkItemsAsync(IUnitOfWorkProvider source, CancellationToken cancellationToken = default);
}