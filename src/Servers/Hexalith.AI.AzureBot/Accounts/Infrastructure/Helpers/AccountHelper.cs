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
namespace Hexalith.AI.AzureBot.Accounts.Infrastructure.Helpers;

using System.Diagnostics.CodeAnalysis;

using Dapr.Actors.Runtime;

using Hexalith.AI.AzureBot.Accounts.Application.Services;
using Hexalith.AI.AzureBot.Accounts.Infrastructure;
using Hexalith.AI.AzureBot.Accounts.Infrastructure.Configuration;
using Hexalith.AI.AzureBot.Accounts.Infrastructure.Services;
using Hexalith.Extensions.Configuration;

/// <summary>
/// Class AccountHelper.
/// </summary>
public static class AccountHelper
{
    /// <summary>
    /// Adds the global administration.
    /// </summary>
    /// <param name="actors">The actors.</param>
    /// <returns>ActorRegistrationCollection.</returns>
    /// <exception cref="System.ArgumentNullException"></exception>
    public static ActorRegistrationCollection AddAccount([NotNull] this ActorRegistrationCollection actors)
    {
        ArgumentNullException.ThrowIfNull(actors);
        actors.RegisterActor<AccountAggregateActor>();
        return actors;
    }

    /// <summary>
    /// Adds the global administration.
    /// </summary>
    /// <param name="services">The services.</param>
    /// <param name="configuration">The configuration.</param>
    /// <returns>IServiceCollection.</returns>
    /// <exception cref="System.ArgumentNullException"></exception>
    public static IServiceCollection AddAccount([NotNull] this IServiceCollection services, [NotNull] IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(configuration);
        return services
            .AddScoped<IAccountQueryService, AccountQueryService>()
            .AddScoped<IAccountCommandService, AccountCommandService>()
            .ConfigureSettings<AccountSettings>(configuration);
    }
}