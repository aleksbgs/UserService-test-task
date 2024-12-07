using MediatR;
using UserService.Application.Mappers;
using UserService.Application.Queries;
using UserService.Application.Responses;
using UserService.Core.Entities;
using UserService.Core.Repositories;

namespace UserService.Application.Handlers;

public class GetAllUsersHandler:IRequestHandler<GetAllUsersQuery, IList<UserResponse>>
{
    private readonly IUserRepository _userRepository;

    public GetAllUsersHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<IList<UserResponse>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    { 
        var usersList = await _userRepository.GetAllUsers();
        var usersResponseList = UserMapper.Mapper.Map<IList<User>,IList<UserResponse>>(usersList.ToList());
        return usersResponseList;
    }
}