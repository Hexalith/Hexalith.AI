namespace Hexalith.AI.AzureBot.Accounts.Application.Models;

public class UserAccountInformation
{
    public string? AccountId { get; set; }

    public IEnumerable<string>? Accounts { get; set; }

    public IEnumerable<string>? Administrators { get; set; }
    public string? Domain { get; set; }

    public string? Name { get; set; }
    public IEnumerable<string>? Tenants { get; set; }
}