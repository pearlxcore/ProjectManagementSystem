using ErrorOr;
using MediatR;
using ProjectManagementSystem.Application.Common.Interfaces.Persistance;
using ProjectManagementSystem.Domain.Aggregates.Projects;
using ProjectManagementSystem.Domain.Common.Errors;
using Task = ProjectManagementSystem.Domain.Aggregates.Task.Task;

namespace ProjectManagementSystem.Application.Projects.Command.AssignTask
{
    public class AssignProjectTaskCommandHandler : IRequestHandler<AssignProjectTaskCommand, ErrorOr<Project>>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly ITaskRepository _taskRepository;

        public AssignProjectTaskCommandHandler(IProjectRepository projectRepository, ITaskRepository taskRepository)
        {
            _projectRepository=projectRepository;
            _taskRepository=taskRepository;
        }

        public async Task<ErrorOr<Project>> Handle(AssignProjectTaskCommand request, CancellationToken cancellationToken)
        {
            // check if project is exists
            if (_projectRepository.GetProjectById(request.ProjectId) is not Project project)
            {
                return Errors.Project.NotFound;
            }

            // check if user already exist
            if (_projectRepository.CheckTaskIdExists(request.TaskId))
            {
                return Errors.Project.DuplicateId;
            }

            // check if task is exists
            if (_taskRepository.GetTaskById(request.TaskId) is not Task task)
            {
                return Errors.Task.NotFound;
            }

            project =  _projectRepository.AssignProjectTask(task, request.ProjectId);

            return project;
        }
    }
}
