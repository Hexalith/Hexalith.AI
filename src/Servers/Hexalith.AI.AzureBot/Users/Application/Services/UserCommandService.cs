// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 05-01-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 05-02-2023
// ***********************************************************************
// <copyright file="UserCommandService.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.Users.Application.Services;

using System.Threading.Tasks;

using Hexalith.AI.AzureBot.Users.Application.Commands;
using Hexalith.Application.Commands;
using Hexalith.Application.Metadatas;
using Hexalith.Extensions.Common;

/// <summary>
/// Class UserCommandService.
/// Implements the <see cref="Hexalith.AI.AzureBot.Users.Application.Services.IUserCommandService" />.
/// </summary>
/// <seealso cref="Hexalith.AI.AzureBot.Users.Application.Services.IUserCommandService" />
public class UserCommandService : IUserCommandService
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
    /// Initializes a new instance of the <see cref="UserCommandService"/> class.
    /// </summary>
    /// <param name="commandBus">The command bus.</param>
    /// <param name="dateTimeService">The date time service.</param>
    /// <exception cref="System.ArgumentNullException"></exception>
    public UserCommandService(ICommandBus commandBus, IDateTimeService dateTimeService)
    {
        ArgumentNullException.ThrowIfNull(commandBus);
        _commandBus = commandBus;
        _dateTimeService = dateTimeService;
    }

    /// <inheritdoc/>
    public async Task RegisterAsync(
        string email,
        string name,
        string userId,
        string messageId,
        string correlationId,
        string sessionId,
        CancellationToken cancellationToken)
    {
        RegisterUser message = new(email);
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
}