using ErrorOr;
using MediatR;
using ProjectManagementSystem.Application.Common.Interfaces.Persistance;
using ProjectManagementSystem.Domain.Aggregates.Clients;
using ProjectManagementSystem.Domain.Common.Errors;

namespace ProjectManagementSystem.Application.Clients.Query.GetClient
{
    public class GetClientQueryHandler : IRequestHandler<GetClientQuery, ErrorOr<Client>>
    {
        private readonly IClientRepository _clientRepository;

        public GetClientQueryHandler(IClientRepository clientRepository)
        {
            _clientRepository=clientRepository;
        }

        public async Task<ErrorOr<Client>> Handle(GetClientQuery request, CancellationToken cancellationToken)
        {
            if (_clientRepository.GetClientById(request.Id) is not Client client)
            {
                return Errors.Client.NotFound;
            }

            return client;
        }
    }
}
