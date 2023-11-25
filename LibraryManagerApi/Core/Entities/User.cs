namespace LibraryManagerApi.Core.Entities;

public class User
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = null!;
    public string Email { get; private set; } = null!;

    public User()
    {
    }

    public User(Guid id, string name, string email)
    {
        Id = id;
        Name = name;
        Email = email;
    }
}