using ProjectManagementSystem.Application.Common.Interfaces.Persistance;
using ProjectManagementSystem.Domain.Aggregates.Users;

namespace ProjectManagementSystem.Infrastructure.Persistance.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ProjectManagementSystemDbContext _context;

        public UserRepository(ProjectManagementSystemDbContext context)
        {
            _context=context;
        }

        public async void AddUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public User? GetUserByEmail(string email)
        {
            return _context.Users.AsEnumerable().FirstOrDefault(x => x.Email == email);
        }

        public User? GetUserById(Guid id)
        {
            return _context.Users.AsEnumerable().FirstOrDefault(u => u.Id.Value == id);
        }

        public async Task<User?> UpdateUser(User userUpdate)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id.Value == userUpdate.Id.Value);
            if (user is not null)
            {
                user = userUpdate;
                await _context.SaveChangesAsync();
            }
            else
                return null;

            return user;
        }
    }
}
