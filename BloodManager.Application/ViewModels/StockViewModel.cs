namespace BloodManager.Application.ViewModels;

public class StockViewModel
{
    public StockViewModel(Guid id, string description)
    {
        Id = id;
        Description = description;
    }

    public Guid Id { get; set; }
    public string Description { get; set; }
}