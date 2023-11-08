using ProjectManagementSystem.Domain.Aggregates.Clients.ValueObjects;
using ProjectManagementSystem.Domain.Aggregates.Common.Model;
using ProjectManagementSystem.Domain.Aggregates.Projects.ValueObjects;

namespace ProjectManagementSystem.Domain.Aggregates.Clients
{
    public sealed class Client : AggregateRoot<ClientId, Guid>
    {
        private readonly List<ProjectId> _projectIds;
        public string Name { get; private set; }
        public string Email { get; private set; }
        public ClientContact ClientContact { get; private set; }
        public IReadOnlyList<ProjectId> ProjectIds => _projectIds;

        private Client(
            ClientId clientId,
            string name,
            string email,
            ClientContact clientContact) : base(clientId)
        {
            _projectIds = new();
            Name = name;
            Email = email;
            ClientContact = clientContact;
        }

        public void UpdateClient(
            string name,
            string email)
        {
            Name = name;
            Email = email;
        }

        public class Factory
        {
            public static Client Create(
                string name,
                string email,
                ClientContact clientContact)
            {
                return new(
                    ClientId.CreateUnique(),
                    name,
                    email,
                    clientContact);
            }
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private Client()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {

        }
    }
}
