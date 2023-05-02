// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 05-01-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 05-01-2023
// ***********************************************************************
// <copyright file="ConversationAccount.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.Conversations.Domain;

using System.Runtime.Serialization;

/// <summary>
/// Class ConversationAccount.
/// </summary>
[DataContract]
public class ConversationAccount
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ConversationAccount" /> class.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <param name="roles">The roles.</param>
    /// <param name="authentications">The authentications.</param>
    public ConversationAccount(string name, IEnumerable<string> roles, IEnumerable<ConversationAuthentication> authentications)
    {
        Name = name;
        Roles = roles;
        Authentications = authentications;
    }

    /// <summary>
    /// Gets the authentications.
    /// </summary>
    /// <value>The authentications.</value>
    public IEnumerable<ConversationAuthentication> Authentications { get; }

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