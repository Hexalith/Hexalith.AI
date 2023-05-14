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
namespace Hexalith.AI.AzureBot.ApplicationAdministrations.Domain.Events;

using Hexalith.Domain.Events;

/// <summary>
/// Class GlobalAdministratorRegistered.
/// Implements the <see cref="BaseEvent" />.
/// </summary>
/// <seealso cref="BaseEvent" />
public class GlobalAdministratorRegistered : BaseEvent
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GlobalAdministratorRegistered"/> class.
    /// </summary>
    /// <param name="email">The email.</param>
    /// <param name="name">The name.</param>
    public GlobalAdministratorRegistered(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            throw new ArgumentNullException(nameof(email));
        }

        Email = email.ToUpperInvariant();
    }

    /// <summary>
    /// Gets or sets the email.
    /// </summary>
    /// <value>The email.</value>
    public string Email { get; set; }
}