using AutoMapper;
using Core.Entities.Concrete.Auth;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Security.JWT;
using ECommerce.Business.Abstract;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace ECommerce.Business.Concrete;

public class AuthService : IAuthService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly ITokenHelper _tokenHelper;
    private readonly IMapper _mapper;

    public AuthService(UserManager<AppUser> userManager, ITokenHelper tokenHelper, IMapper mapper)
    {
        _userManager = userManager;
        _tokenHelper = tokenHelper;
        _mapper = mapper;
    }

    public async Task<IDataResult<AccessToken>> CreateTokenAsync(AppUser appUser)
    {
        IList<Claim> userClaims = await _userManager.GetClaimsAsync(appUser);
        AccessToken accessToken = _tokenHelper.CreateToken(userClaims.ToList());
        return new SuccessDataResult<AccessToken>(accessToken,"Login successfull");
    }

    public async Task<IDataResult<AppUser>> LoginAsync(LoginDto loginDto)
    {
        AppUser appUser = await _userManager.FindByNameAsync(loginDto.Username);
        if (appUser == null) return new ErrorDataResult<AppUser>("User does not exist");
        bool checkPassword=await _userManager.CheckPasswordAsync(appUser,loginDto.Password);
        if (!checkPassword) return new ErrorDataResult<AppUser>("UserName or Password is wrong!");
        return new SuccessDataResult<AppUser>(appUser,"Login Successfuly");
    }

    public async Task<IDataResult<AppUser>> RegisterAsync(RegisterDto registerDto)
    {
        AppUser appUser = await _userManager.FindByNameAsync(registerDto.Username);
        if (appUser != null) return new ErrorDataResult<AppUser>("User already exists");
        AppUser newUser = _mapper.Map<AppUser>(registerDto);
        IdentityResult result = await _userManager.CreateAsync(newUser, registerDto.Password);
        if (!result.Succeeded)
        {
            List<string> errors = new();
            foreach (var error in result.Errors)
                errors.Add(error.Description);
            return new ErrorDataResult<AppUser>(string.Join(',', errors));
        }
        await AddUserClaimAsync(newUser);
        return new SuccessDataResult<AppUser>(newUser, "Registered Successfully");
    }

    private async Task AddUserClaimAsync(AppUser newUser)
    {
        List<Claim> userClaims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier,newUser.Id),
            new Claim(ClaimTypes.Name,newUser.UserName),
            new Claim(ClaimTypes.Email,newUser.Email),
            new Claim("FullName",newUser.FullName),
        };
        await _userManager.AddClaimsAsync(newUser, userClaims);
    }
}
