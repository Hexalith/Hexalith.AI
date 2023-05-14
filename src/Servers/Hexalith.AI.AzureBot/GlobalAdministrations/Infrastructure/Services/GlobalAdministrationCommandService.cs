// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 05-02-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 05-02-2023
// ***********************************************************************
// <copyright file="ApplicationAdministrationCommandService.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.ApplicationAdministrations.Infrastructure.Services;

using Hexalith.AI.AzureBot.ApplicationAdministrations.Application.Commands;
using Hexalith.AI.AzureBot.ApplicationAdministrations.Application.Services;
using Hexalith.Application.Commands;
using Hexalith.Application.Metadatas;
using Hexalith.Extensions.Common;
using Hexalith.Extensions.Helpers;

/// <summary>
/// Class ApplicationAdministrationCommandService.
/// Implements the <see cref="IApplicationAdministrationCommandService" />.
/// </summary>
/// <seealso cref="IApplicationAdministrationCommandService" />
public class ApplicationAdministrationCommandService : IApplicationAdministrationCommandService
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
    /// Initializes a new instance of the <see cref="ApplicationAdministrationCommandService" /> class.
    /// </summary>
    /// <param name="commandBus">The command bus.</param>
    /// <param name="dateTimeService">The date time service.</param>
    /// <exception cref="System.ArgumentNullException"></exception>
    public ApplicationAdministrationCommandService(ICommandBus commandBus, IDateTimeService dateTimeService)
    {
        ArgumentNullException.ThrowIfNull(commandBus);
        _commandBus = commandBus;
        _dateTimeService = dateTimeService;
    }

    /// <inheritdoc/>
    public async Task DoAsync(RegisterGlobalAdministrator command, Metadata metadata, CancellationToken cancellationToken)
    {
        await _commandBus
            .PublishAsync(
                command,
                metadata,
                cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task RegisterGlobalAdministratorAsync(
        string email,
        string userId,
        string messageId,
        string correlationId,
        string sessionId,
        CancellationToken cancellationToken)
    {
        RegisterGlobalAdministrator message = new(email);
        await DoAsync(
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

    /// <inheritdoc/>
    public async Task RegisterGlobalAdministratorAsync(string email, string userId, CancellationToken cancellationToken)
    {
        string id = UniqueIdHelper.GenerateUniqueStringId();
        await RegisterGlobalAdministratorAsync(email, userId, id, id, id, cancellationToken).ConfigureAwait(false);
    }
}