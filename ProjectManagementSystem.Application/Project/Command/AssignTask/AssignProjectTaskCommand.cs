using ErrorOr;
using MediatR;

namespace ProjectManagementSystem.Application.Projects.Command.AssignTask
{
    public class AssignProjectTaskCommand : IRequest<ErrorOr<Domain.Aggregates.Projects.Project>>
    {
        public Guid ProjectId { get; set; }
        public Guid TaskId { get; set; }
    }
}
