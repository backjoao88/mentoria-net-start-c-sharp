using BloodManager.Abstractions.Mediator;
using BloodManager.Application.ViewModels;
using BloodManager.Core;
using BloodManager.Core.Entities;

namespace BloodManager.Application.Commands.CreateStock;

public class CreateStockCommandHandler : IBkRequestHandler<CreateStockCommand, StockViewModel>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateStockCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<StockViewModel> HandleAsync(CreateStockCommand request)
    {
        var stock = new Stock(request.BloodType, request.RhFactorType, request.Description);
        await _unitOfWork.StockRepository.SaveAsync(stock);
        await _unitOfWork.CompleteAsync();
        var stockViewModel = new StockViewModel(stock.Id, stock.Description);
        return stockViewModel;
    }
}