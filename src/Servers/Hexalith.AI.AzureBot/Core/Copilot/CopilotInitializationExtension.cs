// ***********************************************************************
// Assembly         : Hexalith.AI.AzureBot
// Author           : Jérôme Piquot
// Created          : 07-04-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 07-04-2023
// ***********************************************************************
// <copyright file="CopilotInitializationExtension.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Hexalith.AI.AzureBot.Core.Copilot;

using Hexalith.Infrastructure.WebApis.Helpers;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

using SemanticKernel.Service;
using SemanticKernel.Service.CopilotChat.Extensions;
using SemanticKernel.Service.CopilotChat.Hubs;

/// <summary>
/// Class CopilotInitializationExtension.
/// </summary>
internal static class CopilotInitializationExtension
{
    /// <summary>
    /// Adds the copilot.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <returns>WebApplicationBuilder.</returns>
    public static WebApplicationBuilder AddCopilot(this WebApplicationBuilder builder)
    {
        // Load in configuration settings from appsettings.json, user-secrets, key vaults, etc...
        _ = builder.Host.AddConfiguration();
        _ = builder.WebHost.UseUrls(); // Disables endpoint override warning message when using IConfiguration for Kestrel endpoint.

        // Add in configuration options and Semantic Kernel services.
        _ = builder.Services

            // .AddSingleton<ILogger>(sp => sp.GetRequiredService<ILogger<Program>>()) // some services require an un-templated ILogger
            .AddOptions(builder.Configuration)
            .AddSemanticKernelServices();

        // Add CopilotChat services.
        builder.Services
            .AddCopilotChatOptions(builder.Configuration)
            .AddCopilotChatPlannerServices()
            .AddPersistentChatStore();

        // Add SignalR as the real time relay service
        _ = builder.Services.AddSignalR();

        // Add AppInsights telemetry
        // builder.Services
        // .AddHttpContextAccessor()
        // .AddApplicationInsightsTelemetry(options => options.ConnectionString = builder.Configuration["APPLICATIONINSIGHTS_CONNECTION_STRING"])
        // .AddSingleton<ITelemetryInitializer, AppInsightsUserTelemetryInitializerService>()
        // .AddLogging(logBuilder => logBuilder.AddApplicationInsights())
        // .AddSingleton<ITelemetryService, AppInsightsTelemetryService>();
        /*
        #if DEBUG
                TelemetryDebugWriter.IsTracingDisabled = false;
        #endif
        */

        // Add in the rest of the services.
        _ = builder.Services
            .AddAuthorization(builder.Configuration)

            // .AddEndpointsApiExplorer()
            //            .AddSwaggerGen()
            .AddCors();

        // .AddControllers();
        // builder.Services.AddHealthChecks();
        return builder;
    }

    /// <summary>
    /// Uses the copilot.
    /// </summary>
    /// <param name="app">The application.</param>
    /// <returns>WebApplication.</returns>
    public static WebApplication UseCopilot(this WebApplication app)
    {
        // Add CopilotChat hub for real time communication
        _ = app.MapHub<MessageRelayHub>("/messageRelayHub");

        _ = app.UseHexalith();
        _ = app.UseCors();
        return app;
    }
}