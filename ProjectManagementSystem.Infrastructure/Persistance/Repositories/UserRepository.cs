using ProjectManagementSystem.Application.Common.Interfaces.Persistance;
using ProjectManagementSystem.Domain.Aggregates.Users;

namespace ProjectManagementSystem.Infrastructure.Persistance.Repositories
{
    public class UserRepository : IUserRepository
    {
        private static readonly List<User> _users = new();
        private readonly ProjectManagementSystemDbContext _context;

        public UserRepository(ProjectManagementSystemDbContext context)
        {
            _context=context;
        }

        public async void AddUser(User user)
        {
            _users.Add(user);
            await _context.SaveChangesAsync();
        }

        public User? GetUserByEmail(string email)
        {
            return _users.FirstOrDefault(x => x.Email == email);
        }

        public User? GetUserById(Guid id)
        {
            return _users.FirstOrDefault(u => u.Id.Value == id);
        }

        public async Task<User?> UpdateUser(User userUpdate)
        {
            var user = _users.FirstOrDefault(x => x.Id.Value == userUpdate.Id.Value);
            if (user is not null)
            {
                user = userUpdate;
            }
            else
                return null;

            await _context.SaveChangesAsync();

            return user;
        }
    }
}
