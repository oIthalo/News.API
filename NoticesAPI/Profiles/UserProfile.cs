using AutoMapper;
using NoticesAPI.Data.DTOs;
using NoticesAPI.Models;
namespace NoticesAPI.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserDtoRegister, User>().ReverseMap();
        CreateMap<UserDtoLogin, User>().ReverseMap();
        CreateMap<UserDtoRead, User>().ReverseMap();
    }
}