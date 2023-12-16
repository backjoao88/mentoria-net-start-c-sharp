using BloodManager.Abstractions.Mediator;
using BloodManager.Application.Commands.CreateDonation;
using BloodManager.Application.Queries.GetAllDonations;
using BloodManager.Application.Validations.FluentValidation;
using BloodManager.Application.ViewModels;
using BloodManager.Core.Validations;
using Microsoft.AspNetCore.Mvc;

namespace BloodManager.API.Controllers;

[ApiController]
[Route("api/donation")]
public class DonationController : ControllerBase
{
    private readonly IBkMediator _bkMediator;
    private readonly IValidation<CreateDonationCommand> _validation;
    
    public DonationController(IBkMediator bkMediator, IValidation<CreateDonationCommand> validation)
    {
        _bkMediator = bkMediator;
        _validation = validation;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Save(CreateDonationCommand createDonationCommand)
    {
        var validationResult = await _validation.IsValidAsync(createDonationCommand);
        if (!validationResult.Success)
        {
            return BadRequest(validationResult.Errors);
        }
        var donationViewModel =
            await _bkMediator.SendAsync<CreateDonationCommand, DonationDetailedViewModel>(createDonationCommand);
        return Ok(donationViewModel);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var getAllDonationsQuery = new GetAllDonationsQuery();
        var donationsViewModel = await _bkMediator.SendAsync<GetAllDonationsQuery, List<DonationDetailedViewModel>>(getAllDonationsQuery);
        return Ok(donationsViewModel);
    }
}