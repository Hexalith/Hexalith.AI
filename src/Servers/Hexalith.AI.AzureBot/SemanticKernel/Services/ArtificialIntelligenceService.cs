// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 04-29-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 04-29-2023
// ***********************************************************************
// <copyright file="ArtificialIntelligenceService.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.SemanticKernel.Services;

using Hexalith.AI.AzureBot.SemanticKernel;
using Hexalith.AI.AzureBot.SemanticKernel.Configurations;

using Microsoft.Extensions.Options;
using Microsoft.SemanticKernel;

/// <summary>
/// Class ArtificialIntelligenceService.
/// </summary>
public class ArtificialIntelligenceService
{
    /// <summary>
    /// The logger.
    /// </summary>
    private readonly ILogger<ArtificialIntelligenceService> _logger;

    /// <summary>
    /// The settings.
    /// </summary>
    private readonly ArtificialIntelligenceServiceSettings _settings;

    /// <summary>
    /// The kernel.
    /// </summary>
    private IKernel? _kernel;

    /// <summary>
    /// Initializes a new instance of the <see cref="ArtificialIntelligenceService" /> class.
    /// </summary>
    /// <param name="settings">The settings.</param>
    /// <param name="logger">The logger.</param>
    public ArtificialIntelligenceService(IOptions<ArtificialIntelligenceServiceSettings> settings, ILogger<ArtificialIntelligenceService> logger)
    {
        ArgumentNullException.ThrowIfNull(settings);
        ArgumentNullException.ThrowIfNull(logger);
        _settings = settings.Value;
        _logger = logger;
    }

    /// <summary>
    /// Gets the kernel.
    /// </summary>
    /// <value>The kernel.</value>
    public IKernel Kernel => _kernel ??= CreateKernel();

    /// <summary>
    /// Creates the kernel.
    /// </summary>
    /// <returns>System.Nullable&lt;IKernel&gt;.</returns>
    private IKernel CreateKernel()
    {
        KernelConfig config = new();
        config = config.AddCompletionService(_settings);
        return Microsoft.SemanticKernel.Kernel
            .Builder
            .WithLogger(_logger)
            .WithConfiguration(config)
            .Build();
    }
}