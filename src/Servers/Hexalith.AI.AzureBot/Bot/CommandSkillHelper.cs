namespace Hexalith.AI.AzureBot.Bot;

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text.Json;

using Hexalith.Application.Commands;
using Hexalith.Extensions.Reflections;

using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Orchestration;
using Microsoft.SemanticKernel.SemanticFunctions;

public static class CommandSkillHelper
{
    public static IDictionary<string, ISKFunction> ImportSemanticSkillFromCommands(this IKernel kernel)
    {
        Dictionary<string, ISKFunction> skill = new();

        Dictionary<string, BaseCommand> map = TypeMapper<BaseCommand>.GetMap();

        foreach (KeyValuePair<string, BaseCommand> m in map)
        {
            string functionName = m.Key;

            string skillName = m.Value.AggregateName;

            // Load prompt configuration. Note: the configuration is optional.
            PromptTemplateConfig config = new()
            {
                Type = "completion",
                Description = GetDescription(m.Value.GetType()),
                Input = GetInputParameters(m.Value),
                Completion = new()
                {
                    MaxTokens = 2000,
                },
            };
            kernel.Log.LogTrace("Adding command skill {0}/{1}", skillName, functionName);

            // Load prompt template
            PromptTemplate template = new(
                GetTemplate(m.Value),
                config,
                kernel.PromptTemplateEngine);

            SemanticFunctionConfig functionConfig = new(config, template);

            skill[functionName] = kernel.RegisterSemanticFunction(skillName, functionName, functionConfig);
        }

        return skill;
    }

    private static string GetDefaultValue(PropertyInfo property)
    {
        // Get the default value attribute
        DefaultValueAttribute? defaultValueAttribute = property.GetCustomAttribute<DefaultValueAttribute>();
        if (defaultValueAttribute is not null && defaultValueAttribute.Value is not null)
        {
            // Get the description from the description attribute
            return JsonSerializer.Serialize(defaultValueAttribute.Value);
        }

        return string.Empty;
    }

    private static string GetDescription(Type type)
    {
        // Get the description attribute
        DescriptionAttribute? descriptionAttribute = type.GetCustomAttribute<DescriptionAttribute>(false);
        if (descriptionAttribute != null)
        {
            // Get the description from the description attribute
            return string.IsNullOrWhiteSpace(descriptionAttribute.Description)
                ? throw new InvalidOperationException($"The command description in the description attribute on class {type.FullName} is empty. It must describe the command action description needed for the semantic kernel function.")
                : descriptionAttribute.Description;
        }

        // Get the display attribute
        DisplayAttribute? displayAttribute = type.GetCustomAttribute<DisplayAttribute>(false);
        if (displayAttribute != null)
        {
            // Get the description from the display attribute
            return string.IsNullOrWhiteSpace(displayAttribute.Description)
                ? throw new InvalidOperationException($"The command description in the display attribute on class {type.FullName} is empty. It must describe the command action description needed for the semantic kernel function.")
                : displayAttribute.Description;
        }

        throw new InvalidOperationException($"The command {type.Name} should have a description. Use the 'Description' or 'Display' attribute on the class to define the command action description needed for the semantic kernel function.");
    }

    private static string GetDescription(PropertyInfo property)
    {
        // Get the description attribute
        DescriptionAttribute? descriptionAttribute = property.GetCustomAttribute<DescriptionAttribute>(false);
        if (descriptionAttribute != null)
        {
            // Get the description from the description attribute
            return string.IsNullOrWhiteSpace(descriptionAttribute.Description)
                ? throw new InvalidOperationException($"The command description in the description attribute on class {property.DeclaringType?.FullName} is empty. It must describe the command action description needed for the semantic kernel function.")
                : descriptionAttribute.Description;
        }

        // Get the display attribute
        DisplayAttribute? displayAttribute = property.GetCustomAttribute<DisplayAttribute>(false);
        if (displayAttribute != null)
        {
            // Get the description from the display attribute
            return string.IsNullOrWhiteSpace(displayAttribute.Description)
                ? throw new InvalidOperationException($"The command description in the display attribute on class {property.DeclaringType?.FullName} is empty. It must describe the command action description needed for the semantic kernel function.")
                : displayAttribute.Description;
        }

        throw new InvalidOperationException($"The command {property.Name} should have a description. Use the 'Description' or 'Display' attribute on the class to define the command action description needed for the semantic kernel function.");
    }

    private static PromptTemplateConfig.InputConfig GetInputParameters(BaseCommand command)
    {
        // Get all public properties with a setter
        PropertyInfo[] properties = command.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.SetProperty);
        List<PromptTemplateConfig.InputParameter> parameters = properties.Select(p => new PromptTemplateConfig.InputParameter
        {
            Name = p.Name,
            Description = GetDescription(p),
            DefaultValue = GetDefaultValue(p),
        }).ToList();
        return new PromptTemplateConfig.InputConfig
        {
            Parameters = parameters,
        };
    }

    private static string GetTemplate(BaseCommand value)
        => $$"""
        {type.Name}
        """;
}