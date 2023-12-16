using BloodManager.Abstractions.Mediator;
using BloodManager.Application.Commands.CreateStock;
using BloodManager.Application.Commands.DecreaseStock;
using BloodManager.Application.Commands.IncreaseStock;
using BloodManager.Application.Queries.GetStockById;
using BloodManager.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BloodManager.API.Controllers;

[ApiController]
[Route("api/stocks")]
public class StockController : ControllerBase
{
    private readonly IBkMediator _bkMediator;

    public StockController(IBkMediator bkMediator)
    {
        _bkMediator = bkMediator;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Save(CreateStockCommand createStockCommand)
    {
        var stockViewModel = await _bkMediator.SendAsync<CreateStockCommand, StockViewModel>(createStockCommand);
        return Created(nameof(Save), stockViewModel);
    }

    [HttpPatch("{id}/increase")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Increase(IncreaseStockCommand increaseStockCommand)
    {
        await _bkMediator.SendAsync(increaseStockCommand);
        return NoContent();
    }

    [HttpPatch("{id}/decrease")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Decrease(DecreaseStockCommand decreaseStockCommand)
    {
        await _bkMediator.SendAsync(decreaseStockCommand);
        return NoContent();
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(Guid id)
    {
        var getStockById = new GetStockByIdQuery(id);
        var stockViewModel = await _bkMediator.SendAsync<GetStockByIdQuery, StockDetailedViewModel?>(getStockById);
        if (stockViewModel is null)
        {
            return NotFound();
        }
        return Ok(stockViewModel);
    }
}