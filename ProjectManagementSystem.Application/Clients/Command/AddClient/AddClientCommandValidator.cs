using FluentValidation;

namespace ProjectManagementSystem.Application.Clients.Command.AddClient
{
    public class AddClientCommandValidator : AbstractValidator<AddClientCommand>
    {
        public AddClientCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.ClientContact).NotEmpty();
        }
    }
}
