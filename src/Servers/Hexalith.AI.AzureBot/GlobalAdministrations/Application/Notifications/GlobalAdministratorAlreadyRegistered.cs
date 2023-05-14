// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 04-25-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 04-25-2023
// ***********************************************************************
// <copyright file="GlobalAdministratorAlreadyRegistered.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.ApplicationAdministrations.Application.Notifications;

using System.Text.Json.Serialization;

using Hexalith.Application.Notifications;

/// <summary>
/// Class GlobalAdministratorAlreadyRegistered.
/// Implements the <see cref="BaseNotification" />.
/// </summary>
/// <seealso cref="BaseNotification" />
public class GlobalAdministratorAlreadyRegistered : BaseNotification
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GlobalAdministratorAlreadyRegistered" /> class.
    /// </summary>
    /// <param name="email">The email.</param>
    /// <param name="name">The name.</param>
    public GlobalAdministratorAlreadyRegistered(string email)
        : base($"User {email} already registered", $"The global administrator with the email '{email}' address has already been registered.", NotificationSeverity.Warning, null) => Email = email;

    /// <summary>
    /// Initializes a new instance of the <see cref="GlobalAdministratorAlreadyRegistered"/> class.
    /// </summary>
    /// <param name="email">The email.</param>
    /// <param name="title">The title.</param>
    /// <param name="message">The message.</param>
    /// <param name="severity">The severity.</param>
    /// <param name="technicalDescription">The technical description.</param>
    [JsonConstructor]
    public GlobalAdministratorAlreadyRegistered(string email, string title, string message, NotificationSeverity severity, string? technicalDescription)
        : base(title, message, severity, technicalDescription) => Email = email;

    /// <summary>
    /// Initializes a new instance of the <see cref="GlobalAdministratorAlreadyRegistered"/> class.
    /// </summary>
    [Obsolete("For serialization only", true)]
    public GlobalAdministratorAlreadyRegistered() => Email = string.Empty;

    /// <summary>
    /// Gets or sets the email.
    /// </summary>
    /// <value>The email.</value>
    public string Email { get; set; }
}