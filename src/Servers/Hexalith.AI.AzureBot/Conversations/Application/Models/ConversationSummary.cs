// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 05-02-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 05-02-2023
// ***********************************************************************
// <copyright file="ConversationSummary.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.Conversations.Application.Models;

using System.Runtime.Serialization;

/// <summary>
/// Class ConversationSummary.
/// </summary>
[DataContract]
public class ConversationSummary
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ConversationSummary"/> class.
    /// </summary>
    [Obsolete("For serialization only", true)]
    public ConversationSummary() => Id = Title = Summary = string.Empty;

    /// <summary>
    /// Initializes a new instance of the <see cref="ConversationSummary"/> class.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="title">The title.</param>
    /// <param name="summary">The summary.</param>
    /// <param name="dateStarted">The date started.</param>
    /// <param name="dateEnded">The date ended.</param>
    public ConversationSummary(string id, string title, string summary, DateTimeOffset dateStarted, DateTimeOffset? dateEnded)
    {
        Id = id;
        Title = title;
        Summary = summary;
        DateStarted = dateStarted;
        DateEnded = dateEnded;
    }

    /// <summary>
    /// Gets or sets the date ended.
    /// </summary>
    /// <value>The date ended.</value>
    public DateTimeOffset? DateEnded { get; set; }

    /// <summary>
    /// Gets or sets the date started.
    /// </summary>
    /// <value>The date started.</value>
    public DateTimeOffset DateStarted { get; set; }

    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    /// <value>The identifier.</value>
    public string Id { get; set; }

    /// <summary>
    /// Gets or sets the summary.
    /// </summary>
    /// <value>The summary.</value>
    public string Summary { get; set; }

    /// <summary>
    /// Gets or sets the title.
    /// </summary>
    /// <value>The title.</value>
    public string Title { get; set; }
}