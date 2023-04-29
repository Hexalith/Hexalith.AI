// ***********************************************************************
// Assembly         :
// Author           : Jérôme Piquot
// Created          : 04-25-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 04-25-2023
// ***********************************************************************
// <copyright file="GlobalAdministrator.cs" company="Fiveforty S.A.S.">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.GlobalAdministrations.Domain.Entities;

using System.Diagnostics.CodeAnalysis;

using Hexalith.AI.AzureBot.GlobalAdministrations.Domain.Events;

/// <summary>
/// Class GlobalAdministrator.
/// Implements the <see cref="IEquatable{GlobalAdministrator}" />.
/// </summary>
/// <seealso cref="IEquatable{GlobalAdministrator}" />
public record GlobalAdministrator(string Email, string Name, bool Enabled)
{
    /// <summary>
    /// Applies the specified domain event.
    /// </summary>
    /// <param name="domainEvent">The domain event.</param>
    /// <returns>GlobalAdministrator.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static GlobalAdministrator Apply([NotNull] GlobalAdministratorRegistered domainEvent)
    {
        ArgumentNullException.ThrowIfNull(domainEvent);
        return new GlobalAdministrator(domainEvent.Email, domainEvent.Name, true);
    }
}