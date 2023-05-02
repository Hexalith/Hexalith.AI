// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 04-24-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 05-01-2023
// ***********************************************************************
// <copyright file="ConversationCommand.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.Conversations.Domain.Commands;

using System.Text.Json.Serialization;

using Hexalith.Application.Abstractions.Commands;

/// <summary>
/// Class ConversationCommand.
/// Implements the <see cref="BaseCommand" />.
/// </summary>
/// <seealso cref="BaseCommand" />
public class ConversationCommand : BaseCommand
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ConversationCommand" /> class.
    /// </summary>
    /// <param name="email">The email.</param>
    [JsonConstructor]
    protected ConversationCommand(string email) => Email = email;

    /// <summary>
    /// Initializes a new instance of the <see cref="ConversationCommand" /> class.
    /// </summary>
    [Obsolete("For serialization only", true)]
    protected ConversationCommand() => Email = string.Empty;

    /// <summary>
    /// Gets or sets the email.
    /// </summary>
    /// <value>The email.</value>
    public string Email { get; set; }

    /// <inheritdoc/>
    protected override string DefaultAggregateId() => Email;

    /// <inheritdoc/>
    protected override string DefaultAggregateName() => nameof(Conversation);
}