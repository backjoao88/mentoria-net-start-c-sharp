namespace LibraryManagerApi.Core.Models.InputModels;

public class UserInputModel
{
    public string Name { get; set; }
    public string Email { get; set; }

    public UserInputModel(string name, string email)
    {
        Name = name;
        Email = email;
    }
}