namespace Hexalith.AI.AzureBot.Users.Application.Services;

public interface IUserCommandService
{
    Task GrantGlobalAdministratorRoleAsync(string email, string correlationId, CancellationToken cancellationToken);

    Task RegisterAsync(string email, string correlationId, CancellationToken cancellationToken);
}