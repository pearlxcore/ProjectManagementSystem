using ErrorOr;
using MediatR;
using ProjectManagementSystem.Application.Common.Interfaces.Persistance;
using ProjectManagementSystem.Domain.Aggregates.Clients;
using ProjectManagementSystem.Domain.Common.Errors;

namespace ProjectManagementSystem.Application.Clients.Command.UpdateClient
{
    public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, ErrorOr<Client>>
    {
        private readonly IClientRepository _clientRepository;

        public UpdateClientCommandHandler(IClientRepository clientRepository)
        {
            _clientRepository=clientRepository;
        }

        public async Task<ErrorOr<Client>> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            if (_clientRepository.GetClientById(request.Id) is not Client client)
            {
                return Errors.Client.NotFound;
            }

            // update client
            client.ClientContact.Update(
                               request.ClientContact.Phone,
                               request.ClientContact.Address);

            client.UpdateClient(
                request.Name,
                request.Email);

            return client;
        }
    }
}
