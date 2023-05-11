// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 04-30-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 04-30-2023
// ***********************************************************************
// <copyright file="ProjectSource.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.UnitOfWork.Domain.Projects;

/// <summary>
/// Class ProjectSource.
/// Implements the <see cref="IEquatable{ProjectSource}" />.
/// </summary>
/// <seealso cref="IEquatable{ProjectSource}" />
public record ProjectSource(string Name, Uri Url, ProjectSourceType Type)
{
}