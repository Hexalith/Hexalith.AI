// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 04-23-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 04-23-2023
// ***********************************************************************
// <copyright file="ArtificialIntelligenceServiceSettings.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Hexalith.AI.AzureBot.SemanticKernel.Configurations;

using Hexalith.Extensions.Configuration;

/// <summary>
/// Artificial Intelligence Service Settings.
/// Implements the <see cref="ISettings" />.
/// </summary>
/// <seealso cref="ISettings" />
public class ArtificialIntelligenceServiceSettings : ISettings
{
    public AiModelConfiguration? ChatModelService { get; set; }
    public AiModelConfiguration? TextModelService { get; set; }

    public static string ConfigurationName() => "AI";
}