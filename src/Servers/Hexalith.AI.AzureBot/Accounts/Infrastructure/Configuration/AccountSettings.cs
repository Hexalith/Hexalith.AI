// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 04-25-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 04-26-2023
// ***********************************************************************
// <copyright file="AccountSettings.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.Accounts.Infrastructure.Actors;

using Hexalith.AI.AzureBot.Accounts.Domain;
using Hexalith.Application.Abstractions.Tasks;
using Hexalith.Extensions.Configuration;

/// <summary>
/// Class AccountSettings.
/// </summary>
public class AccountSettings : ISettings
{
    /// <summary>
    /// Gets the execute command resiliency policy.
    /// </summary>
    /// <value>The execute command resiliency policy.</value>
    public ResiliencyPolicy? ExecuteCommandResiliencyPolicy { get; internal set; }

    /// <summary>
    /// Configurations the name.
    /// </summary>
    /// <returns>System.String.</returns>
    public static string ConfigurationName() => nameof(Account);
}