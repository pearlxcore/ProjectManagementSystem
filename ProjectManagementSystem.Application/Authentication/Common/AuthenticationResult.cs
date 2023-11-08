
using ProjectManagementSystem.Domain.Aggregates.Users;

namespace ProjectManagementSystem.Application.Authentication.Common
{
    public record AuthenticationResult(
        User User,
        string Token);
}
