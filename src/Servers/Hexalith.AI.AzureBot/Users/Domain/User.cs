// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 05-01-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 05-02-2023
// ***********************************************************************
// <copyright file="User.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.Users.Domain;

using Hexalith.AI.AzureBot.Users.Domain.Events;
using Hexalith.Domain.Aggregates;
using Hexalith.Domain.Events;

/// <summary>
/// Class UserInformation.
/// </summary>
public record User(
        string Email,
        string Name,
        bool IsGlobalAdministrator,
        IEnumerable<UserAccount> Accounts)
    : Aggregate
{
    /// <summary>
    /// Initializes a new instance of the <see cref="User" /> class.
    /// </summary>
    /// <param name="userRegistered">The user registered.</param>
    public User(UserRegistered userRegistered)
        : this(
              (userRegistered ?? throw new ArgumentNullException(nameof(userRegistered))).Email,
              userRegistered.Email,
              false,
              Array.Empty<UserAccount>())
    {
    }

    /// <summary>
    /// Applies the specified domain event.
    /// </summary>
    /// <param name="domainEvent">The domain event.</param>
    /// <returns>IAggregate.</returns>
    /// <exception cref="System.NotImplementedException"></exception>
    public override IAggregate Apply(BaseEvent domainEvent) => throw new NotImplementedException();

    /// <inheritdoc/>
    protected override string DefaultAggregateId() => Email;

    /// <inheritdoc/>
    protected override string DefaultAggregateName() => nameof(User);
}