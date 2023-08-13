using Core.Utilities.Security.Encrypting;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Core.Utilities.Security.JWT;

public class JWTHelper : ITokenHelper
{
    private readonly IConfiguration _configuration;
    private readonly TokenOption _tokenOption;
    private DateTime _accessTokenExpiration;
    public JWTHelper(IConfiguration configuration)
    {
        _configuration = configuration;
        _tokenOption = _configuration.GetSection("TokenOptions").Get<TokenOption>();
        _accessTokenExpiration = DateTime.UtcNow.AddMinutes(_tokenOption.AccessTokenExpiration);
    }
    
    public AccessToken CreateToken(List<Claim> claims)
    {
        JwtHeader jwtHeader = CreateJwtHeader();
        JwtPayload jwtPayload = CreateJwtPayload(claims);
        JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(jwtHeader, jwtPayload);
        return CreateAccessToken(jwtSecurityToken);
    }

    private AccessToken CreateAccessToken(JwtSecurityToken jwtSecurityToken)
    {
        JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        string token = jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);

        return new AccessToken
        {
            Token = token,
            Expiration = _accessTokenExpiration
        };
    }

    private JwtPayload CreateJwtPayload(List<Claim> claims)
    {
        return new JwtPayload(
           issuer: _tokenOption.Issuer,
           audience: _tokenOption.Audience,
           claims: claims,
           notBefore: DateTime.UtcNow,
           expires: _accessTokenExpiration
            );
    }

    private JwtHeader CreateJwtHeader()
    {
        SecurityKey securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOption.Securitykey);
        SigningCredentials signingCredentials = SigninCredentialsHelper.CreateSigninCredentials(securityKey);
        JwtHeader jwtHeader = new JwtHeader(signingCredentials);
        return jwtHeader;
    }
}
