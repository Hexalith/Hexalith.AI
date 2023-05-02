// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 04-24-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 05-02-2023
// ***********************************************************************
// <copyright file="ConversationSummaryChanged.cs" company="Fiveforty">
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
public class ConversationSummaryChanged : ConversationEvent
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ConversationSummaryChanged" /> class.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="summary">The summary.</param>
    /// <param name="email">The email.</param>
    /// <param name="date">The date.</param>
    [JsonConstructor]
    public ConversationSummaryChanged(string id, string summary)
        : base(id)
    {
        ArgumentException.ThrowIfNullOrEmpty(summary);
        Summary = summary;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ConversationSummaryChanged" /> class.
    /// </summary>
    [Obsolete("For serialization only", true)]
    public ConversationSummaryChanged() => Summary = string.Empty;

    /// <summary>
    /// Gets the summary.
    /// </summary>
    /// <value>The summary.</value>
    public string Summary { get; }
}