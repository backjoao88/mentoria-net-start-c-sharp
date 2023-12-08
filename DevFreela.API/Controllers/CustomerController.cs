using DevFreela.Application.Commands.CreateCustomer;
using DevFreela.Application.Commands.UpdateCustomer;
using DevFreela.Application.Queries.GetAllCustomers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers;

[ApiController]
[Route("/api/customers")]
public class CustomerController : ControllerBase
{
    private readonly IMediator _mediator;

    public CustomerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Endpoint used for saving a customer
    /// </summary>
    /// <returns>201</returns>
    /// <returns>400</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Save(CreateCustomerCommand createCustomerCommand)
    {
        var customerViewModel = await _mediator.Send(createCustomerCommand);
        return Created(nameof(Save), customerViewModel);
    }

    /// <summary>
    /// Endpoint used for update a customer
    /// </summary>
    /// <returns>204</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Update(Guid id, UpdateCustomerCommand updateCustomerCommand)
    {
        await _mediator.Send(updateCustomerCommand);
        return NoContent();
    }

    /// <summary>
    /// Endpoint used for return all customers
    /// </summary>
    /// <returns>200</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var getAllProjectsQuery = new GetAllCustomersQuery("");
        var customers = await _mediator.Send(getAllProjectsQuery);
        return Ok(customers);
    }
}