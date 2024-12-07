using FluentValidation;
using UserService.Application.Commands;

namespace UserService.Application.Validators;

public class UserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public UserCommandValidator()
    {
        RuleFor(u => u.Email)
            .NotEmpty()
            .WithMessage("{EmailAddress} is required");
    }
}