using BloodManager.Abstractions.Mediator;
using BloodManager.Application.ViewModels;
using BloodManager.Core;
using BloodManager.Core.Entities;

namespace BloodManager.Application.Queries.GetStockById;

public class GetStockByIdQueryHandler : IBkRequestHandler<GetStockByIdQuery, StockDetailedViewModel?>
{

    private readonly IUnitOfWork _unitOfWork;

    public GetStockByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<StockDetailedViewModel?> HandleAsync(GetStockByIdQuery request)
    {
        var stockId = new Stock(request.Id);
        var stock = await _unitOfWork.StockRepository.FindByIdAsync(stockId);
        if (stock is null)
        {
            return null;
        }
        var stocksViewModel = new StockDetailedViewModel(stock.Id, stock.Description, stock.BloodType, stock.RhFactorType, stock.Quantity);
        return stocksViewModel;
    }
}