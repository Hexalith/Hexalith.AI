// ***********************************************************************
// Assembly         : Hexalith.AI.Build
// Author           : Jérôme Piquot
// Created          : 04-18-2023
//
// Last Modified By : Jérôme Piquot
// Last Modified On : 04-21-2023
// ***********************************************************************
// <copyright file="Program.cs" company="Fiveforty">
//     Copyright (c) Fiveforty S.A.S.. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Hexalith.AI.Build;

using ADotNet.Clients;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets.Tasks;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets.Tasks.SetupDotNetTaskV1s;

/// <summary>
/// Class Program.
/// </summary>
internal class Program
{
    /// <summary>
    /// Defines the entry point of the application.
    /// </summary>
    /// <param name="args">The arguments.</param>
    private static void Main(string[] args)
    {
        ADotNetClient adoNetClient = new();

        GithubPipeline githubPipeline = new()
        {
            Name = "Hexalith.AI Build",

            OnEvents = new Events
            {
                Push = new PushEvent
                {
                    Branches = new string[] { "main" },
                },

                PullRequest = new PullRequestEvent
                {
                    Branches = new string[] { "main" },
                },
            },

            Jobs = new Jobs
            {
                Build = new BuildJob
                {
                    EnvironmentVariables = new Dictionary<string, string>
                    {
                        { "ApiKey", "${{ secrets.APIKEY }}" },
                        { "OrgId", "${{ secrets.ORGID }}" },
                    },

                    RunsOn = BuildMachines.UbuntuLatest,

                    Steps = new List<GithubTask>
                    {
                        new CheckoutTaskV2
                        {
                            Name = "Pulling Code",
                        },

                        new SetupDotNetTaskV1
                        {
                            Name = "Installing .NET",

                            TargetDotNetVersion = new TargetDotNetVersion
                            {
                                DotNetVersion = "7.0.*",
                            },
                        },

                        new RestoreTask
                        {
                            Name = "Restoring Packages",
                        },

                        new DotNetBuildTask
                        {
                            Name = "Building Solution",
                        },

                        new TestTask
                        {
                            Name = "Running Tests",
                        },
                    },
                },
            },
        };

        adoNetClient.SerializeAndWriteToFile(
            adoPipeline: githubPipeline,
            path: "../../../../../../.github/workflows/dotnet.yml");
    }
}