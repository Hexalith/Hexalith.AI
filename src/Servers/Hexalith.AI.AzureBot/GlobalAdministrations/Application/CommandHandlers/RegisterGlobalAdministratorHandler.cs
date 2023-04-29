// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 04-25-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 04-25-2023
// ***********************************************************************
// <copyright file="RegisterGlobalAdministratorHandler.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.GlobalAdministrations.Application.CommandHandlers;

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

using Hexalith.AI.AzureBot.GlobalAdministrations.Application.Commands;
using Hexalith.AI.AzureBot.GlobalAdministrations.Application.Notifications;
using Hexalith.AI.AzureBot.GlobalAdministrations.Domain.Events;
using Hexalith.Application.Abstractions.Commands;
using Hexalith.Domain.Abstractions.Messages;
using Hexalith.Extensions.Helpers;

/// <summary>
/// Class RegisterGlobalAdministratorHandler.
/// Implements the <see cref="Hexalith.Application.Abstractions.Commands.CommandHandler{Hexalith.AI.AzureBot.GlobalAdministrations.Application.Commands.RegisterGlobalAdministrator}" />.
/// </summary>
/// <seealso cref="Hexalith.Application.Abstractions.Commands.CommandHandler{Hexalith.AI.AzureBot.GlobalAdministrations.Application.Commands.RegisterGlobalAdministrator}" />
public class RegisterGlobalAdministratorHandler : CommandHandler<RegisterGlobalAdministrator>
{
    /// <summary>
    /// The global administration service.
    /// </summary>
    private readonly IGlobalAdministrationService _globalAdministrationService;

    /// <summary>
    /// Initializes a new instance of the <see cref="RegisterGlobalAdministratorHandler" /> class.
    /// </summary>
    /// <param name="globalAdministrationService">The global administration service.</param>
    /// <exception cref="System.ArgumentNullException"></exception>
    public RegisterGlobalAdministratorHandler([NotNull] IGlobalAdministrationService globalAdministrationService)
    {
        ArgumentNullException.ThrowIfNull(globalAdministrationService);
        _globalAdministrationService = globalAdministrationService;
    }

    /// <inheritdoc/>
    public override async Task<IEnumerable<BaseMessage>> DoAsync(RegisterGlobalAdministrator command, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(command);
        ArgumentException.ThrowIfNullOrEmpty(command.Email);
        return await _globalAdministrationService.IsRegisteredAsync(command.Email, cancellationToken).ConfigureAwait(false)
            ? new GlobalAdministratorAlreadyRegistered(command.Email, command.Name).IntoArray()
            : new GlobalAdministratorRegistered(command.Email, command.Name).IntoArray();
    }

    /// <inheritdoc/>
    public override Task<IEnumerable<BaseMessage>> UndoAsync(RegisterGlobalAdministrator command, CancellationToken cancellationToken) => throw new NotSupportedException();
}