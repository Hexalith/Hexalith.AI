// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 05-02-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 05-02-2023
// ***********************************************************************
// <copyright file="SecurityTenantCommandService.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.SecurityTenants.Infrastructure.Services;

using System.Threading.Tasks;

using Hexalith.AI.AzureBot.SecurityTenants.Application.Commands;
using Hexalith.AI.AzureBot.SecurityTenants.Application.Services;
using Hexalith.Application.Commands;
using Hexalith.Application.Metadatas;
using Hexalith.Extensions.Common;

/// <summary>
/// Class SecurityTenantCommandService.
/// Implements the <see cref="ISecurityTenantCommandService" />.
/// </summary>
/// <seealso cref="ISecurityTenantCommandService" />
public class SecurityTenantCommandService : ISecurityTenantCommandService
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
    /// Initializes a new instance of the <see cref="SecurityTenantCommandService" /> class.
    /// </summary>
    /// <param name="commandBus">The command bus.</param>
    /// <param name="dateTimeService">The date time service.</param>
    /// <exception cref="System.ArgumentNullException"></exception>
    public SecurityTenantCommandService(ICommandBus commandBus, IDateTimeService dateTimeService)
    {
        ArgumentNullException.ThrowIfNull(commandBus);
        _commandBus = commandBus;
        _dateTimeService = dateTimeService;
    }

    /// <inheritdoc/>
    public async Task RegisterSecurityTenantAsync(
        string name,
        string domain,
        string id,
        string messageId,
        string correlationId,
        string userId,
        string sessionId,
        CancellationToken cancellationToken)
    {
        RegisterSecurityTenant message = new(name, domain, id);
        await RegisterSecurityTenantAsync(
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
    public Task RegisterSecurityTenantAsync(
      RegisterSecurityTenant message,
      Metadata metadata,
      CancellationToken cancellationToken)
    {
        return _commandBus
            .PublishAsync(
                message,
                metadata,
                cancellationToken);
    }
}