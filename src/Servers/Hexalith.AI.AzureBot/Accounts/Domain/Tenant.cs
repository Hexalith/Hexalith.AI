// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 04-24-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 05-08-2023
// ***********************************************************************
// <copyright file="Tenant.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Hexalith.AI.AzureBot.Accounts.Domain;

using Hexalith.Domain.Abstractions.Aggregates;

/// <summary>
/// Class Domain.
/// Implements the <see cref="IAggregate" />
/// Implements the <see cref="IEquatable{Domain}" />.
/// </summary>
/// <seealso cref="IAggregate" />
/// <seealso cref="IEquatable{Domain}" />
public record Tenant(string Id, string ApplicationId, string ApplicationSecret)
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Tenant"/> class.
    /// </summary>
    /// <param name="id">The identifier.</param>
    public Tenant(string id)
        : this(id, string.Empty, string.Empty)
    {
    }
}