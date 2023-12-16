using BloodManager.Core.Enums;

namespace BloodManager.Application.ViewModels;

public class StockDetailedViewModel
{
    public StockDetailedViewModel(Guid id, string description, BloodType bloodType, RhFactorType rhFactorType, int quantity)
    {
        Id = id;
        Description = description;
        BloodType = bloodType;
        RhFactorType = rhFactorType;
        Quantity = quantity;
    }

    public Guid Id { get; set; }
    public string Description { get; set; }
    public BloodType BloodType { get; set; }
    public RhFactorType RhFactorType { get; set; }
    public int Quantity { get; set; }
}