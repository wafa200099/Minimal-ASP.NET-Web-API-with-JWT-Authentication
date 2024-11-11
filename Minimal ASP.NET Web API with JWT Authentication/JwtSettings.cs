namespace Minimal_ASP.NET_Web_API_with_JWT_Authentication;

public class JwtSettings
{
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public string Key { get; set; }
}
