// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 04-26-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 04-29-2023
// ***********************************************************************
// <copyright file="GlobalAdministrationHelper.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.Users.Infrastructure.Helpers;

using System.Diagnostics.CodeAnalysis;

using Dapr.Actors.Runtime;

using Hexalith.AI.AzureBot.Users.Application.Services;
using Hexalith.AI.AzureBot.Users.Infrastructure.Actors;
using Hexalith.AI.AzureBot.Users.Infrastructure.Configuration;
using Hexalith.Extensions.Configuration;

/// <summary>
/// Class UserHelper.
/// </summary>
public static class UserHelper
{
    /// <summary>
    /// Adds the global administration.
    /// </summary>
    /// <param name="actors">The actors.</param>
    /// <returns>ActorRegistrationCollection.</returns>
    /// <exception cref="System.ArgumentNullException"></exception>
    public static ActorRegistrationCollection AddUser([NotNull] this ActorRegistrationCollection actors)
    {
        ArgumentNullException.ThrowIfNull(actors);
        actors.RegisterActor<UserAggregateActor>();
        return actors;
    }

    /// <summary>
    /// Adds the global administration.
    /// </summary>
    /// <param name="services">The services.</param>
    /// <param name="configuration">The configuration.</param>
    /// <returns>IServiceCollection.</returns>
    /// <exception cref="System.ArgumentNullException"></exception>
    public static IServiceCollection AddUser([NotNull] this IServiceCollection services, [NotNull] IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(configuration);
        return services
            .AddScoped<IUserQueryService, UserQueryService>()
            .ConfigureSettings<UserSettings>(configuration);
    }
}