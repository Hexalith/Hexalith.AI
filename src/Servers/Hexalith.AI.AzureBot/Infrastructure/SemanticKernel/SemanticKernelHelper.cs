// ***********************************************************************
// Assembly         :
// Author           : Jérôme Piquot
// Created          : 04-23-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 04-23-2023
// ***********************************************************************
// <copyright file="SemanticKernelHelper.cs" company="Fiveforty S.A.S.">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.Infrastructure.SemanticKernel;

using System.Diagnostics.CodeAnalysis;

using Hexalith.AI.AzureBot.Infrastructure.SemanticKernel.Configurations;
using Hexalith.Extensions.Configuration;

using Microsoft.SemanticKernel;

/// <summary>
/// Class SemanticKernelHelper.
/// </summary>
public static class SemanticKernelHelper
{
    /// <summary>
    /// Adds the completion service.
    /// </summary>
    /// <param name="config">The configuration.</param>
    /// <param name="settings">The settings.</param>
    /// <returns>KernelConfig.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static KernelConfig AddCompletionService([NotNull] this KernelConfig config, [NotNull] ArtificialIntelligenceServiceSettings settings)
    {
        ArgumentNullException.ThrowIfNull(config);
        ArgumentNullException.ThrowIfNull(settings);
        _ = SettingsException<ArtificialIntelligenceServiceSettings>.ThrowIfUndefined(settings.ChatModelService);
        _ = SettingsException<ArtificialIntelligenceServiceSettings>.ThrowIfUndefined(settings.TextModelService);
        _ = SettingsException<ArtificialIntelligenceServiceSettings>.ThrowIfUndefined(settings.ChatModelService.Type);
        _ = SettingsException<ArtificialIntelligenceServiceSettings>.ThrowIfUndefined(settings.ChatModelService.Name);
        _ = SettingsException<ArtificialIntelligenceServiceSettings>.ThrowIfUndefined(settings.ChatModelService.ApplicationKey);
        _ = SettingsException<ArtificialIntelligenceServiceSettings>.ThrowIfUndefined(settings.ChatModelService.Model);
        _ = SettingsException<ArtificialIntelligenceServiceSettings>.ThrowIfUndefined(settings.TextModelService.Type);
        _ = SettingsException<ArtificialIntelligenceServiceSettings>.ThrowIfUndefined(settings.TextModelService.Name);
        _ = SettingsException<ArtificialIntelligenceServiceSettings>.ThrowIfUndefined(settings.TextModelService.ApplicationKey);
        _ = SettingsException<ArtificialIntelligenceServiceSettings>.ThrowIfUndefined(settings.TextModelService.Model);
        config = settings.ChatModelService.Type switch
        {
            CompletionServiceType.AzureOpenAI =>
                    config.AddAzureChatCompletionService(
                    settings.ChatModelService.Name,
                    settings.ChatModelService.Model,
                    SettingsException<ArtificialIntelligenceServiceSettings>.ThrowIfUndefined(settings.ChatModelService.Endpoint)!,
                    settings.ChatModelService.ApplicationKey),
            CompletionServiceType.OpenAI =>
                _ = config.AddOpenAIChatCompletionService(
                    settings.ChatModelService.Name,
                    settings.ChatModelService.Model,
                    settings.ChatModelService.ApplicationKey,
                    settings.ChatModelService.OrganizationId),
            _ => throw new InvalidOperationException($"Unknown completion service type {settings.ChatModelService.Type}"),
        };
        return settings.TextModelService.Type switch
        {
            CompletionServiceType.AzureOpenAI =>
                    config.AddAzureTextCompletionService(
                    settings.TextModelService.Name,
                    settings.TextModelService.Model,
                    SettingsException<ArtificialIntelligenceServiceSettings>.ThrowIfUndefined(settings.TextModelService.Endpoint)!,
                    settings.TextModelService.ApplicationKey),
            CompletionServiceType.OpenAI =>
                _ = config.AddOpenAITextCompletionService(
                    settings.TextModelService.Name,
                    settings.TextModelService.Model,
                    settings.TextModelService.ApplicationKey,
                    settings.TextModelService.OrganizationId),
            _ => throw new InvalidOperationException($"Unknown completion service type {settings.TextModelService.Type}"),
        };
    }
}