// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 04-24-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 05-02-2023
// ***********************************************************************
// <copyright file="SetConversationTitle.cs" company="Fiveforty">
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
public class SetConversationTitle : ConversationCommand
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SetConversationTitle" /> class.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="title">The title.</param>
    [JsonConstructor]
    public SetConversationTitle(string id, string title)
        : base(id)
    {
        ArgumentException.ThrowIfNullOrEmpty(title);
        Title = title;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SetConversationTitle" /> class.
    /// </summary>
    [Obsolete("For serialization only", true)]
    public SetConversationTitle() => Title = string.Empty;

    /// <summary>
    /// Gets the Title.
    /// </summary>
    /// <value>The Title.</value>
    public string Title { get; }
}