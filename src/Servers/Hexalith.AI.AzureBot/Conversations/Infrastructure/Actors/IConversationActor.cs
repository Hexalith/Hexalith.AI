// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 04-25-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 05-02-2023
// ***********************************************************************
// <copyright file="IConversationActor.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.Conversations.Infrastructure.Actors;

using System.Threading.Tasks;

using Dapr.Actors;

/// <summary>
/// Interface IConversationActor
/// Extends the <see cref="IActor" />.
/// </summary>
/// <seealso cref="IActor" />
public interface IConversationActor : IActor
{
    /// <summary>
    /// Gets the conversation text asynchronous.
    /// </summary>
    /// <returns>Task&lt;System.String&gt;.</returns>
    Task<string> GetConversationTextAsync();
}