// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 05-01-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 05-02-2023
// ***********************************************************************
// <copyright file="SecurityTenantUserInformation.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.SecurityTenants.Application.Models;

using System.Runtime.Serialization;

using Newtonsoft.Json;

/// <summary>
/// Class UserSecurityTenantInformation.
/// </summary>
[Serializable]
[DataContract]
public class SecurityTenantUserInformation
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SecurityTenantUserInformation" /> class.
    /// </summary>
    /// <param name="tenantId">The tenant identifier.</param>
    /// <param name="objectId">The object identifier.</param>
    /// <param name="email">The email.</param>
    /// <param name="name">The name.</param>
    [JsonConstructor]
    public SecurityTenantUserInformation(string tenantId, string objectId, string email, string name)
    {
        SecurityTenantId = tenantId;
        Name = name;
        ObjectId = objectId;
        Email = email;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SecurityTenantUserInformation" /> class.
    /// </summary>
    [Obsolete("For serialization only", true)]
    public SecurityTenantUserInformation() => Email = SecurityTenantId = Name = ObjectId = string.Empty;

    /// <summary>
    /// Gets the email.
    /// </summary>
    /// <value>The email.</value>
    public string Email { get; }

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>The name.</value>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the id.
    /// </summary>
    /// <value>The id.</value>
    public string ObjectId { get; set; }

    /// <summary>
    /// Gets or sets the account identifier.
    /// </summary>
    /// <value>The account identifier.</value>
    public string SecurityTenantId { get; set; }
}