// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 05-01-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 05-02-2023
// ***********************************************************************
// <copyright file="Conversation.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.Conversations.Domain;

using Hexalith.AI.AzureBot.Conversations.Domain.Events;
using Hexalith.Domain.Aggregates;
using Hexalith.Domain.Events;
using Hexalith.Domain.Exceptions;
using Hexalith.Extensions.Helpers;

/// <summary>
/// Class ConversationInformation.
/// </summary>
public record Conversation(
        string Id,
        string Email,
        string Account,
        string Title,
        string Summary,
        DateTimeOffset DateStarted,
        DateTimeOffset? DateEnded,
        IEnumerable<ConversationItem> Items)
     : Aggregate
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Conversation"/> class.
    /// </summary>
    /// <param name="started">The started.</param>
    public Conversation(ConversationStarted started)
        : this(
              (started ?? throw new ArgumentNullException(nameof(started))).Id,
              started.Email,
              started.Account,
              string.Empty,
              string.Empty,
              started.Date,
              null,
              new ConversationItem(started.Email, started.Text, started.UserName, started.Date).IntoArray())
    {
    }

    /// <summary>
    /// Applies the specified domain event.
    /// </summary>
    /// <param name="domainEvent">The domain event.</param>
    /// <returns>IAggregate.</returns>
    /// <exception cref="System.NotImplementedException"></exception>
    public override IAggregate Apply(BaseEvent domainEvent)
    {
        return domainEvent switch
        {
            ConversationItemAdded item => this with
            {
                Items = new List<ConversationItem>(Items)
                    {
                        new ConversationItem(item.Email, item.Text, item.UserName, item.Date),
                    },
            },
            ConversationEnded ended => this with { DateEnded = ended.Date },
            ConversationTitleChanged setTitle => this with { Title = setTitle.Title },
            ConversationSummaryChanged setSummary => this with { Summary = setSummary.Summary },
            ConversationStarted => throw new InvalidAggregateEventException(this, domainEvent, true),
            _ => throw new InvalidAggregateEventException(this, domainEvent, false),
        };
    }

    /// <summary>
    /// Defaults the aggregate identifier.
    /// </summary>
    /// <returns>System.String.</returns>
    protected override string DefaultAggregateId() => Id;

    /// <summary>
    /// Defaults the name of the aggregate.
    /// </summary>
    /// <returns>System.String.</returns>
    protected override string DefaultAggregateName() => nameof(Conversation);
}