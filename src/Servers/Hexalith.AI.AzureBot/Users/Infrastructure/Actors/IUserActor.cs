// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 04-25-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 05-01-2023
// ***********************************************************************
// <copyright file="IUserActor.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.Users.Infrastructure.Actors;

using System.Threading.Tasks;

using Dapr.Actors;

/// <summary>
/// Interface IUserActor
/// Extends the <see cref="IActor" />.
/// </summary>
/// <seealso cref="IActor" />
public interface IUserActor : IActor
{
    /// <summary>
    /// Gets the roles asynchronous.
    /// </summary>
    /// <param name="account">The account.</param>
    /// <returns>Task&lt;IEnumerable&lt;System.String&gt;&gt;.</returns>
    Task<IEnumerable<string>> GetRolesAsync(string account);

    /// <summary>
    /// Determines whether [is global administrator asynchronous].
    /// </summary>
    /// <returns>Task&lt;System.Boolean&gt;.</returns>
    Task<bool> IsGlobalAdministratorAsync();

    /// <summary>
    /// Determines whether [is registered asynchronous] [the specified email].
    /// </summary>
    /// <returns>Task&lt;System.Boolean&gt;.</returns>
    Task<bool> IsRegisteredAsync();
}