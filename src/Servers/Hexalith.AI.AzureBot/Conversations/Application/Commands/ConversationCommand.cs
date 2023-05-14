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
namespace Hexalith.AI.AzureBot.Conversations.Application.Commands;

using System.ComponentModel;
using System.Text.Json.Serialization;

using Hexalith.AI.AzureBot.Conversations.Domain;

using Hexalith.Application.Commands;

/// <summary>
/// Class ConversationCommand.
/// Implements the <see cref="BaseCommand" />.
/// </summary>
/// <seealso cref="BaseCommand" />
[Description("Conversation command")]
public abstract class ConversationCommand : BaseCommand
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ConversationCommand" /> class.
    /// </summary>
    /// <param name="id">The id.</param>
    [JsonConstructor]
    protected ConversationCommand(string id) => Id = id;

    /// <summary>
    /// Initializes a new instance of the <see cref="ConversationCommand" /> class.
    /// </summary>
    [Obsolete("For serialization only", true)]
    protected ConversationCommand() => Id = string.Empty;

    /// <summary>
    /// Gets or sets the id.
    /// </summary>
    /// <value>The id.</value>
    public string Id { get; set; }

    /// <inheritdoc/>
    protected override string DefaultAggregateId() => Id;

    /// <inheritdoc/>
    protected override string DefaultAggregateName() => nameof(Conversation);
}