using ErrorOr;
using MediatR;
using ProjectManagementSystem.Domain.Aggregates.Clients;

namespace ProjectManagementSystem.Application.Clients.Query.GetClient
{
    public class GetClientQuery : IRequest<ErrorOr<Client>>
    {
        public Guid Id { get; set; }
    }
}
