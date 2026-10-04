using Microsoft.AspNetCore.Mvc;

namespace LearnCSharp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PingController : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult> Ping()
    {
        return Ok(new
        {
            ping = "pong"
        });
    }
    
}