using ProjectManagementSystem.Application.Common.Interfaces.Persistance;
using ProjectManagementSystem.Domain.Aggregates.Clients;

namespace ProjectManagementSystem.Infrastructure.Persistance.Repositories
{
    public class ClientRespository : IClientRepository
    {
        private static readonly List<Client> _clients = new();
        private readonly ProjectManagementSystemDbContext _context;

        public ClientRespository(ProjectManagementSystemDbContext context)
        {
            _context=context;
        }

        public async void AddClient(Client client)
        {
            _clients.Add(client);
            await _context.SaveChangesAsync();
        }

        public Client? GetClientByEmail(string email)
        {
            var client = _clients.FirstOrDefault(c => c.Email == email);
            if (client is null)
            {
                return null;
            }

            return client;
        }

        public Client? GetClientById(Guid id)
        {

            var client = _clients.FirstOrDefault(c => c.Id.Value == id);
            if (client is null)
            {
                return null;
            }

            return client;
        }

        public async Task<Client?> UpdateClient(Client clientUpdate)
        {
            var client = _clients.FirstOrDefault(x => x.Id.Value == clientUpdate.Id.Value);
            if (client is not null)
            {
                client = clientUpdate;
            }
            else
                return null;

            await _context.SaveChangesAsync();

            return client;
        }
    }
}
