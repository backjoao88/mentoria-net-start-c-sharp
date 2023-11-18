using System;
using System.Collections.Generic;
using System.Linq;
using AwesomeDevEvents.Core;
using AwesomeDevEvents.Core.Models;
using AwesomeDevEvents.Persistence;
using Microsoft.AspNetCore.Mvc;
namespace AwesomeDevEvents.Controllers
{
    [Route("api/dev-events")]
    [ApiController]
    public class DevEventsController : ControllerBase
    {
        readonly IUnitOfWork _unitOfWork;
        public DevEventsController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            var devEvents = _unitOfWork.DevEventRepository.FindAll();
            return Ok(devEvents);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var devEvent = _unitOfWork.DevEventRepository.FindById(id);
            return Ok(devEvent);
        }

        [HttpPost]
        public IActionResult Post(DevEvent devEvent)
        {
            _unitOfWork.DevEventRepository.Save(devEvent);
            _unitOfWork.Complete();
            return CreatedAtAction(nameof(GetById), new { id = devEvent.Id }, devEvent);
        }
    }
}