using BloodManager.Abstractions.Mediator;
using BloodManager.Application.Commands.CreateDonor;
using BloodManager.Application.Commands.DeleteDonor;
using BloodManager.Application.Commands.UpdateDonor;
using BloodManager.Application.Queries.GetAllDonors;
using BloodManager.Application.Queries.GetDonorById;
using BloodManager.Application.ViewModels;
using BloodManager.Core.Entities;
using BloodManager.Core.Validations;
using Microsoft.AspNetCore.Mvc;

namespace BloodManager.API.Controllers;

[ApiController]
[Route("/api/donor")]
public class DonorController : ControllerBase
{
    public DonorController(IBkMediator bkMediator, IValidation<CreateDonorCommand> validation)
    {
        _bkMediator = bkMediator;
        _validation = validation;
    }

    private readonly IBkMediator _bkMediator;
    private readonly IValidation<CreateDonorCommand> _validation;

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Save(CreateDonorCommand createDonorCommand)
    {
        var validationResult = await _validation.IsValidAsync(createDonorCommand);
        if (!validationResult.Success)
        {
            return BadRequest(validationResult.Errors);
        }
        var donorViewModel = await _bkMediator.SendAsync<CreateDonorCommand, DonorViewModel>(createDonorCommand);
        return Created(nameof(Save), donorViewModel);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> RetrieveAll()
    {
        var getAllQuery = new GetAllDonorsQuery();
        var donors = await _bkMediator.SendAsync<GetAllDonorsQuery, List<DonorDetailedViewModel>>(getAllQuery);
        return Ok(donors);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Update(UpdateDonorCommand updateDonorCommand)
    {
        await _bkMediator.SendAsync(updateDonorCommand);
        return NoContent();
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetById(Guid id)
    {
        var getByIdQuery = new GetDonorByIdQuery(id);
        var donorViewModel = await _bkMediator.SendAsync<GetDonorByIdQuery, DonorDetailedViewModel?>(getByIdQuery);
        if (donorViewModel is null)
        {
            return NotFound();
        }
        return Ok(donorViewModel);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Delete(Guid id, DeleteDonorCommand deleteDonorCommand)
    {
        deleteDonorCommand.Id = id;
        var donorViewModel = await _bkMediator.SendAsync<DeleteDonorCommand, DonorViewModel?>(deleteDonorCommand);
        if (donorViewModel is null)
        {
            return NotFound();
        }
        return NoContent();
    }
}