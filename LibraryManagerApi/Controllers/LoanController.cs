using Microsoft.AspNetCore.Mvc;

namespace LibraryManagerApi.Controllers;

[ApiController]
[Route("/api/loans")]
public class LoanController : ControllerBase
{
    /// <summary>
    /// Endpoints used for retrieving all loans
    /// </summary>
    /// <returns>All loans</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetAll()
    {
        return Ok();
    }
}