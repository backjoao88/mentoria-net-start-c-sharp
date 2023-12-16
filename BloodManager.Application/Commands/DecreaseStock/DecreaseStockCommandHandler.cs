using BloodManager.Abstractions.Mediator;
using BloodManager.Core;
using BloodManager.Core.Entities;

namespace BloodManager.Application.Commands.DecreaseStock;

public class DecreaseStockCommandHandler : IBkRequestHandler<DecreaseStockCommand>
{
    public DecreaseStockCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    private readonly IUnitOfWork _unitOfWork;

    public async Task HandleAsync(DecreaseStockCommand request)
    {
        var stockId = new Stock(request.Id);
        var stock = await _unitOfWork.StockRepository.FindByIdAsync(stockId);
        if (stock is null)
        {
            return;
        }

        stock.Decrease(request.QuantityMl);
        await _unitOfWork.CompleteAsync();
    }
}