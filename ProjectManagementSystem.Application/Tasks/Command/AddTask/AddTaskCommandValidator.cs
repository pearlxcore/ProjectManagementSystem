using FluentValidation;

namespace ProjectManagementSystem.Application.Tasks.Command.AddTask
{
    public class AddTaskCommandValidator : AbstractValidator<AddTaskCommand>
    {
        public AddTaskCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.StartDate).NotEmpty();
            RuleFor(x => x.EndDate).NotEmpty();
            RuleFor(x => x.Status).NotEmpty();
            RuleFor(x => x.Priority).NotEmpty();
        }
    }
}
