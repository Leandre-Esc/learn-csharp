using LearnCSharp.Application.Users.DTOs;
using LearnCSharp.Application.Users.Services;
using Microsoft.AspNetCore.Mvc;

namespace LearnCSharp.Api.Controllers;

[ApiController]
[Route("/api/users")]
public class UserController : ControllerBase
{
    private readonly UserService _service;
    
    public UserController(UserService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<UserDto>> GetAll()
    {
        var users = await _service.GetAllAsync();
        return Ok(users);
    }
}