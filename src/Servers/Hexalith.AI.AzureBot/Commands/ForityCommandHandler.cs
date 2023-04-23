namespace Hexalith.AI.AzureBot.Commands;

using AdaptiveCards.Templating;

using Hexalith.AI.AzureBot.Models;

using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using Microsoft.TeamsFx.Conversation;

using Newtonsoft.Json;

/// <summary>
/// The <see cref="ForityCommandHandler"/> registers a pattern with the <see cref="ITeamsCommandHandler"/> and
/// responds with an Adaptive Card if the user types the <see cref="TriggerPatterns"/>.
/// </summary>
public class ForityCommandHandler : ITeamsCommandHandler
{
    private readonly string _adaptiveCardFilePath = Path.Combine(".", "Resources", "ForityCard.json");
    private readonly ILogger<ForityCommandHandler> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="ForityCommandHandler"/> class.
    /// </summary>
    /// <param name="logger"></param>
    public ForityCommandHandler(ILogger<ForityCommandHandler> logger) => _logger = logger;

    /// <inheritdoc/>
    public IEnumerable<ITriggerPattern> TriggerPatterns => new List<ITriggerPattern>
    {
        // Used to trigger the command handler if the command text contains 'Fority'
        new RegExpTrigger("fority"),
    };

    /// <inheritdoc/>
    public async Task<ICommandResponse> HandleCommandAsync(ITurnContext turnContext, CommandMessage message, CancellationToken cancellationToken = default)
    {
        _logger?.LogInformation($"App received message: {message.Text}");

        // Read adaptive card template
        string cardTemplate = await File.ReadAllTextAsync(_adaptiveCardFilePath, cancellationToken).ConfigureAwait(false);

        // Render adaptive card content
        string cardContent = new AdaptiveCardTemplate(cardTemplate).Expand(
            new ForityModel
            {
                Title = "Echo service",
                Body = $"You said: {message.Text}",
            });

        // Build attachment
        IMessageActivity activity = MessageFactory.Attachment(
            new Attachment
            {
                ContentType = "application/vnd.microsoft.card.adaptive",
                Content = JsonConvert.DeserializeObject(cardContent),
            });

        // send response
        return new ActivityCommandResponse(activity);
    }
}