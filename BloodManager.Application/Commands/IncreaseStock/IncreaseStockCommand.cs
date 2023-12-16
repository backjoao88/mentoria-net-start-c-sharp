using BloodManager.Abstractions.Mediator;

namespace BloodManager.Application.Commands.IncreaseStock;

public class IncreaseStockCommand : IBkRequest
{
    public IncreaseStockCommand(Guid id, int quantityMl)
    {
        Id = id;
        QuantityMl = quantityMl;
    }
    
    public Guid Id { get; set; }
    public int QuantityMl { get; set; }
}