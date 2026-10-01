namespace LearnCSharp.Application.Users.DTOs;

public record CreateUserRequest(
    string? FirstName,
    string? LastName,
    string UserName,
    string Email,
    string Password);