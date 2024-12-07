using MediatR;
using UserService.Application.Responses;

namespace UserService.Application.Queries;

public class GetAllUsersQuery:IRequest<IList<UserResponse>>
{
    
}