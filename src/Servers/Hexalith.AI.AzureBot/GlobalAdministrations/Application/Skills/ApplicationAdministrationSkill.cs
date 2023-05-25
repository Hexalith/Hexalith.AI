// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 05-09-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 05-09-2023
// ***********************************************************************
// <copyright file="ApplicationAdministrationSkill.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.ApplicationAdministrations.Application.Skills;

using Hexalith.AI.AzureBot.ApplicationAdministrations.Application.Services;
using Hexalith.AI.AzureBot.GlobalAdministrations.Application.Commands;
using Hexalith.Application.Metadatas;

using Microsoft.SemanticKernel.Orchestration;
using Microsoft.SemanticKernel.SkillDefinition;

/// <summary>
/// Class ApplicationAdministrationSkill.
/// </summary>
public class ApplicationAdministrationSkill
{
    /// <summary>
    /// The service.
    /// </summary>
    private readonly IApplicationAdministrationCommandService _service;

    /// <summary>
    /// Initializes a new instance of the <see cref="ApplicationAdministrationSkill" /> class.
    /// </summary>
    /// <param name="service">The service.</param>
    /// <exception cref="System.ArgumentNullException"></exception>
    public ApplicationAdministrationSkill(IApplicationAdministrationCommandService service)
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