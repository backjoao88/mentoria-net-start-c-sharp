using System;
using System.Collections.Generic;
using System.Linq;
using AwesomeDevEvents.Models;
using AwesomeDevEvents.Persistence;
using Microsoft.AspNetCore.Mvc;
namespace AwesomeDevEvents.Controllers
{
    [Route("api/dev-events")]
    [ApiController]
    public class DevEventsController : ControllerBase
    {

        readonly DevEventsDbContext _devEventsDbContext;

        public DevEventsController(DevEventsDbContext devEventsDbContext)
        {
            this._devEventsDbContext = devEventsDbContext;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            var devEvents = _devEventsDbContext.DevEvents.ToList();
            return Ok(devEvents);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var devEvent = _devEventsDbContext.DevEvents.Where((d) => d.Id == id);
            return Ok(devEvent);
        }
    }
}