namespace Hexalith.AI.AzureBot.Conversations.Infrastructure.Services;

using System.Threading.Tasks;

using Hexalith.AI.AzureBot.Conversations.Application.Commands;
using Hexalith.AI.AzureBot.Conversations.Application.Services;
using Hexalith.Application.Abstractions.Commands;
using Hexalith.Application.Abstractions.Metadatas;
using Hexalith.Extensions.Common;

public class ConversationCommandService : IConversationCommandService
{
    private readonly ICommandBus _commandBus;
    private readonly IDateTimeService _dateTimeService;

    public ConversationCommandService(ICommandBus commandBus, IDateTimeService dateTimeService)
    {
        ArgumentNullException.ThrowIfNull(commandBus);
        _commandBus = commandBus;
        _dateTimeService = dateTimeService;
    }

    public async Task GrantGlobalAdministratorRoleAsync(
        string email,
        string userId,
        string messageId,
        string correlationId,
        string sessionId,
        CancellationToken cancellationToken)
    {
        StartConversation message = new(email);
        await _commandBus
            .PublishAsync(
                message,
                new Metadata(
                    messageId,
                    message,
                    _dateTimeService.Now,
                    new(correlationId, userId, _dateTimeService.Now, null, sessionId),
                    null),
                cancellationToken)
            .ConfigureAwait(false);
    }

    public Task GrantGlobalAdministratorRoleAsync(string email, string correlationId, CancellationToken cancellationToken) => throw new NotImplementedException();

    public async Task RegisterAsync(
                string email,
        string userId,
        string messageId,
        string correlationId,
        string sessionId,
        CancellationToken cancellationToken)
    {
        StartConversation message = new(email);
        await _commandBus
            .PublishAsync(
                message,
                new Metadata(
                    messageId,
                    message,
                    _dateTimeService.Now,
                    new(correlationId, userId, _dateTimeService.Now, null, sessionId),
                    null),
                cancellationToken)
            .ConfigureAwait(false);
    }

    public Task RegisterAsync(string email, string correlationId, CancellationToken cancellationToken) => throw new NotImplementedException();
}