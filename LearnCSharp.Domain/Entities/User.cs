namespace LearnCSharp.Domain.Entities;

public class User
{
    public Guid Id { get; private set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public User(
        string firstName,
        string lastName,
        string username,
        string email,
        string password)
    {
        FirstName = firstName;
        LastName = lastName;
        Username = username;
        Email = email;
        Password = password;
    }
}