// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 04-24-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 05-02-2023
// ***********************************************************************
// <copyright file="ConversationTitleChanged.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.Conversations.Domain.Events;

using System.Text.Json.Serialization;

/// <summary>
/// Class ConversationRegistered.
/// Implements the <see cref="BaseEvent" />.
/// </summary>
/// <seealso cref="BaseEvent" />
public class ConversationTitleChanged : ConversationEvent
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ConversationTitleChanged" /> class.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="title">The title.</param>
    /// <param name="email">The email.</param>
    /// <param name="date">The date.</param>
    [JsonConstructor]
    public ConversationTitleChanged(string id, string title)
        : base(id)
    {
        ArgumentException.ThrowIfNullOrEmpty(title);
        Title = title;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ConversationTitleChanged" /> class.
    /// </summary>
    [Obsolete("For serialization only", true)]
    public ConversationTitleChanged() => Title = string.Empty;

    /// <summary>
    /// Gets the title.
    /// </summary>
    /// <value>The title.</value>
    public string Title { get; }
}