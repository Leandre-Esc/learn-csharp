using LearnCSharp.Application.Auth.DTOs;
using LearnCSharp.Application.Auth.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LearnCSharp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _service;
    
    public AuthController(IAuthService service)
    {
        _service = service;
    }

    public async Task<ActionResult<SignInResponse>> SignIn([FromBody] SignInRequest request)
    {
        var response = await _service.SignInAsync(request);
        return Ok(response);
    }
}