using AutoMapper;
using ConfitecAPIApplication.DTOs.User;
using ConfitecAPIApplication.Interfaces;
using ConfitecAPIBusiness.DTO;
using ConfitecAPIBusiness.Models;

namespace ConfitecAPIApplication.AutoMapper;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDTO>().ReverseMap();
        CreateMap<User, UserByIdDTO>().ReverseMap();
        CreateMap<User, CreateUserRequestDTO>().ReverseMap();
        CreateMap<User, CreateUserResponseDTO>().ReverseMap();
        CreateMap<User, UpdateUserDTO>().ReverseMap();
    }
}