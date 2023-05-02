// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 05-01-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 05-02-2023
// ***********************************************************************
// <copyright file="TenantUserInformation.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.Tenants.Application.Models;

using System.Runtime.Serialization;

using Newtonsoft.Json;

/// <summary>
/// Class UserTenantInformation.
/// </summary>
[Serializable]
[DataContract]
public class TenantUserInformation
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TenantUserInformation" /> class.
    /// </summary>
    /// <param name="tenantId">The tenant identifier.</param>
    /// <param name="objectId">The object identifier.</param>
    /// <param name="email">The email.</param>
    /// <param name="name">The name.</param>
    [JsonConstructor]
    public TenantUserInformation(string tenantId, string objectId, string email, string name)
    {
        TenantId = tenantId;
        Name = name;
        ObjectId = objectId;
        Email = email;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="TenantUserInformation" /> class.
    /// </summary>
    [Obsolete("For serialization only", true)]
    public TenantUserInformation() => Email = TenantId = Name = ObjectId = string.Empty;

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
    public string TenantId { get; set; }
}