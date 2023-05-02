namespace Hexalith.AI.AzureBot.Users.Application.Services;

using System.Threading.Tasks;

using Dapr.Actors;
using Dapr.Actors.Client;

using Hexalith.AI.AzureBot.Users.Infrastructure.Actors;

public class UserQueryService : IUserQueryService
{
    public async Task<bool> IsGlobalAdministratorAsync(string email)
        => await GetUserActor(email).IsGlobalAdministratorAsync().ConfigureAwait(false);

    public async Task<bool> IsRegisteredAsync(string email)
        => await GetUserActor(email).IsRegisteredAsync().ConfigureAwait(false);

    private IUserActor GetUserActor(string email) => ActorProxy.Create<IUserActor>(new ActorId(email), nameof(UserActor));
}