namespace LearnCSharp.Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    public User(
        string? firstName,
        string? lastName,
        string username,
        string email,
        string password)
    {
        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        Username = username;
        Email = email;
        Password = password;
        
        CreatedAt = DateTime.UtcNow;
    }

    public void Update(
        string? firstName,
        string? lastName,
        string username,
        string email)
    {
        FirstName = firstName;
        LastName = lastName;
        Username = username;
        Email = email;
        
        UpdatedAt = DateTime.UtcNow;
    }
}