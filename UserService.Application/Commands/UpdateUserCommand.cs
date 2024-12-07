using MediatR;

namespace UserService.Application.Commands;

public class UpdateUserCommand : IRequest<Unit>
{
    public int Id { get; set; } 
    public string? Role { get; set; }
}