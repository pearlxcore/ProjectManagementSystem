using FluentValidation;

namespace ProjectManagementSystem.Application.Projects.Command.CreateProject
{
    public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();

            RuleFor(x => x.StartDate).NotEmpty();

            RuleFor(x => x.EndDate).NotEmpty();

            RuleFor(x => x.Status).NotEmpty();

            RuleFor(x => x.Priority).NotEmpty();

            RuleFor(x => x.Budget).NotEmpty();

            RuleFor(x => x.TeamMembers).NotEmpty();

            RuleFor(x => x.ClientId).NotEmpty();

        }
    }
}
