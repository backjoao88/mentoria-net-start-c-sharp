using BloodManager.Abstractions.Mediator;
using BloodManager.Application.ViewModels;

namespace BloodManager.Application.Queries.GetStockById;

public class GetStockByIdQuery : IBkRequest<StockDetailedViewModel?>
{
    public GetStockByIdQuery(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}