
using ProjectManagementSystem.Domain.Aggregates.Users;

namespace ProjectManagementSystem.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
