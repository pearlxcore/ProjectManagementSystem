using ErrorOr;
using MediatR;
using ProjectManagementSystem.Domain.Aggregates.Clients;

namespace ProjectManagementSystem.Application.Clients.Command.AddClient
{
    public record AddClientCommand(
        Guid Id,
        string Name,
        string Email,
        AddClientContactCommand ClientContact) : IRequest<ErrorOr<Client>>;

    public record AddClientContactCommand(
        string Phone,
        string Address);
}
