namespace Hexalith.AI.AzureBot.Infrastructure.SemanticKernel.Services;

using Hexalith.AI.AzureBot.Infrastructure.SemanticKernel.Configurations;

using Microsoft.Extensions.Options;
using Microsoft.SemanticKernel;

public class ArtificialIntelligenceService
{
    private readonly ILogger<ArtificialIntelligenceService> _logger;
    private readonly ArtificialIntelligenceServiceSettings _settings;
    private IKernel? _kernel;

    /// <summary>
    /// Initializes a new instance of the <see cref="ArtificialIntelligenceService"/> class.
    /// </summary>
    /// <param name="settings"></param>
    /// <param name="logger"></param>
    public ArtificialIntelligenceService(IOptions<ArtificialIntelligenceServiceSettings> settings, ILogger<ArtificialIntelligenceService> logger)
    {
        _settings = settings.Value;
        _logger = logger;
    }

    public IKernel Kernel => _kernel ??= CreateKernel();

    private IKernel? CreateKernel()
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