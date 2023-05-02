namespace Hexalith.AI.AzureBot.GlobalAdministrations.Application.Commands;

using Hexalith.AI.AzureBot.GlobalAdministrations.Domain;
using Hexalith.Application.Abstractions.Commands;

public class GlobalAdministrationCommand : BaseCommand
{
    protected override string DefaultAggregateId() => nameof(GlobalAdministration);

    protected override string DefaultAggregateName() => nameof(GlobalAdministration);
}