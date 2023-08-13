using Microsoft.AspNetCore.Identity;

namespace Core.Entities.Concrete.Auth;

public class AppRole:IdentityRole
{
    public bool IsDeleted { get; set; }
}
