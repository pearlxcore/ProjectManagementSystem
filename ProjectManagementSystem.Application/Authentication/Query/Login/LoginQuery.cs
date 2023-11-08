using ErrorOr;
using MediatR;
using ProjectManagementSystem.Application.Authentication.Common;

namespace ProjectManagementSystem.Application.Authentication.Query.Login
{
    public record LoginQuery(
        string Email,
        string Password) : IRequest<ErrorOr<AuthenticationResult>>;
}
