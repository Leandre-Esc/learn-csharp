using System.Text.Json.Serialization;

namespace LearnCSharp.Application.Users.DTOs;

public record CreateUserRequest(
    [property: JsonPropertyName("first_name")] string? FirstName,
    [property: JsonPropertyName("last_name")] string? LastName,
    string UserName,
    string Email,
    string Password);