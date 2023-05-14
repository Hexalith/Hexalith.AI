// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 05-02-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 05-02-2023
// ***********************************************************************
// <copyright file="ConversationCommandService.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.Conversations.Infrastructure.Services;

using System.Threading.Tasks;

using Hexalith.AI.AzureBot.Conversations.Application.Commands;
using Hexalith.AI.AzureBot.Conversations.Application.Services;
using Hexalith.Application.Commands;
using Hexalith.Application.Metadatas;
using Hexalith.Extensions.Common;

/// <summary>
/// Class ConversationCommandService.
/// Implements the <see cref="IConversationCommandService" />.
/// </summary>
/// <seealso cref="IConversationCommandService" />
public class ConversationCommandService : IConversationCommandService
{
    /// <summary>
    /// The command bus.
    /// </summary>
    private readonly ICommandBus _commandBus;

    /// <summary>
    /// The date time service.
    /// </summary>
    private readonly IDateTimeService _dateTimeService;

    /// <summary>
    /// Initializes a new instance of the <see cref="ConversationCommandService" /> class.
    /// </summary>
    /// <param name="commandBus">The command bus.</param>
    /// <param name="dateTimeService">The date time service.</param>
    /// <exception cref="System.ArgumentNullException"></exception>
    public ConversationCommandService(ICommandBus commandBus, IDateTimeService dateTimeService)
    {
        ArgumentNullException.ThrowIfNull(commandBus);
        _commandBus = commandBus;
        _dateTimeService = dateTimeService;
    }

    /// <inheritdoc/>
    public async Task StartConversationAsync(
        string id,
        string email,
        string account,
        string text,
        DateTimeOffset startedDate,
        string messageId,
        string correlationId,
        string sessionId,
        CancellationToken cancellationToken)
    {
        StartConversation message = new(id, account, email, text, startedDate);
        await _commandBus
            .PublishAsync(
                message,
                new Metadata(
                    messageId,
                    message,
                    _dateTimeService.Now,
                    new(correlationId, email, _dateTimeService.Now, null, sessionId),
                    null),
                cancellationToken)
            .ConfigureAwait(false);
    }
}