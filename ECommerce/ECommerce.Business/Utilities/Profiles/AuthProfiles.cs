using AutoMapper;
using Core.Entities.Concrete.Auth;

namespace ECommerce.Business.Utilities.Profiles;

public class AuthProfiles:Profile
{
    public AuthProfiles()
    {
        CreateMap<RegisterDto, AppUser>();
    }
}
