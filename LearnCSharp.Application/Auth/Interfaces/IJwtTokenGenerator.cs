using LearnCSharp.Domain.Entities;

namespace LearnCSharp.Application.Auth.Interfaces;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}