// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 05-01-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 05-01-2023
// ***********************************************************************
// <copyright file="GlobalAdministrationCommand.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.GlobalAdministrations.Application.Commands;

using Hexalith.AI.AzureBot.GlobalAdministrations.Domain;
using Hexalith.Application.Abstractions.Commands;

/// <summary>
/// Class GlobalAdministrationCommand.
/// Implements the <see cref="BaseCommand" />.
/// </summary>
/// <seealso cref="BaseCommand" />
public class GlobalAdministrationCommand : BaseCommand
{
    /// <summary>
    /// Defaults the aggregate identifier.
    /// </summary>
    /// <returns>System.String.</returns>
    protected override string DefaultAggregateId() => nameof(GlobalAdministration);

    /// <summary>
    /// Defaults the name of the aggregate.
    /// </summary>
    /// <returns>System.String.</returns>
    protected override string DefaultAggregateName() => nameof(GlobalAdministration);
}