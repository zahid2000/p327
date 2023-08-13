﻿using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Core.Utilities.Security.Encrypting;

public static class SecurityKeyHelper
{
    public static SecurityKey CreateSecurityKey(string securityKey)
    {
        return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
    }
}
