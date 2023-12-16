using BloodManager.Abstractions.Mediator;
using BloodManager.Application.ViewModels;
using BloodManager.Core.Enums;

namespace BloodManager.Application.Commands.CreateStock;

public class CreateStockCommand : IBkRequest<StockViewModel>
{
    public CreateStockCommand(string description, BloodType bloodType, RhFactorType rhFactorType)
    {
        Description = description;
        BloodType = bloodType;
        RhFactorType = rhFactorType;
    }

    public string Description { get; set; }
    public BloodType BloodType { get; set; }
    public RhFactorType RhFactorType { get; set; }
}