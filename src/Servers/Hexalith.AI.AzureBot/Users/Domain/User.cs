// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 05-01-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 05-01-2023
// ***********************************************************************
// <copyright file="User.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.Users.Domain;

using System.Text.Json.Serialization;

using Hexalith.AI.AzureBot.Users.Domain.Events;
using Hexalith.Domain.Abstractions.Aggregates;
using Hexalith.Domain.Abstractions.Events;

/// <summary>
/// Class UserInformation.
/// </summary>
public class User : Aggregate
{
    /// <summary>
    /// Initializes a new instance of the <see cref="User"/> class.
    /// </summary>
    /// <param name="email">The email.</param>
    /// <param name="name">The name.</param>
    /// <param name="isGlobalAdministrator">if set to <c>true</c> [is global administrator].</param>
    /// <param name="accounts">The accounts.</param>
    [JsonConstructor]
    public User(
        string email,
        string name,
        bool isGlobalAdministrator,
        IEnumerable<UserAccount> accounts)
    {
        Email = email;
        Name = name;
        IsGlobalAdministrator = isGlobalAdministrator;
        Accounts = accounts;
    }

    public User(UserRegistered userRegistered)
        : this(
              (userRegistered ?? throw new ArgumentNullException(nameof(userRegistered))).Email,
              userRegistered.Email, false,
              Array.Empty<UserAccount>())
    {
    }

    /// <summary>
    /// Gets the accounts.
    /// </summary>
    /// <value>The accounts.</value>
    public IEnumerable<UserAccount> Accounts { get; }

    /// <summary>
    /// Gets or sets the email.
    /// </summary>
    /// <value>The email.</value>
    public string Email { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this instance is global administrator.
    /// </summary>
    /// <value><c>true</c> if this instance is global administrator; otherwise, <c>false</c>.</value>
    public bool IsGlobalAdministrator { get; set; }

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>The name.</value>
    public string Name { get; set; }

    /// <summary>
    /// Applies the specified domain event.
    /// </summary>
    /// <param name="domainEvent">The domain event.</param>
    /// <returns>IAggregate.</returns>
    /// <exception cref="System.NotImplementedException"></exception>
    public override IAggregate Apply(BaseEvent domainEvent) => throw new NotImplementedException();

    protected override string DefaultAggregateId() => Email;

    protected override string DefaultAggregateName() => nameof(User);
}