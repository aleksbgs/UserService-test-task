using MediatR;
using UserService.Application.Commands;
using UserService.Application.Exceptions;
using UserService.Application.Mappers;
using UserService.Core.Entities;
using UserService.Core.Repositories;

namespace UserService.Application.Handlers;

public class UpdateUserCommandHandler: IRequestHandler<UpdateUserCommand,Unit>
{
    private readonly IUserRepository _userRepository;

    public UpdateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }


    public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var userToUpdate = await _userRepository.GetByIdAsync(request.Id);
        if (userToUpdate == null) 
        {
            throw new UserNotFoundException(nameof(User), request.Id);
        }
        UserMapper.Mapper.Map(request, userToUpdate, typeof(UpdateUserCommand), typeof(User));
        await _userRepository.UpdateAsync(userToUpdate);
        return Unit.Value;
    }
}