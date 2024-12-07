using AutoMapper;
using UserService.Application.Commands;
using UserService.Application.Responses;
using UserService.Core.Entities;

namespace UserService.Application.Mappers;

public class UserMappingProfile: Profile
{
    public UserMappingProfile()
    {
        CreateMap<User, UserResponse>().ReverseMap();
        CreateMap<User, CreateUserCommand>().ReverseMap();
        CreateMap<User, UpdateUserCommand>().ReverseMap();
    }
}