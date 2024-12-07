using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using UserService.Application.Commands;
using UserService.Application.Mappers;
using UserService.Application.Responses;
using UserService.Core.Entities;
using UserService.Core.Repositories;

namespace UserService.Application.Handlers;

public class CreateUserCommandHandler: IRequestHandler<CreateUserCommand, UserResponse>
{
    private readonly IUserRepository _userRepository;
    
    public CreateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<UserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var userEntity = UserMapper.Mapper.Map<User>(request);
        var passwordHash = BCrypt.Net.BCrypt.HashPassword(userEntity.Password);
        userEntity.Password = passwordHash;
        
        if (userEntity is null) 
        {
            throw new ApplicationException("There is an issue with mapping while creating new user");
        }
        var newUser = await _userRepository.AddAsync(userEntity);
        var userResponse = UserMapper.Mapper.Map<UserResponse>(newUser);
        return userResponse;
    }
}