using ErrorOr;
using MediatR;
using Task = ProjectManagementSystem.Domain.Aggregates.Task.Task;

namespace ProjectManagementSystem.Application.Tasks.Command.AssignUser
{
    public class AssignTaskUserCommand : IRequest<ErrorOr<Task>>
    {
        public Guid TaskId { get; set; }
        public Guid UserId { get; set; }
    }
}
