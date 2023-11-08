using ErrorOr;
using MediatR;
using ProjectManagementSystem.Application.Common.Interfaces.Persistance;
using ProjectManagementSystem.Domain.Aggregates.Clients;
using ProjectManagementSystem.Domain.Aggregates.Projects.ValueObjects;
using ProjectManagementSystem.Domain.Common.Errors;

namespace ProjectManagementSystem.Application.Clients.Command.AddClient
{
    public class AddClientCommandHandler : IRequestHandler<AddClientCommand, ErrorOr<Client>>
    {
        private readonly IClientRepository _clientRepository;

        public AddClientCommandHandler(IClientRepository clientRepository)
        {
            _clientRepository=clientRepository;
        }

        public async Task<ErrorOr<Client>> Handle(AddClientCommand request, CancellationToken cancellationToken)
        {
            // check if email already in use
            if (_clientRepository.GetClientByEmail(request.Email) is not null)
            {
                return Errors.Client.DuplicateEmail;
            }

            var clientContact = ClientContact.Create(
                request.ClientContact.Phone,
                request.ClientContact.Address);

            var client = Client.Factory.Create(
                name: request.Name,
                email: request.Email,
                clientContact: clientContact);

            _clientRepository.AddClient(client);

            return client;
        }
    }
}
