// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 05-02-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 05-02-2023
// ***********************************************************************
// <copyright file="TenantUser.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.Tenants.Domain;

/// <summary>
/// Class TenantUser.
/// Implements the <see cref="System.IEquatable{Hexalith.AI.AzureBot.Tenants.Domain.TenantUser}" />.
/// </summary>
/// <seealso cref="System.IEquatable{Hexalith.AI.AzureBot.Tenants.Domain.TenantUser}" />
public record TenantUser(string ObjectId, string Name, string Email)
{
}