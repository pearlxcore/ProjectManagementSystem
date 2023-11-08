using FluentValidation;

namespace ProjectManagementSystem.Application.Tasks.Query.GetTask
{
    public class GetTaskQueryValidator : AbstractValidator<GetTaskQuery>
    {
        public GetTaskQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
