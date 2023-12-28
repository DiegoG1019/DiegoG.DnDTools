namespace DiegoG.DnDTools.Apps.API.Options;

public class BearerTokenOptions
{
    public string? ClaimsIssuer { get; set; }
    public TimeSpan? BearerTokenExpiration { get; set; }
    public TimeSpan? RefreshTokenExpiration { get; set; }
}
