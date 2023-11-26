namespace LibraryManagerApi.Core.Models.ViewModels;

public class UserViewModel
{
    
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public UserViewModel(string name, string email)
    {
        Name = name;
        Email = email;
    }
}