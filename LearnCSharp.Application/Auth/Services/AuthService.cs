using LearnCSharp.Application.Auth.DTOs;
using LearnCSharp.Application.Auth.Interfaces;
using LearnCSharp.Application.Users.Interfaces;

namespace LearnCSharp.Application.Auth.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _repository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtTokenGenerator _generator;

    public AuthService(IUserRepository repository, IPasswordHasher passwordHasher, IJwtTokenGenerator generator)
    {
        _repository = repository;
        _passwordHasher = passwordHasher;
        _generator = generator;
    }

    public async Task<SignInResponse> SignInAsync(SignInRequest request)
    {
        var user = await _repository.GetByEmailAsync(request.Email);

        if (user is null)
            throw new UnauthorizedAccessException("Invalid email or password");

        var passwordValid = _passwordHasher.Verify(
            user,
            user.Password,
            request.Password);

        if (!passwordValid)
            throw new UnauthorizedAccessException("Invalid email or password");

        var accessToken = _generator.GenerateToken(user);

        return new SignInResponse(accessToken);
    }
}