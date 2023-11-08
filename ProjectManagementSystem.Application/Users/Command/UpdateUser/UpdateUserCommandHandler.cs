using ErrorOr;
using MediatR;
using ProjectManagementSystem.Application.Common.Interfaces.Persistance;
using ProjectManagementSystem.Domain.Aggregates.User.Common;
using ProjectManagementSystem.Domain.Aggregates.Users;
using ProjectManagementSystem.Domain.Common.Errors;

namespace ProjectManagementSystem.Application.Users.Command.UpdateUser
{
    public class UpdateClientCommandHandler : IRequestHandler<UpdateUserCommand, ErrorOr<User>>
    {
        private readonly IUserRepository _userRepository;

        public UpdateClientCommandHandler(IUserRepository userRepository)
        {
            _userRepository=userRepository;
        }

        public async Task<ErrorOr<User>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            if (_userRepository.GetUserById(request.Id) is not User user)
            {
                return Errors.User.NotFound;
            }

            UserRole userRole;

            if (Enum.TryParse(request.Role, true, out userRole))
            {
                user.UserContact.Update(
                                request.UserContact.Phone,
                                request.UserContact.Address);

                user.UpdateUser(
                    request.FirstName,
                    request.LastName,
                    request.Email,
                    request.Password,
                    userRole);
            }
            else
            {
                return Errors.User.InvalidRole;
            }

            return user;
        }
    }
}
