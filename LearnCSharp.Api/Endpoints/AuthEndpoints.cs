using LearnCSharp.Application.Auth.DTOs;
using LearnCSharp.Application.Auth.Services;

namespace LearnCSharp.Api.Endpoints;

public static class AuthEndpoints
{
    public static RouteGroupBuilder MapAuthEndpoints(this RouteGroupBuilder group)
    {
        group.MapPost("/", async (SignInRequest request, AuthService service) =>
        {
            var response = await service.SignInAsync(request);
            return Results.Ok(response);
        });
        
        return group;
    }
}