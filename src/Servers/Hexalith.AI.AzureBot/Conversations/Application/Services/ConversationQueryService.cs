namespace Hexalith.AI.AzureBot.Conversations.Application.Services;

using System.Threading.Tasks;

using Dapr.Actors;
using Dapr.Actors.Client;

using Hexalith.AI.AzureBot.Conversations.Infrastructure.Actors;

public class ConversationQueryService : IConversationQueryService
{
    public async Task<bool> IsGlobalAdministratorAsync(string email)
        => await GetConversationActor(email).IsGlobalAdministratorAsync().ConfigureAwait(false);

    public async Task<bool> IsRegisteredAsync(string email)
        => await GetConversationActor(email).IsRegisteredAsync().ConfigureAwait(false);

    private IConversationActor GetConversationActor(string email) => ActorProxy.Create<IConversationActor>(new ActorId(email), nameof(ConversationActor));
}