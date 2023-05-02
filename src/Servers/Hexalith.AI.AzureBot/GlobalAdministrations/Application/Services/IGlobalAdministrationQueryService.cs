namespace Hexalith.AI.AzureBot.GlobalAdministrations.Application.Services;

public interface IGlobalAdministrationQueryService
{
    Task<bool> IsAdministratorAsync(string email);
}