using BloodManager.Abstractions.Mediator;

namespace BloodManager.Application.Commands.DecreaseStock;

public class DecreaseStockCommand : IBkRequest
{
    public Guid Id { get; set; }
    public int QuantityMl { get; set; }
}