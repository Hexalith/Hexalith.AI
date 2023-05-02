// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 04-24-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 05-01-2023
// ***********************************************************************
// <copyright file="ConversationRegistered.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.Conversations.Application.Commands;

using System.Text.Json.Serialization;

using Hexalith.AI.AzureBot.Conversations.Domain.Commands;

/// <summary>
/// Class ConversationRegistered.
/// Implements the <see cref="BaseCommand" />.
/// </summary>
/// <seealso cref="BaseCommand" />
public class RegisterConversation : ConversationCommand
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RegisterConversation" /> class.
    /// </summary>
    /// <param name="email">The email.</param>
    [JsonConstructor]
    public RegisterConversation(string email)
        : base(email)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="RegisterConversation" /> class.
    /// </summary>
    [Obsolete("For serialization only", true)]
    public RegisterConversation()
    {
    }
}