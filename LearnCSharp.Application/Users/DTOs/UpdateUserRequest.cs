namespace LearnCSharp.Application.Users.DTOs;

public record UpdateUserRequest(
    string FirstName,
    string LastName,
    string UserName,
    string Email,
    string Password);