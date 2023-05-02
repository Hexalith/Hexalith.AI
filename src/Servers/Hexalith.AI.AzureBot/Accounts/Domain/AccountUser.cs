// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 05-02-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 05-02-2023
// ***********************************************************************
// <copyright file="AccountUser.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.Accounts.Domain;

/// <summary>
/// Class AccountUser.
/// Implements the <see cref="System.IEquatable{Hexalith.AI.AzureBot.Accounts.Domain.AccountUser}" />.
/// </summary>
/// <seealso cref="System.IEquatable{Hexalith.AI.AzureBot.Accounts.Domain.AccountUser}" />
public record AccountUser(string Email, IEnumerable<string> Roles)
{
}