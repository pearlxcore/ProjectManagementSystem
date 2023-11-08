using ErrorOr;
using MediatR;
using Task = ProjectManagementSystem.Domain.Aggregates.Task.Task;
namespace ProjectManagementSystem.Application.Tasks.Query.GetTask
{
    public class GetTaskQuery : IRequest<ErrorOr<Task>>
    {
        public Guid Id { get; set; }
    }
}
