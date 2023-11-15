using ProjectManagementSystem.Application.Common.Interfaces.Persistance;
using ProjectManagementSystem.Domain.Aggregates.Clients;

namespace ProjectManagementSystem.Infrastructure.Persistance.Repositories
{
    public class ClientRespository : IClientRepository
    {
        private readonly ProjectManagementSystemDbContext _context;

        public ClientRespository(ProjectManagementSystemDbContext context)
        {
            _context=context;
        }

        public async Task AddClient(Client client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
        }

        public Client? GetClientByEmail(string email)
        {
            return _context.Clients.AsEnumerable().FirstOrDefault(c => c.Email == email);
        }

        public Client? GetClientById(Guid id)
        {

            return _context.Clients.AsEnumerable().FirstOrDefault(c => c.Id.Value == id);
        }

        public async Task<Client?> UpdateClient(Client clientUpdate)
        {
            var client = _context.Clients.FirstOrDefault(x => x.Id.Value == clientUpdate.Id.Value);
            if (client is not null)
            {
                client = clientUpdate;
                await _context.SaveChangesAsync();
            }
            else
                return null;

            await _context.SaveChangesAsync();

            return client;
        }
    }
}
