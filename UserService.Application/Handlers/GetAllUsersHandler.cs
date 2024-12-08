using MediatR;
using UserService.Application.Mappers;
using UserService.Application.Queries;
using UserService.Application.Responses;
using UserService.Core.Entities;
using UserService.Core.Repositories;

namespace UserService.Application.Handlers;

public class GetAllUsersHandler(IAsyncRepository<User> userRepository)
    : IRequestHandler<GetAllUsersQuery, IList<UserResponse>>
{
    public async Task<IList<UserResponse>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    { 
        var usersList = await userRepository.GetAllAsync();
        var usersResponseList = UserMapper.Mapper.Map<IList<User>,IList<UserResponse>>(usersList.ToList());
        return usersResponseList;
    }
}