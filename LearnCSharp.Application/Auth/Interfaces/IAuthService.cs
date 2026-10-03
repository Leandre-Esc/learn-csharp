using LearnCSharp.Application.Auth.DTOs;

namespace LearnCSharp.Application.Auth.Interfaces;

public interface IAuthService
{
    Task<SignInResponse> SignInAsync(SignInRequest request);
}