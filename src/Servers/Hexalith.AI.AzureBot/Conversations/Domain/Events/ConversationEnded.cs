// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 04-24-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 05-02-2023
// ***********************************************************************
// <copyright file="ConversationEnded.cs" company="Fiveforty">
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
public class ConversationEnded : ConversationEvent
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ConversationEnded" /> class.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="date">The date.</param>
    [JsonConstructor]
    public ConversationEnded(string id, DateTimeOffset date)
        : base(id) => Date = date;

    /// <summary>
    /// Initializes a new instance of the <see cref="ConversationEnded" /> class.
    /// </summary>
    [Obsolete("For serialization only", true)]
    public ConversationEnded()
    {
    }

    /// <summary>
    /// Gets the date.
    /// </summary>
    /// <value>The date.</value>
    public DateTimeOffset Date { get; }
}