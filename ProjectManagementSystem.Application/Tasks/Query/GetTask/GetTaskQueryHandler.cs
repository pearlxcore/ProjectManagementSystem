using ErrorOr;
using MediatR;
using ProjectManagementSystem.Application.Common.Interfaces.Persistance;
using ProjectManagementSystem.Domain.Common.Errors;
using Task = ProjectManagementSystem.Domain.Aggregates.Task.Task;
namespace ProjectManagementSystem.Application.Tasks.Query.GetTask
{
    public class GetTaskQueryHandler : IRequestHandler<GetTaskQuery, ErrorOr<Task>>
    {
        private readonly ITaskRepository _taskRepository;

        public GetTaskQueryHandler(ITaskRepository taskRepository)
        {
            _taskRepository=taskRepository;
        }

        public async Task<ErrorOr<Task>> Handle(GetTaskQuery request, CancellationToken cancellationToken)
        {
            if (_taskRepository.GetTaskById(request.Id) is not Task task)
            {
                return Errors.Task.NotFound;
            }

            return task;
        }
    }
}
