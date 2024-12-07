using MediatR;
using UserService.Application.Responses;

namespace UserService.Application.Commands;

public class CreateUserCommand: IRequest<UserResponse>
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Role { get; set; }
}