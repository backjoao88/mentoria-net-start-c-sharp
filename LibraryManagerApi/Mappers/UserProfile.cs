using AutoMapper;
using LibraryManagerApi.Core.Entities;
using LibraryManagerApi.Core.Models.InputModels;
using LibraryManagerApi.Core.Models.ViewModels;

namespace LibraryManagerApi.Mappers;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserInputModel, User>();
        CreateMap<User, UserViewModel>();
    }
}