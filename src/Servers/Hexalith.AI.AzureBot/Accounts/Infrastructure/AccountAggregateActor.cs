// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 04-25-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 04-25-2023
// ***********************************************************************
// <copyright file="AccountAggregateActor.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.Accounts.Infrastructure;

using Dapr.Actors.Runtime;

/// <summary>
/// Class AccountAggregateActor.
/// Implements the <see cref="Actor" />
/// Implements the <see cref="IAccountAggregateActor" />.
/// </summary>
/// <seealso cref="Actor" />
/// <seealso cref="IAccountAggregateActor" />
public class AccountAggregateActor : Actor, IAccountAggregateActor
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AccountAggregateActor"/> class.
    /// </summary>
    /// <param name="host">The <see cref="T:Dapr.Actors.Runtime.ActorHost" /> that will host this actor instance.</param>
    public AccountAggregateActor(ActorHost host)
        : base(host)
    {
    }
}