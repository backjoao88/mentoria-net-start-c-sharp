using AutoMapper;
using LibraryManagerApi.Core;
using LibraryManagerApi.Core.Entities;
using LibraryManagerApi.Core.Models.InputModels;
using LibraryManagerApi.Core.Models.ViewModels;
using LibraryManagerApi.Core.Validation;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagerApi.Controllers;

[ApiController]
[Route("/api/loans")]
public class LoanController : ControllerBase
{
    
    readonly IMapper _mapper;
    readonly IValidation<LoanInputModel> _validation;
    readonly IUnitOfWork _unitOfWork;

    public LoanController(IMapper mapper, IValidation<LoanInputModel> validation, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _validation = validation;
        _unitOfWork = unitOfWork;
    }
    
    /// <summary>
    /// Endpoint used for saving a new loan
    /// </summary>
    /// <param name="loanInputModel"></param>
    /// <returns>The loan created</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Save(LoanInputModel loanInputModel)
    {
        var validationResult = _validation.IsValid(loanInputModel);
        if (!validationResult.IsSuccess)
        {
            return BadRequest(validationResult.Message);
        }
        var loan = _mapper.Map<LoanInputModel, Loan>(loanInputModel);
        var startDate = DateTime.Now;
        loan.Update(startDate, startDate.AddDays(7), default);
        _unitOfWork.LoanRepository.Save(loan);
        _unitOfWork.Complete();
        var loanViewModel = _mapper.Map<Loan, LoanViewModel>(loan);
        return Created(nameof(Save), loanViewModel);
    }
    
    /// <summary>
    /// Endpoint used for retrieving all loans
    /// </summary>
    /// <returns>All loans</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetAll()
    {
        var books = _unitOfWork.LoanRepository.FindAll();
        var loansViewModel = _mapper.Map<List<LoanViewModel>>(books);
        return Ok(loansViewModel);
    }
    
    /// <summary>
    /// Endpoint used for retrieving a specified loan
    /// </summary>
    /// <returns>The loan requested</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetById(Guid id)
    {
        var loan = _unitOfWork.LoanRepository.FindById(id);
        if (loan is null)
        {
            return NotFound();
        }
        var loanViewModel = _mapper.Map<Loan, LoanViewModel>(loan);
        return Ok(loanViewModel);
    }
    
    /// <summary>
    /// Endpoint used for marking a loan as returned
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Nothing</returns>
    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult PatchDevolution(Guid id)
    {
        var loan = _unitOfWork.LoanRepository.FindById(id);
        if (loan is null)
        {
            return NotFound();
        }
        loan.Return();
        _unitOfWork.Complete();
        return NoContent();
    }
}