using LibraryManagerApi.Core.Entities;

namespace LibraryManagerApi.Core.Models.ViewModels;

public class BookViewModel
{
    
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string Author { get; set; } = "";
    public string Isbn { get; set; } = "";
    public int PublicationYear { get; set; }
    public int Quantity { get; set; } = 0;
    public int MinQuantityAllowed { get; set; } = 0;
}