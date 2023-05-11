// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 05-09-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 05-09-2023
// ***********************************************************************
// <copyright file="GlobalAdministrationSkill.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.GlobalAdministrations.Application.Skills;

using Hexalith.AI.AzureBot.GlobalAdministrations.Application.Commands;
using Hexalith.AI.AzureBot.GlobalAdministrations.Application.Services;
using Hexalith.Application.Abstractions.Metadatas;

using Microsoft.SemanticKernel.Orchestration;
using Microsoft.SemanticKernel.SkillDefinition;

/// <summary>
/// Class GlobalAdministrationSkill.
/// </summary>
public class GlobalAdministrationSkill
{
    /// <summary>
    /// The service.
    /// </summary>
    private readonly IGlobalAdministrationCommandService _service;

    /// <summary>
    /// Initializes a new instance of the <see cref="GlobalAdministrationSkill" /> class.
    /// </summary>
    /// <param name="service">The service.</param>
    /// <exception cref="System.ArgumentNullException"></exception>
    public GlobalAdministrationSkill(IGlobalAdministrationCommandService service)
    {
        ArgumentNullException.ThrowIfNull(service);
        _service = service;
    }

    /// <summary>
    /// Registers the global administrator.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <returns>RegisterGlobalAdministrator.</returns>
    /// <exception cref="System.ArgumentNullException"></exception>
    [SKFunction("Register a new global administrator")]
    [SKFunctionContextParameter(Name = nameof(RegisterGlobalAdministrator.Email), Description = "The email of the administrator to register")]
    [SKFunctionContextParameter(Name = nameof(Metadata.Context.UserId), Description = "The email of the user asking to register a global administrator")]
    [SKFunctionName(nameof(RegisterGlobalAdministrator))]
    public async Task<string> RegisterGlobalAdministratorAsync(SKContext context)
    {
        ArgumentNullException.ThrowIfNull(context);
        string email = context[nameof(RegisterGlobalAdministrator.Email)];
        string userId = context[nameof(Metadata.Context.UserId)];

        await _service.RegisterGlobalAdministratorAsync(email, userId, context.CancellationToken).ConfigureAwait(false);
        return $"The registration for the global administrator with the email {email} has been submitted by {userId}.";
    }
}