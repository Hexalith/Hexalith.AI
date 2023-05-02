// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 04-24-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 05-02-2023
// ***********************************************************************
// <copyright file="ConversationItemAdded.cs" company="Fiveforty">
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
public class ConversationItemAdded : ConversationEvent
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ConversationItemAdded" /> class.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="text">The text.</param>
    /// <param name="email">The email.</param>
    /// <param name="date">The date.</param>
    [JsonConstructor]
    public ConversationItemAdded(string id, string email, string text, DateTimeOffset date)
        : base(id)
    {
        ArgumentException.ThrowIfNullOrEmpty(text);
        ArgumentException.ThrowIfNullOrEmpty(email);
        Text = text;
        Email = email;
        Date = date;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ConversationItemAdded" /> class.
    /// </summary>
    [Obsolete("For serialization only", true)]
    public ConversationItemAdded() => Email = Text = string.Empty;

    /// <summary>
    /// Gets the date.
    /// </summary>
    /// <value>The date.</value>
    public DateTimeOffset Date { get; }

    /// <summary>
    /// Gets the email.
    /// </summary>
    /// <value>The email.</value>
    public string Email { get; }

    /// <summary>
    /// Gets the text.
    /// </summary>
    /// <value>The text.</value>
    public string Text { get; }
}