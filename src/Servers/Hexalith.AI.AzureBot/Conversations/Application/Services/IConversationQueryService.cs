namespace Hexalith.AI.AzureBot.Conversations.Application.Services;

public interface IConversationQueryService
{
    Task<bool> IsGlobalAdministratorAsync(string email);

    Task<bool> IsRegisteredAsync(string email);
}