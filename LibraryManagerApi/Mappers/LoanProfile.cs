using AutoMapper;
using LibraryManagerApi.Core.Entities;
using LibraryManagerApi.Core.Models.InputModels;
using LibraryManagerApi.Core.Models.ViewModels;

namespace LibraryManagerApi.Mappers;

public class LoanProfile : Profile
{
    public LoanProfile()
    {
        CreateMap<LoanInputModel, Loan>();
        CreateMap<Loan, LoanViewModel>();
    }
}