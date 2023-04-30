namespace Hexalith.AI.AzureBot.UnitOfWork.Application.Providers;

public interface IUnitOfWorkProvider
{
    Task SynchronizeItemsAsync(CancellationToken cancellationToken = default);

    Task SynchronizeProjectsAsync(CancellationToken cancellationToken = default);
}