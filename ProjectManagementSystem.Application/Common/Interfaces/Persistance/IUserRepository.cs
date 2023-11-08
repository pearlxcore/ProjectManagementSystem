
using ProjectManagementSystem.Domain.Aggregates.Users;

namespace ProjectManagementSystem.Application.Common.Interfaces.Persistance
{
    public interface IUserRepository
    {
        void AddUser(User user);
        User? GetUserByEmail(string email);
        User? GetUserById(Guid id);
        Task<User?> UpdateUser(User userUpdate);
    }
}
