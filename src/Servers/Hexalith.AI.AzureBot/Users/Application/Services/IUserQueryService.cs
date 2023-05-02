namespace Hexalith.AI.AzureBot.Users.Application.Services;

public interface IUserQueryService
{
    Task<bool> IsGlobalAdministratorAsync(string email);

    Task<bool> IsRegisteredAsync(string email);
}