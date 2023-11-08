using ErrorOr;
using MediatR;
using Task = ProjectManagementSystem.Domain.Aggregates.Task.Task;
namespace ProjectManagementSystem.Application.Tasks.Command.AddTask
{
    public record AddTaskCommand(
        string Name,
        string Description,
        DateTime StartDate,
        DateTime EndDate,
        string Status,
        string Priority,
        List<Guid> AssignedUsers,
        Guid ProjectId) : IRequest<ErrorOr<Task>>;

}
