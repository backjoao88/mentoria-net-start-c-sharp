using BloodDonationManager.Application.Commands.CreateDonation;
using BloodDonationManager.Application.Queries.GetAllDonations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonationManager.API.Controllers;

[ApiController]
[Route("api/donation")]
public class DonationController : ControllerBase
{
    public DonationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    private readonly IMediator _mediator;

    [HttpPost]
    public async Task<IActionResult> Post(CreateDonationCommand createDonationCommand)
    {
        var donation = await _mediator.Send(createDonationCommand);
        return Created(nameof(Post), donation);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var getAllDonationsQuery = new GetAllDonationsQuery("");
        var donations = await _mediator.Send(getAllDonationsQuery);
        return Ok(donations);
    }
}