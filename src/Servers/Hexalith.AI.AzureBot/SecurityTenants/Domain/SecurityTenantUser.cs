// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 05-02-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 05-02-2023
// ***********************************************************************
// <copyright file="SecurityTenantUser.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.SecurityTenants.Domain;

/// <summary>
/// Class SecurityTenantUser.
/// Implements the <see cref="System.IEquatable{Hexalith.AI.AzureBot.SecurityTenants.Domain.SecurityTenantUser}" />.
/// </summary>
/// <seealso cref="System.IEquatable{Hexalith.AI.AzureBot.SecurityTenants.Domain.SecurityTenantUser}" />
public record SecurityTenantUser(string ObjectId, string Name, string Email)
{
}