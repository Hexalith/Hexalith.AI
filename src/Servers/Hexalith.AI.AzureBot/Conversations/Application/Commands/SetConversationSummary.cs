// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 04-24-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 05-02-2023
// ***********************************************************************
// <copyright file="SetConversationTitle - Copy.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.Conversations.Application.Commands;

using System.Text.Json.Serialization;

/// <summary>
/// Class ConversationRegistered.
/// Implements the <see cref="BaseCommand" />.
/// </summary>
/// <seealso cref="BaseCommand" />
public class SetConversationSummary : ConversationCommand
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SetConversationSummary" /> class.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="summary">The summary.</param>
    [JsonConstructor]
    public SetConversationSummary(string id, string summary)
        : base(id)
    {
        ArgumentException.ThrowIfNullOrEmpty(summary);
        Summary = summary;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SetConversationSummary" /> class.
    /// </summary>
    [Obsolete("For serialization only", true)]
    public SetConversationSummary() => Summary = string.Empty;

    /// <summary>
    /// Gets the Summary.
    /// </summary>
    /// <value>The Summary.</value>
    public string Summary { get; }
}