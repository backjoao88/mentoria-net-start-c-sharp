using AutoMapper;
using LibraryManagerApi.Core;
using LibraryManagerApi.Core.Entities;
using LibraryManagerApi.Core.Models.InputModels;
using LibraryManagerApi.Core.Models.ViewModels;
using LibraryManagerApi.Core.Validation;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagerApi.Controllers;

[ApiController]
[Route("/api/books")]
public class BookController : ControllerBase
{
    readonly IMapper _mapper;
    readonly IValidation<BookInputModel> _validation;
    readonly IUnitOfWork _unitOfWork;
    public BookController(IMapper mapper, IValidation<BookInputModel> validation, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _validation = validation;
        _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Endpoint used saving a new book
    /// </summary>
    /// <returns>All books</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Save(BookInputModel bookInputModel)
    {
        var validationResult = _validation.IsValid(bookInputModel);
        if (!validationResult.IsSuccess)
        {
            return BadRequest(validationResult.Message);
        }
        var book = _mapper.Map<BookInputModel, Book>(bookInputModel);
        _unitOfWork.BookRepository.Save(book);
        _unitOfWork.Complete();
        return Created(nameof(Save), book);
    }
    
    /// <summary>
    /// Endpoint used for retrieving all books
    /// </summary>
    /// <returns>All books</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetAll()
    {
        var books = _unitOfWork.BookRepository.FindAll();
        var booksViewModel = _mapper.Map<List<BookViewModel>>(books);
        foreach (var book in books)
        {
            Console.WriteLine(book.Id);
        }
        return Ok(booksViewModel);
    }

    /// <summary>
    /// Endpoint used for retrieving a specified book
    /// </summary>
    /// <returns>All books</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetById(int id)
    {
        var book = _unitOfWork.BookRepository.FindById(id);
        if (book is null)
        {
            return NotFound();
        }

        var bookViewModel = _mapper.Map<Book, BookViewModel>(book);
        return Ok(bookViewModel);
    }


    /// <summary>
    /// Endpoint used for updating a specified book
    /// </summary>
    /// <returns>Nothing</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Update(int id, BookInputModel bookInputModel)
    {
        var book = _unitOfWork.BookRepository.FindById(id);
        if (book is null)
        {
            return NotFound();
        }
        
        book.Update(
            bookInputModel.Title.Any() ? bookInputModel.Title : book.Title, 
            bookInputModel.Author.Any() ? bookInputModel.Author : book.Author, 
            bookInputModel.Isbn.Any() ? bookInputModel.Isbn : book.Isbn, 
            bookInputModel.PublicationYear != 0 ? bookInputModel.PublicationYear : book.PublicationYear
        );
        
        _unitOfWork.Complete();
        return NoContent();
    }
    
    /// <summary>
    /// Endpoint used for removing a specified book
    /// </summary>
    /// <returns>Nothing</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Remove(int id)
    {
        var book = _unitOfWork.BookRepository.FindById(id);
        if (book is null)
        {
            return NotFound();
        }
        book.Delete();
        _unitOfWork.Complete();
        return Ok();
    }
    
}