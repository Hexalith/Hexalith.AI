namespace Hexalith.AI.AzureBot.GlobalAdministrations.Application.Services;

public interface IGlobalAdministrationCommandService
{
    Task GrantGlobalAdministratorRoleAsync(
        string email,
        string userId,
        string messageId,
        string correlationId,
        string sessionId,
        CancellationToken cancellationToken);
}