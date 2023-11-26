using AutoMapper;
using LibraryManagerApi.Core;
using LibraryManagerApi.Core.Entities;
using LibraryManagerApi.Core.Models.InputModels;
using LibraryManagerApi.Core.Models.ViewModels;
using LibraryManagerApi.Core.Validation;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagerApi.Controllers;

[ApiController]
[Route("/api/users")]
public class UserController : ControllerBase
{
    
    readonly IMapper _mapper;
    readonly IValidation<UserInputModel> _validation;
    readonly IUnitOfWork _unitOfWork;

    public UserController(IMapper mapper, IValidation<UserInputModel> validation, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _validation = validation;
        _unitOfWork = unitOfWork;
    }
    
    /// <summary>
    /// Endpoint used for retrieving all users
    /// </summary>
    /// <returns>All users</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetAll()
    {
        var users = _unitOfWork.UserRepository.FindAll();
        var usersViewModel = _mapper.Map<List<UserViewModel>>(users);
        return Ok(usersViewModel);
    }

    /// <summary>
    /// Endpoint used for saving a new user
    /// </summary>
    /// <param name="userInputModel"></param>
    /// <returns>Nothing</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Save(UserInputModel userInputModel)
    {
        var validationResult = _validation.IsValid(userInputModel);
        if (!validationResult.IsSuccess)
        {
            return BadRequest(validationResult.Message);
        }
        var user = _mapper.Map<UserInputModel, User>(userInputModel);
        _unitOfWork.UserRepository.Save(user);
        _unitOfWork.Complete();
        var userViewModel = _mapper.Map<User, UserViewModel>(user);
        return Created(nameof(Save), userViewModel);
    }

    /// <summary>
    /// Endpoint used for retrieving a specified user
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetById(Guid id)
    {
        var user = _unitOfWork.UserRepository.FindById(id);
        if (user is null)
        {
            return NotFound();
        }
        var userViewModel = _mapper.Map<User, UserViewModel>(user);
        return Ok(userViewModel);
    }
    
    /// <summary>
    /// Endpoint used for updating a user
    /// </summary>
    /// <param name="id"></param>
    /// <param name="userInputModel"></param>
    /// <returns>Nothing</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Update(Guid id, UserInputModel userInputModel)
    {
        var user = _unitOfWork.UserRepository.FindById(id);
        if (user is null)
        {
            return NotFound();
        }
        user.Update(
            userInputModel.Name.Any() ? userInputModel.Name : user.Name,
            userInputModel.Email.Any() ? userInputModel.Email : user.Email
        );
        _unitOfWork.Complete();
        return NoContent();
    }
    
    /// <summary>
    /// Endpoint used for removing a user
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Nothing</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Remove(Guid id)
    {
        var user = _unitOfWork.UserRepository.FindById(id);
        if (user is null)
        {
            return NotFound();
        }
        user.Delete();
        _unitOfWork.Complete();
        return NoContent();
    }
    
}