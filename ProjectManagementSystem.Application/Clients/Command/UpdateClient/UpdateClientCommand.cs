using ErrorOr;
using MediatR;
using ProjectManagementSystem.Domain.Aggregates.Clients;

namespace ProjectManagementSystem.Application.Clients.Command.UpdateClient
{
    public record UpdateClientCommand(
        Guid Id,
        string Name,
        string Email,
        UpdateClientContactCommand ClientContact) : IRequest<ErrorOr<Client>>;

    public record UpdateClientContactCommand(
        string Phone,
        string Address);
}
