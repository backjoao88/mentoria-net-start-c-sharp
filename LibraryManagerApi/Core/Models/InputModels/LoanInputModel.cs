namespace LibraryManagerApi.Core.Models.InputModels;

public class LoanInputModel
{
    public int IdUser { get; set; }
    public int IdBook { get; set; }

    public LoanInputModel(int idUser, int idBook)
    {
        IdUser = idUser;
        IdBook = idBook;
    }
}