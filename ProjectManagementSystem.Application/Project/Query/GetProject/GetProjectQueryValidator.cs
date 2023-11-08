using FluentValidation;

namespace ProjectManagementSystem.Application.Projects.Query.GetProject
{
    public class GetProjectQueryValidator : AbstractValidator<GetProjectQuery>
    {
        public GetProjectQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
