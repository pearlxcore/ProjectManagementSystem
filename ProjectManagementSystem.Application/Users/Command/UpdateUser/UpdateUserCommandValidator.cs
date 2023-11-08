using FluentValidation;

namespace ProjectManagementSystem.Application.Users.Command.UpdateUser
{
    public class UpdateClientCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateClientCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.Role).NotEmpty();
            RuleFor(x => x.UserContact).NotEmpty();
        }
    }
}
