using ErrorOr;
using MediatR;
using ProjectManagementSystem.Domain.Aggregates.Projects;

namespace ProjectManagementSystem.Application.Projects.Command.CreateProject
{
    public record CreateProjectCommand(
        string Name,
        string Description,
        DateTime StartDate,
        DateTime EndDate,
        string Status,
        String Priority,
        Decimal Budget,
        List<Guid> TeamMembers,
        Guid ClientId) : IRequest<ErrorOr<Project>>;
}
