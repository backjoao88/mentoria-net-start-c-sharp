using AutoMapper;
using LibraryManagerApi.Core.Entities;
using LibraryManagerApi.Core.Models.InputModels;
using LibraryManagerApi.Core.Models.ViewModels;

namespace LibraryManagerApi.Mappers;

public class BookProfile : Profile
{
    public BookProfile()
    {
        CreateMap<BookInputModel, Book>();
        CreateMap<Book, BookViewModel>();
    }
}