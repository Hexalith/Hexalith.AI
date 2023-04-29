// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 04-25-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 04-25-2023
// ***********************************************************************
// <copyright file="IGlobalAdministrationActor.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.GlobalAdministrations.Infrastructure.Actors;

using System.Threading.Tasks;

using Dapr.Actors;

/// <summary>
/// Interface IGlobalAdministrationActor
/// Extends the <see cref="IActor" />.
/// </summary>
/// <seealso cref="IActor" />
public interface IGlobalAdministrationActor : IActor
{
    /// <summary>
    /// Administrators the count asynchronous.
    /// </summary>
    /// <returns>Task&lt;System.Int32&gt;.</returns>
    Task<int> AdministratorCountAsync();

    /// <summary>
    /// Determines whether [is administrator asynchronous] [the specified email].
    /// </summary>
    /// <param name="email">The email.</param>
    /// <returns>Task&lt;System.Boolean&gt;.</returns>
    Task<bool> IsAdministratorAsync(string email);

    /// <summary>
    /// Determines whether [is registered asynchronous] [the specified email].
    /// </summary>
    /// <param name="email">The email.</param>
    /// <returns>Task&lt;System.Boolean&gt;.</returns>
    Task<bool> IsRegisteredAsync(string email);
}