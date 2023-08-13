namespace Core.Utilities.Security.JWT;

public class TokenOption
{
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public int AccessTokenExpiration { get; set; }
    public string Securitykey { get; set; }
}
