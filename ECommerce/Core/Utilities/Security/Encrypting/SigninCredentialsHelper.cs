using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.Encrypting;

public static class SigninCredentialsHelper
{
    public static SigningCredentials CreateSigninCredentials(SecurityKey securityKey)
    {
        return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
    }
}
