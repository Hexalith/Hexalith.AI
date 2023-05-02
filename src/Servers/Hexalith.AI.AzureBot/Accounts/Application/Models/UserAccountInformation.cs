// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 05-01-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 05-01-2023
// ***********************************************************************
// <copyright file="UserAccountInformation.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.Accounts.Application.Models;

/// <summary>
/// Class UserAccountInformation.
/// </summary>
public class UserAccountInformation
{
    /// <summary>
    /// Gets or sets the account identifier.
    /// </summary>
    /// <value>The account identifier.</value>
    public string? AccountId { get; set; }

    /// <summary>
    /// Gets or sets the accounts.
    /// </summary>
    /// <value>The accounts.</value>
    public IEnumerable<string>? Accounts { get; set; }

    /// <summary>
    /// Gets or sets the administrators.
    /// </summary>
    /// <value>The administrators.</value>
    public IEnumerable<string>? Administrators { get; set; }

    /// <summary>
    /// Gets or sets the domain.
    /// </summary>
    /// <value>The domain.</value>
    public string? Domain { get; set; }

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>The name.</value>
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets the tenants.
    /// </summary>
    /// <value>The tenants.</value>
    public IEnumerable<string>? Tenants { get; set; }
}