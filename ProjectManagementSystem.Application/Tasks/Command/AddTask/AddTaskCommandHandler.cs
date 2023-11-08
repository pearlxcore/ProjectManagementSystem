using ErrorOr;
using MediatR;
using ProjectManagementSystem.Application.Common.Interfaces.Persistance;
using ProjectManagementSystem.Domain.Aggregates.Projects.ValueObjects;
using ProjectManagementSystem.Domain.Aggregates.Users.ValueObjects;
using ProjectManagementSystem.Domain.Common.Errors;
using Task = ProjectManagementSystem.Domain.Aggregates.Task.Task;

namespace ProjectManagementSystem.Application.Tasks.Command.AddTask
{
    public class AddTaskCommandHandler : IRequestHandler<AddTaskCommand, ErrorOr<Task>>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly ITaskRepository _taskRepository;
        private readonly IUserRepository _userRepository;

        public AddTaskCommandHandler(IProjectRepository projectRepository, ITaskRepository taskRepository, IUserRepository userRepository)
        {
            _projectRepository=projectRepository;
            _taskRepository=taskRepository;
            _userRepository=userRepository;
        }

        public async Task<ErrorOr<Task>> Handle(AddTaskCommand request, CancellationToken cancellationToken)
        {
            if (_taskRepository.GetTaskByName(request.Name) is not null) // check if task name with given project id already 
            {
                return Errors.Task.DuplicateName;
            }

            // check userId exists
            var userIdList = new List<UserId>();
            foreach (var userId in request.AssignedUsers)
            {
                if (_userRepository.GetUserById(userId) is not null)
                {
                    userIdList.Add(new UserId(userId));
                }
                else
                {
                    return Errors.User.NotFound;
                }
            }

            List<UserId> userIds = userIdList.Select(guid => new UserId(guid.Value)).ToList();


            var projectId = new ProjectId(request.ProjectId);

            var task = Domain.Aggregates.Task.Task.Factory.Create(
                request.Name,
                request.Description,
                request.StartDate,
                request.EndDate,
                request.Status,
                request.Priority,
                userIds);

            // presistance
            _taskRepository.AddTask(task);

            return task;
        }
    }
}
