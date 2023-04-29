// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 04-25-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 04-25-2023
// ***********************************************************************
// <copyright file="IGlobalAdministrationService.cs" company="Fiveforty S.A.S.">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.GlobalAdministrations.Application;

/// <summary>
/// Interface IGlobalAdministrationService.
/// </summary>
public interface IGlobalAdministrationService
{
    /// <summary>
    /// Determines whether [is administrator asynchronous] [the specified email].
    /// </summary>
    /// <param name="email">The email.</param>
    /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Task&lt;System.Boolean&gt;.</returns>
    Task<bool> IsAdministratorAsync(string email, CancellationToken cancellationToken);

    /// <summary>
    /// Determines whether the specified email is registered.
    /// </summary>
    /// <param name="email">The email.</param>
    /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Task&lt;System.Boolean&gt;.</returns>
    Task<bool> IsRegisteredAsync(string email, CancellationToken cancellationToken);
}