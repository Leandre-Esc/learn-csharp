namespace LearnCSharp.Application.Auth.DTOs;

public record SignInRequest(
    string Email,
    string Password);