using FluentValidation;

namespace ProjectManagementSystem.Application.Projects.Command.AssignTask
{
    public class AssignProjectTaskCommandValidator : AbstractValidator<AssignProjectTaskCommand>
    {
        public AssignProjectTaskCommandValidator()
        {
            RuleFor(x => x.ProjectId).NotEmpty();
            RuleFor(x => x.TaskId).NotEmpty();
        }
    }
}
