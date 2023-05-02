// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 05-01-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 05-01-2023
// ***********************************************************************
// <copyright file="UserAccount.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.Users.Domain;

using System.Runtime.Serialization;

/// <summary>
/// Class UserAccount.
/// </summary>
[DataContract]
public class UserAccount
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UserAccount" /> class.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <param name="roles">The roles.</param>
    /// <param name="authentications">The authentications.</param>
    public UserAccount(string name, IEnumerable<string> roles, IEnumerable<UserAuthentication> authentications)
    {
        Name = name;
        Roles = roles;
        Authentications = authentications;
    }

    /// <summary>
    /// Gets the authentications.
    /// </summary>
    /// <value>The authentications.</value>
    public IEnumerable<UserAuthentication> Authentications { get; }

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>The name.</value>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the roles.
    /// </summary>
    /// <value>The roles.</value>
    public IEnumerable<string> Roles { get; set; }
}