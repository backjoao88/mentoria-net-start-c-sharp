using DevFreela.Core.Entities.Interfaces;

namespace DevFreela.Core.Entities;

public class User : ISoftDeletable, IAuditable
{
    public User(string firstName, string lastName, string email, string role)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Role = role;
    }

    public Guid Id { get; private set; }
    public string FirstName { get; private set; } = "";
    public string LastName { get; private set; } = "";
    public string Email { get; private set; } = "";
    public string Role { get; private set; } = "";
    public bool IsDeleted { get; private set;  }
    public DateTime CreatedAt { get; private set; }
}