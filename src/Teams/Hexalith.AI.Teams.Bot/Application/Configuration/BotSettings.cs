// ***********************************************************************
// Assembly         : Hexalith.AI.Teams.Bot
// Author           : Jérôme Piquot
// Created          : 04-18-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 04-18-2023
// ***********************************************************************
// <copyright file="BotSettings.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.Teams.Bot.Application.Configuration
{
    using Hexalith.Extensions.Configuration;

    /// <summary>
    /// Class BotSettings.
    /// Implements the <see cref="ISettings" />.
    /// </summary>
    /// <seealso cref="ISettings" />
    public class BotSettings : ISettings
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public string? Id { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        public string? Password { get; set; }

        /// <summary>
        /// Configurations the name.
        /// </summary>
        /// <returns>System.String.</returns>
        public static string ConfigurationName()
        {
            return "Bot";
        }
    }
}