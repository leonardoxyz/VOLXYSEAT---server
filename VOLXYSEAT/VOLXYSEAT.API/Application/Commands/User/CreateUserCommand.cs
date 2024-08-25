using MediatR;

namespace VOLXYSEAT.API.Application.Commands.User
{
    public record class CreateUserCommand(
        string Name,
        string Email,
        string Password,
        string PasswordConfirm,
        string Role) : IRequest<bool>
    {
    }
}
