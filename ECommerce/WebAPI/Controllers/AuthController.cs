﻿using Core.Entities.Concrete.Auth;
using ECommerce.Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto registerDto)
    {
        var result=await _authService.RegisterAsync(registerDto);
        if (!result.Success)
                return BadRequest(result);
        return Ok(result);
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        var result = await _authService.LoginAsync(loginDto);
        if (!result.Success)
            return BadRequest(result);
        var accessToken = await _authService.CreateTokenAsync(result.Data);
        return Ok(accessToken);
    }
}
