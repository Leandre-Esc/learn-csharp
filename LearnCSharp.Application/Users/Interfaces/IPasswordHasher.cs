using LearnCSharp.Domain.Entities;

namespace LearnCSharp.Application.Users.Interfaces;

public interface IPasswordHasher
{
    string Hash(User user, string password);
    bool Verify(User user, string hashedPassword, string providedPassword);
}