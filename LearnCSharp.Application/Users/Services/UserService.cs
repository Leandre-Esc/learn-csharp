using LearnCSharp.Application.Users.DTOs;
using LearnCSharp.Application.Users.Interfaces;
using LearnCSharp.Domain.Entities;

namespace LearnCSharp.Application.Users.Services;

public class UserService
{
    private readonly IUserRepository _repository;
    private readonly IPasswordHasher _passwordHasher;

    public UserService(IUserRepository repository, IPasswordHasher passwordHasher)
    {
        _repository = repository;
        _passwordHasher = passwordHasher;
    }
    
    public async Task<List<UserDto> > GetAllAsync()
    {
        var users = await _repository.GetAllAsync();

        return users
            .Select(MapToDto)
            .ToList();
    }

    public async Task<UserDto?> GetByIdAsync(Guid id)
    {
        var user = await _repository.GetByIdAsync(id);

        return user == null
            ? null
            : MapToDto(user);
    }

    public async Task<UserDto> CreatAsync(CreateUserRequest request)
    {
        var exist = await _repository.GetByEmailAsync(request.Email);

        if (exist is not null)
        {
            throw new InvalidOperationException("User with same email already exists");
        }
        
        var user = new User(
            request.FirstName,
            request.LastName,
            request.UserName,
            request.Email,
            request.Password);

        user.Password = _passwordHasher.Hash(user, request.Password);
        
        await _repository.AddAsync(user);
        
        return MapToDto(user);
    }

    public async Task<bool> UpdateAsync(Guid id, UpdateUserRequest request)
    {
        var user = await _repository.GetByIdAsync(id);

        if (user == null)
            return false;
        
        user.Update(
            request.FirstName,
            request.LastName,
            request.UserName,
            request.Email);

        await _repository.UpdateAsync(user);

        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var user = await _repository.GetByIdAsync(id);
        
        if (user == null)
            return false;
        
        await _repository.DeleteAsync(user);
        
        return true;
    }

    private static UserDto MapToDto(User user)
    {
        return new UserDto(
            user.Id,
            user.FirstName,
            user.LastName,
            user.Username,
            user.Email,
            user.Password);
    }
}
