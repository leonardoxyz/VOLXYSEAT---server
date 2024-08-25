using FluentValidation;

namespace VOLXYSEAT.API.Application.Commands.User
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotEmpty().MinimumLength(6);
            RuleFor(x => x.PasswordConfirm).Equal(x => x.Password);
            RuleFor(x => x.Role).Null();
        }
    }
}
