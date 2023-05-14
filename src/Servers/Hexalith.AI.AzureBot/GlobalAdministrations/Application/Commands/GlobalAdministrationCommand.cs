// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 05-01-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 05-01-2023
// ***********************************************************************
// <copyright file="ApplicationAdministrationCommand.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Hexalith.AI.AzureBot.GlobalAdministrations.Application.Commands;

using System.ComponentModel;

using Hexalith.AI.AzureBot.ApplicationAdministrations.Domain;
using Hexalith.Application.Commands;

/// <summary>
/// Class ApplicationAdministrationCommand.
/// Implements the <see cref="BaseCommand" />.
/// </summary>
/// <seealso cref="BaseCommand" />
[Description("Global administration command")]
public class ApplicationAdministrationCommand : BaseCommand
{
    /// <summary>
    /// Defaults the aggregate identifier.
    /// </summary>
    /// <returns>System.String.</returns>
    protected override string DefaultAggregateId() => nameof(ApplicationAdministration);

    /// <summary>
    /// Defaults the name of the aggregate.
    /// </summary>
    /// <returns>System.String.</returns>
    protected override string DefaultAggregateName() => nameof(ApplicationAdministration);
}