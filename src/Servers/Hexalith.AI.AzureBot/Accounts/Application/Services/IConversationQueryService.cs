// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 05-01-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 05-02-2023
// ***********************************************************************
// <copyright file="IConversationQueryService.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.Accounts.Application.Services;

/// <summary>
/// Interface IAccountQueryService.
/// </summary>
public interface IAccountQueryService
{
    /// <summary>
    /// Determines whether [is account user asynchronous] [the specified account].
    /// </summary>
    /// <param name="account">The account.</param>
    /// <param name="email">The email.</param>
    /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>System.Threading.Tasks.Task&lt;bool&gt;.</returns>
    Task<bool> IsAccountUserAsync(string account, string email, CancellationToken cancellationToken);
}