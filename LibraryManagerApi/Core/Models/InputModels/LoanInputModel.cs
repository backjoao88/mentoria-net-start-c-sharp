namespace LibraryManagerApi.Core.Models.InputModels;

public class LoanInputModel
{
    public Guid IdUser { get; set; }
    public Guid IdBook { get; set; }

    public LoanInputModel(Guid idUser, Guid idBook)
    {
        IdUser = idUser;
        IdBook = idBook;
    }
}