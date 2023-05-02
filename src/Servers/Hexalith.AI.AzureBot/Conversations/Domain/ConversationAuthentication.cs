// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 05-01-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 05-01-2023
// ***********************************************************************
// <copyright file="ConversationAuthentication.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.Conversations.Domain;

using System.Runtime.Serialization;

/// <summary>
/// Class ConversationAuthentication.
/// </summary>
[DataContract]
public class ConversationAuthentication
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ConversationAuthentication" /> class.
    /// </summary>
    /// <param name="providerName">Name of the provider.</param>
    /// <param name="userId">The user identifier.</param>
    public ConversationAuthentication(string providerName, string userId)
    {
        ArgumentException.ThrowIfNullOrEmpty(providerName);
        ArgumentException.ThrowIfNullOrEmpty(userId);
        ProviderName = providerName;
        ConversationId = userId;
    }

    /// <summary>
    /// Gets or sets the name of the provider.
    /// </summary>
    /// <value>The name of the provider.</value>
    public string ProviderName { get; set; }

    /// <summary>
    /// Gets the user identifier.
    /// </summary>
    /// <value>The user identifier.</value>
    public string ConversationId { get; }
}