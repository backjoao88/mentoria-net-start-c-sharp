using BloodDonationManager.Application.Commands.CreateDonor;
using BloodDonationManager.Application.Queries.GetAllDonors;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonationManager.API.Controllers;

[ApiController]
[Route("/api/donor")]
public class DonorController : ControllerBase
{
    public DonorController(IMediator mediator)
    {
        _mediator = mediator;
    }

    private readonly IMediator _mediator;

    [HttpPost]
    public async Task<IActionResult> Post(CreateDonorCommand createDonorCommand)
    {
        var result = await _mediator.Send(createDonorCommand);
        return Created(nameof(Post), result);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var getAllDonors = new GetAllDonorsQuery("");
        var donors = await _mediator.Send(getAllDonors);
        return Ok(donors);
    }
}