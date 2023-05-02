namespace Hexalith.AI.AzureBot.Conversations.Application.Services;

public interface IConversationCommandService
{
    Task GrantGlobalAdministratorRoleAsync(string email, string correlationId, CancellationToken cancellationToken);

    Task RegisterAsync(string email, string correlationId, CancellationToken cancellationToken);
}