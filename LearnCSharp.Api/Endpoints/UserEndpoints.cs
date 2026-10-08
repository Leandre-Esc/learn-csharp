using LearnCSharp.Application.Users.DTOs;
using LearnCSharp.Application.Users.Services;

namespace LearnCSharp.Api.Endpoints;

public static class UserEndpoints
{
    public static RouteGroupBuilder MapUserEndpoints(this RouteGroupBuilder group)
    {
        group.MapGet("/", async (UserService service) =>
        {
            var users = await service.GetAllAsync();
            return Results.Ok(users);
        })
        .RequireAuthorization();

        group.MapGet("/{id:guid}", async (Guid id, UserService service) =>
        {
            var user = await service.GetByIdAsync(id);

            return user is null 
                ? Results.NotFound()
                : Results.Ok(user);
        })
        .RequireAuthorization();

        group.MapPost("/", async (CreateUserRequest request, UserService service) =>
        {
            try
            {
                var user = await service.CreatAsync(request);
                return Results.Created($"/api/users/{user.Id}", user);
            }
            catch (InvalidOperationException e)
            {
                return Results.Conflict(new
                {
                    message = e.Message
                });
            }
        });

        group.MapPut("/{id:guid}", async (Guid id, UpdateUserRequest request, UserService service) =>
        {
            var isUpdated = await service.UpdateAsync(id, request);
            
            return !isUpdated ? Results.NotFound() : Results.NoContent();
        })
        .RequireAuthorization();

        group.MapDelete("/{id:guid}", async (Guid id, UserService service) =>
        {
            var isDeleted = await service.DeleteAsync(id);
            
            return !isDeleted ? Results.NotFound() : Results.NoContent();
        })
        .RequireAuthorization();
        
        return group;
    }
}