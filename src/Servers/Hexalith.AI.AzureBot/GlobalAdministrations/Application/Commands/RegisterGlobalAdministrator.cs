// ***********************************************************************
// Assembly         :
// Author           : Jérôme Piquot
// Created          : 04-25-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 04-25-2023
// ***********************************************************************
// <copyright file="GlobalAdministratorRegistered.cs" company="Fiveforty S.A.S.">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Hexalith.AI.AzureBot.ApplicationAdministrations.Application.Commands;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

using Hexalith.AI.AzureBot.GlobalAdministrations.Application.Commands;
using Hexalith.Domain.Events;

/// <summary>
/// Class GlobalAdministratorRegistered.
/// Implements the <see cref="BaseEvent" />.
/// </summary>
/// <seealso cref="BaseEvent" />
[DisplayName("Register global administrator")]
[Description("Register a user as a global administrator")]
public class RegisterGlobalAdministrator : ApplicationAdministrationCommand
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RegisterGlobalAdministrator"/> class.
    /// </summary>
    /// <param name="email">The email.</param>
    [JsonConstructor]
    public RegisterGlobalAdministrator(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            throw new ArgumentException("Is null or empty.", nameof(email));
        }

        Email = email;
    }

    /// <summary>
    /// Gets or sets the email.
    /// </summary>
    /// <value>The email.</value>
    [DisplayName("Administrator email")]
    [Description("The email of the global administrator to register")]
    [DefaultValue("john.doe@microsoft.com")]
    [Required]
    [EmailAddress]
    [MaxLength(256)]
    public string Email { get; set; }
}