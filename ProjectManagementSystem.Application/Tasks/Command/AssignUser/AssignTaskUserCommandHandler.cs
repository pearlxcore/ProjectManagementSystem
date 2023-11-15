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
            var task = _taskRepository.GetTaskById(request.TaskId);
            if (task is null)
            {
                return Errors.Task.NotFound;
            }

            // check user exists
            var user = _userRepository.GetUserById(request.UserId);
            if (user is null)
            {
                return Errors.User.NotFound;
            }

            // check if user already assign
            var userSigned = _taskRepository.CheckUserIdExists(request.UserId);
            if (userSigned)
            {
                return Errors.Task.DuplicateUserId;
            }


            var assignedTask = await _taskRepository.AssignTaskUserAsync(task.Id.Value, user.Id.Value);

            if (assignedTask is null)
            {
                return Errors.Task.UserAssignmentFailed;
            }

            return assignedTask;
        }
    }
}
