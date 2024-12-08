using FluentValidation;
using UserService.Application.Commands;

namespace UserService.Application.Validators;


public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{

    public UpdateUserCommandValidator()
    {
        RuleFor(u => u.Id)
            .NotEmpty()
            .NotNull()
            .WithMessage("{Id} is required")
            .GreaterThan(0)
            .WithMessage("{Id} cannot be -ve");

        RuleFor(u => u.Role)
            .NotEmpty()
            .NotNull()
            .Must(u => new[]{"Admin", "User"}.Contains(u))
            .WithMessage("{RoleName} is required and must be Admin or User");

    }


}