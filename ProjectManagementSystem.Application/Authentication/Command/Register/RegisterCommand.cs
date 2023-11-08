using ErrorOr;
using MediatR;
using ProjectManagementSystem.Application.Authentication.Common;

namespace ProjectManagementSystem.Application.Authentication.Command.Register
{
    public record RegisterCommand(
        string FirstName,
        string LastName,
        string Email,
        string Password,
        string Role,
        UserContactCommand UserContact) : IRequest<ErrorOr<AuthenticationResult>>;

    public record UserContactCommand(
        string Phone,
        string Address);
}
