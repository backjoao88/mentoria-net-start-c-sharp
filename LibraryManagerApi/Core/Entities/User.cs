namespace LibraryManagerApi.Core.Entities;

public class User
{
    public int Id { get; private set; }
    public string Name { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public bool IsDeleted { get; private set; } = false;
    public User()
    {
    }

    public User(int id, string name, string email)
    {
        Id = id;
        Name = name;
        Email = email;
    }

    public void Update(string name, string email)
    {
        Name = name;
        Email = email;
    }

    public void Delete()
    {
        IsDeleted = true;
    }
    
}