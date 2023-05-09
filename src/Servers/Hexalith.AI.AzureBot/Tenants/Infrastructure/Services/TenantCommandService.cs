// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 05-02-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 05-02-2023
// ***********************************************************************
// <copyright file="TenantCommandService.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.Tenants.Infrastructure.Services;

using System.Threading.Tasks;

using Hexalith.AI.AzureBot.Tenants.Application.Commands;
using Hexalith.AI.AzureBot.Tenants.Application.Services;
using Hexalith.Application.Abstractions.Commands;
using Hexalith.Application.Abstractions.Metadatas;
using Hexalith.Extensions.Common;

/// <summary>
/// Class TenantCommandService.
/// Implements the <see cref="ITenantCommandService" />.
/// </summary>
/// <seealso cref="ITenantCommandService" />
public class TenantCommandService : ITenantCommandService
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
    /// Initializes a new instance of the <see cref="TenantCommandService" /> class.
    /// </summary>
    /// <param name="commandBus">The command bus.</param>
    /// <param name="dateTimeService">The date time service.</param>
    /// <exception cref="System.ArgumentNullException"></exception>
    public TenantCommandService(ICommandBus commandBus, IDateTimeService dateTimeService)
    {
        ArgumentNullException.ThrowIfNull(commandBus);
        _commandBus = commandBus;
        _dateTimeService = dateTimeService;
    }

    /// <inheritdoc/>
    public async Task RegisterTenantAsync(
        string name,
        string domain,
        string id,
        string messageId,
        string correlationId,
        string userId,
        string sessionId,
        CancellationToken cancellationToken)
    {
        RegisterTenant message = new(name, domain, id);
        await RegisterTenantAsync(
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
    public Task RegisterTenantAsync(
      RegisterTenant message,
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