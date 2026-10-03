namespace LearnCSharp.Application.Users.DTOs;

public record UserDto(
    Guid Id,
    string? FirstName,
    string? LastName,
    string UserName,
    string Email,
    string Password);
