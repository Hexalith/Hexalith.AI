// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 04-30-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 04-30-2023
// ***********************************************************************
// <copyright file="ProjectSourceType.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Hexalith.AI.AzureBot.UnitOfWork.Domain.Projects;

/// <summary>
/// Enum ProjectSourceType.
/// </summary>
public enum ProjectSourceType
{
    /// <summary>
    /// The azure dev ops.
    /// </summary>
    AzureDevOps,

    /// <summary>
    /// The git hub.
    /// </summary>
    GitHub,
}