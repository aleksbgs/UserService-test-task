using MediatR;
using UserService.Application.Commands;
using UserService.Application.Exceptions;
using UserService.Application.Mappers;
using UserService.Core.Entities;
using UserService.Core.Repositories;

namespace UserService.Application.Handlers;

public class UpdateUserCommandHandler(IAsyncRepository<User> userRepository) : IRequestHandler<UpdateUserCommand, Unit>
{
    public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var userToUpdate = await userRepository.GetByIdAsync(request.Id);
        if (userToUpdate == null) 
        {
            throw new UserNotFoundException(nameof(User), request.Id);
        }
        UserMapper.Mapper.Map(request, userToUpdate, typeof(UpdateUserCommand), typeof(User));
        await userRepository.UpdateAsync(userToUpdate);
        return Unit.Value;
    }
}