// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 04-24-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 05-02-2023
// ***********************************************************************
// <copyright file="EndConversation.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.Conversations.Application.Commands;

using System.ComponentModel;
using System.Text.Json.Serialization;

/// <summary>
/// Class ConversationRegistered.
/// Implements the <see cref="BaseCommand" />.
/// </summary>
/// <seealso cref="BaseCommand" />
[Description("End a conversation")]
public class EndConversation : ConversationCommand
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EndConversation" /> class.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="account">The account.</param>
    /// <param name="email">The email.</param>
    /// <param name="text">The text.</param>
    /// <param name="date">The date.</param>
    [JsonConstructor]
    public EndConversation(string id, DateTimeOffset date)
        : base(id) => Date = date;

    /// <summary>
    /// Initializes a new instance of the <see cref="EndConversation" /> class.
    /// </summary>
    [Obsolete("For serialization only", true)]
    public EndConversation()
    {
    }

    /// <summary>
    /// Gets the date.
    /// </summary>
    /// <value>The date.</value>
    public DateTimeOffset Date { get; }
}