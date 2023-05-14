// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 05-02-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 05-02-2023
// ***********************************************************************
// <copyright file="AccountCommandService.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.Accounts.Infrastructure.Services;

using System.Threading.Tasks;

using Hexalith.AI.AzureBot.Accounts.Application.Commands;
using Hexalith.AI.AzureBot.Accounts.Application.Services;
using Hexalith.Application.Commands;
using Hexalith.Application.Metadatas;
using Hexalith.Extensions.Common;

/// <summary>
/// Class AccountCommandService.
/// Implements the <see cref="IAccountCommandService" />.
/// </summary>
/// <seealso cref="IAccountCommandService" />
public class AccountCommandService : IAccountCommandService
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
    /// Initializes a new instance of the <see cref="AccountCommandService" /> class.
    /// </summary>
    /// <param name="commandBus">The command bus.</param>
    /// <param name="dateTimeService">The date time service.</param>
    /// <exception cref="System.ArgumentNullException"></exception>
    public AccountCommandService(ICommandBus commandBus, IDateTimeService dateTimeService)
    {
        ArgumentNullException.ThrowIfNull(commandBus);
        _commandBus = commandBus;
        _dateTimeService = dateTimeService;
    }

    /// <inheritdoc/>
    public async Task AddUserRoleAsync(
        string account,
        string email,
        string role,
        string messageId,
        string correlationId,
        string sessionId,
        CancellationToken cancellationToken)
    {
        GrantAccountUserRole message = new(account, email, role);
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