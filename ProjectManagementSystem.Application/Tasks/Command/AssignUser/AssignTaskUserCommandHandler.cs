using ErrorOr;
using MediatR;
using ProjectManagementSystem.Application.Common.Interfaces.Persistance;
using ProjectManagementSystem.Domain.Aggregates.Users;
using ProjectManagementSystem.Domain.Common.Errors;
using Task = ProjectManagementSystem.Domain.Aggregates.Task.Task;

namespace ProjectManagementSystem.Application.Tasks.Command.AssignUser
{
    public class AssignTaskUserCommandHandler : IRequestHandler<AssignTaskUserCommand, ErrorOr<Task>>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IUserRepository _userRepository;

        public AssignTaskUserCommandHandler(ITaskRepository taskRepository, IUserRepository userRepository)
        {
            _taskRepository=taskRepository;
            _userRepository=userRepository;
        }

        public async Task<ErrorOr<Task>> Handle(AssignTaskUserCommand request, CancellationToken cancellationToken)
        {
            // check task exists
            if (_taskRepository.GetTaskById(request.TaskId) is not Task task)
            {
                return Errors.Task.NotFound;
            }

            // check user exists
            if (_userRepository.GetUserById(request.UserId) is not User user)
            {
                return Errors.User.NotFound;
            }

            // check if user already assign
            if (_taskRepository.CheckUserIdExists(request.UserId))
            {
                return Errors.Task.DuplicateUserId;
            }

            task = _taskRepository.AssignTaskUser(task.Id.Value, user.Id.Value);

            return task;
        }
    }
}
