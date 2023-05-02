namespace Hexalith.AI.AzureBot.GlobalAdministrations.Application.Services;

using System.Threading.Tasks;

using Dapr.Actors;
using Dapr.Actors.Client;

using Hexalith.AI.AzureBot.GlobalAdministrations.Domain;
using Hexalith.AI.AzureBot.GlobalAdministrations.Infrastructure.Actors;

public class GlobalAdministrationQueryService : IGlobalAdministrationQueryService
{
    private readonly IGlobalAdministrationActor? _globalAdministrationActor;

    private IGlobalAdministrationActor GlobalAdministrationActor
                => _globalAdministrationActor
            ?? ActorProxy.Create<IGlobalAdministrationActor>(
                new ActorId(nameof(GlobalAdministration)),
                nameof(GlobalAdministrationActor));

    public async Task<bool> IsAdministratorAsync(string email)
                => await GlobalAdministrationActor
                .IsAdministratorAsync(email)
                .ConfigureAwait(false);
}