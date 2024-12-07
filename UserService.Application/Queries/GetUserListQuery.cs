using MediatR;
using UserService.Application.Responses;

namespace UserService.Application.Queries;

public class GetUserListQuery:IRequest<List<UserResponse>>
{
    public string UserName { get; set; }
    public GetUserListQuery(string userName)
    {
        UserName = userName;
    }
}