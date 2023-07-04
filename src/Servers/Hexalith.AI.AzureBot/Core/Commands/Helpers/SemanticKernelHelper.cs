namespace Hexalith.AI.AzureBot.Core.Commands.Helpers;

using System.Diagnostics.CodeAnalysis;

using Microsoft.SemanticKernel;

/// <summary>
/// Class MicrosoftBotHelper.
/// </summary>
public static class SemanticKernelHelper
{
    /// <summary>
    /// Adds the hexalith.
    /// </summary>
    /// <param name="config">The configuration.</param>
    /// <returns>IKernel.</returns>
    /// <exception cref="ArgumentNullException">null.</exception>
    public static IKernel AddHexalith([NotNull] this KernelConfig config)
    {
        ArgumentNullException.ThrowIfNull(config);

        // _ = kernel.ImportSkill(cloudDriveSkill, nameof(Microsoft.SemanticKernel.CoreSkills.CloudDriveSkill));
        return config.AddHexalith();
    }

    /// <summary>
    /// Adds the skills.
    /// </summary>
    /// <param name="kernel">The kernel.</param>
    /// <returns>IKernel.</returns>
    public static IKernel AddSkills(this IKernel kernel)
    {
        _ = kernel.ImportApplicationCommandsAsSkills();
        _ = kernel.ImportSemanticSkillFromDirectory(
            Path.Combine(
                Directory.GetCurrentDirectory(),
                "Skills"));
        return kernel;
    }
}