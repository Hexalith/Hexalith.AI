// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 04-26-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 04-29-2023
// ***********************************************************************
// <copyright file="ApplicationAdministrationHelper.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.ApplicationAdministrations.Infrastructure.Helpers;

using System.Diagnostics.CodeAnalysis;

using Dapr.Actors.Runtime;

using Hexalith.AI.AzureBot.ApplicationAdministrations.Application.Services;
using Hexalith.AI.AzureBot.ApplicationAdministrations.Infrastructure.Actors;
using Hexalith.AI.AzureBot.ApplicationAdministrations.Infrastructure.Services;
using Hexalith.Extensions.Configuration;

/// <summary>
/// Class ApplicationAdministrationHelper.
/// </summary>
public static class ApplicationAdministrationHelper
{
    /// <summary>
    /// Adds the global administration.
    /// </summary>
    /// <param name="actors">The actors.</param>
    /// <returns>ActorRegistrationCollection.</returns>
    /// <exception cref="System.ArgumentNullException"></exception>
    public static ActorRegistrationCollection AddApplicationAdministration([NotNull] this ActorRegistrationCollection actors)
    {
        ArgumentNullException.ThrowIfNull(actors);
        actors.RegisterActor<ApplicationAdministrationActor>();
        return actors;
    }

    /// <summary>
    /// Adds the global administration.
    /// </summary>
    /// <param name="services">The services.</param>
    /// <param name="configuration">The configuration.</param>
    /// <returns>IServiceCollection.</returns>
    /// <exception cref="System.ArgumentNullException"></exception>
    public static IServiceCollection AddApplicationAdministration([NotNull] this IServiceCollection services, [NotNull] IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(configuration);
        return services
            .AddScoped<IApplicationAdministrationQueryService, ApplicationAdministrationQueryService>()
            .AddScoped<IApplicationAdministrationCommandService, ApplicationAdministrationCommandService>()
            .ConfigureSettings<ApplicationAdministrationSettings>(configuration);
    }
}