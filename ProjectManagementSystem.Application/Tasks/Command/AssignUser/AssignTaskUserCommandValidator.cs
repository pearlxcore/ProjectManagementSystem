using FluentValidation;

namespace ProjectManagementSystem.Application.Tasks.Command.AssignUser
{
    public class AssignTaskUserCommandValidator : AbstractValidator<AssignTaskUserCommand>
    {
        public AssignTaskUserCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.TaskId).NotEmpty();
        }
    }
}
