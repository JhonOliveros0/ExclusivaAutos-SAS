namespace ExclusivaAutos.Infrastructure;

public class OAuthSettings
{
    public const string SectionName = "OAuth";
    public string ClientId { get; set; } = string.Empty;
    public string ClientSecret { get; set; } = string.Empty;
    public string TenantId { get; set; } = string.Empty;
}