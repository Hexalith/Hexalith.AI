namespace Hexalith.AI.AzureBot.Users.Application.Services;

public interface IUserQueryService
{
    Task<bool> IsRegisteredAsync(string email, CancellationToken cancellationToken);
}