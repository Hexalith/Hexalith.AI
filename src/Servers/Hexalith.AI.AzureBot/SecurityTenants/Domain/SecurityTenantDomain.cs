// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 04-24-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 04-29-2023
// ***********************************************************************
// <copyright file="Domain.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Hexalith.AI.AzureBot.SecurityTenants.Domain;

using System.Runtime.Serialization;

using Hexalith.Domain.Aggregates;

/// <summary>
/// Class Domain.
/// Implements the <see cref="IAggregate" />
/// Implements the <see cref="IEquatable{Domain}" />.
/// </summary>
/// <seealso cref="IAggregate" />
/// <seealso cref="IEquatable{Domain}" />
[DataContract]
public record SecurityTenantDomain(string Dns)
{
}