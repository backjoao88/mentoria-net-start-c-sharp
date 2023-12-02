using LibraryManagerApi.Core.Entities;
namespace LibraryManagerApi.Core.Models.ViewModels;

public class LoanViewModel
{
    public int Id { get; set; }
    public int IdUser { get; set; }
    public UserViewModel User { get; set; } = null!;
    public int IdBook { get; set; }
    public BookViewModel Book { get; set; } = null!;
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public DateTime Devolution { get; set; }
    
}