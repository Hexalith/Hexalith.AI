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

namespace Hexalith.AI.AzureBot.SecurityTenants.Infrastructure.Helpers;

using System.Diagnostics.CodeAnalysis;

using Dapr.Actors.Runtime;

using Hexalith.AI.AzureBot.SecurityTenants.Application.Services;
using Hexalith.AI.AzureBot.SecurityTenants.Infrastructure.Actors;
using Hexalith.AI.AzureBot.SecurityTenants.Infrastructure.Configuration;
using Hexalith.AI.AzureBot.SecurityTenants.Infrastructure.Services;
using Hexalith.Extensions.Configuration;

/// <summary>
/// Class TenantHelper.
/// </summary>
public static class SecurityTenantHelper
{
    /// <summary>
    /// Adds the global administration.
    /// </summary>
    /// <param name="actors">The actors.</param>
    /// <returns>ActorRegistrationCollection.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static ActorRegistrationCollection AddTenant([NotNull] this ActorRegistrationCollection actors)
    {
        ArgumentNullException.ThrowIfNull(actors);
        actors.RegisterActor<SecurityTenantAggregateActor>();
        return actors;
    }

    /// <summary>
    /// Adds the global administration.
    /// </summary>
    /// <param name="services">The services.</param>
    /// <param name="configuration">The configuration.</param>
    /// <returns>IServiceCollection.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static IServiceCollection AddTenant([NotNull] this IServiceCollection services, [NotNull] IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(configuration);
        return services
            .AddScoped<ISecurityTenantQueryService, SecurityTenantQueryService>()
            .AddScoped<ISecurityTenantCommandService, SecurityTenantCommandService>()
            .ConfigureSettings<SecurityTenantSettings>(configuration);
    }
}