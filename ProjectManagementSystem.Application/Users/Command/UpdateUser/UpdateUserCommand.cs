using ErrorOr;
using MediatR;
using ProjectManagementSystem.Domain.Aggregates.Users;

namespace ProjectManagementSystem.Application.Users.Command.UpdateUser
{
    public record UpdateUserCommand(
        Guid Id,
        string FirstName,
        string LastName,
        string Email,
        string Password,
        string Role,
        UserContactCommand UserContact) : IRequest<ErrorOr<User>>;

    public record UserContactCommand(
        string Phone,
        string Address);
}
