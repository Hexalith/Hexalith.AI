namespace Hexalith.AI.AzureBot.Bot.Infrastructure;

using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Teams;
using Microsoft.Bot.Schema;

/// <summary>
/// An empty bot handler.
/// You can add your customization code here to extend your bot logic if needed.
/// </summary>
public class TeamsBot : TeamsActivityHandler
{
    /// <inheritdoc/>
    public override Task OnTurnAsync(ITurnContext turnContext, CancellationToken cancellationToken = default) => base.OnTurnAsync(turnContext, cancellationToken);

    /// <inheritdoc/>
    protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken) =>
        // Sends an activity to the sender of the incoming activity.
        await turnContext.SendActivityAsync(MessageFactory.Text($"Echo: {turnContext.Activity.Text}"), cancellationToken).ConfigureAwait(false);
}