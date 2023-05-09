// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 04-29-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 04-29-2023
// ***********************************************************************
// <copyright file="EchoModel.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Hexalith.AI.AzureBot.GlobalAdministrations.Infrastructure.Bot.Models;

/// <summary>
/// Class EchoModel.
/// </summary>
public class RegisterGlobalAdministratorModel
{
    /// <summary>
    /// Gets or sets the body.
    /// </summary>
    /// <value>The body.</value>
    public string? Body { get; set; }

    /// <summary>
    /// Gets or sets the title.
    /// </summary>
    /// <value>The title.</value>
    public string? Title { get; set; }
}