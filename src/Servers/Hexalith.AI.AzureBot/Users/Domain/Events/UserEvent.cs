// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 04-24-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 05-01-2023
// ***********************************************************************
// <copyright file="UserEvent.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.Users.Domain.Events;

using System.Text.Json.Serialization;

using Hexalith.Domain.Abstractions.Events;

/// <summary>
/// Class UserEvent.
/// Implements the <see cref="BaseEvent" />.
/// </summary>
/// <seealso cref="BaseEvent" />
public class UserEvent : BaseEvent
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UserEvent" /> class.
    /// </summary>
    /// <param name="email">The email.</param>
    [JsonConstructor]
    protected UserEvent(string email) => Email = email;

    /// <summary>
    /// Initializes a new instance of the <see cref="UserEvent" /> class.
    /// </summary>
    [Obsolete("For serialization only", true)]
    protected UserEvent() => Email = string.Empty;

    /// <summary>
    /// Gets or sets the email.
    /// </summary>
    /// <value>The email.</value>
    public string Email { get; set; }

    /// <inheritdoc/>
    protected override string DefaultAggregateId() => Email;

    /// <inheritdoc/>
    protected override string DefaultAggregateName() => nameof(User);
}