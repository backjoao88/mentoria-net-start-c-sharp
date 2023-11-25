using Microsoft.AspNetCore.Mvc;

namespace LibraryManagerApi.Controllers;

[ApiController]
[Route("/api/users")]
public class UserController : ControllerBase
{
    /// <summary>
    /// Endpoints used for retrieving all users
    /// </summary>
    /// <returns>All users</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetAll()
    {
        return Ok();
    }
}