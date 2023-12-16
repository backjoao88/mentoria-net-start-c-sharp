using BloodManager.Abstractions.Mediator;
using BloodManager.Core;
using BloodManager.Core.Entities;

namespace BloodManager.Application.Commands.IncreaseStock;

public class IncreaseStockCommandHandler : IBkRequestHandler<IncreaseStockCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public IncreaseStockCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task HandleAsync(IncreaseStockCommand request)
    {
        var stockId = new Stock(request.Id);
        var stock = await _unitOfWork.StockRepository.FindByIdAsync(stockId);
        if (stock is null)
        {
            return;
        }
        stock.Increase(request.QuantityMl);
        await _unitOfWork.CompleteAsync();
    }
}