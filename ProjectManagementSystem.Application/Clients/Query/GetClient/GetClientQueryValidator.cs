using FluentValidation;

namespace ProjectManagementSystem.Application.Clients.Query.GetClient
{
    public class GetClientQueryValidator : AbstractValidator<GetClientQuery>
    {
        public GetClientQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
