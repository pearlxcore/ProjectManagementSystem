using ErrorOr;
using MediatR;
using ProjectManagementSystem.Application.Authentication.Common;
using ProjectManagementSystem.Application.Common.Interfaces.Authentication;
using ProjectManagementSystem.Application.Common.Interfaces.Persistance;
using ProjectManagementSystem.Domain.Aggregates.User.Common;
using ProjectManagementSystem.Domain.Aggregates.Users;
using ProjectManagementSystem.Domain.Aggregates.Users.ValueObjects;
using ProjectManagementSystem.Domain.Common.Errors;

namespace ProjectManagementSystem.Application.Authentication.Command.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public RegisterCommandHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
        {
            _userRepository=userRepository;
            _jwtTokenGenerator=jwtTokenGenerator;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            // check if email already user
            if (_userRepository.GetUserByEmail(request.Email) is User user)
            {
                return Errors.User.DuplicateEmail;
            }

            // Determine the user role based on the input
            UserRole userRole;
            var token = "";
            if (Enum.TryParse(request.Role, true, out userRole))
            {
                // create user
                user = User.Factory.Create(
                    firstName: request.FirstName,
                    lastName: request.LastName,
                    email: request.Email,
                    password: request.Password,
                    role: userRole,
                    userContact: UserContact.Create(
                        phone: request.UserContact.Phone,
                        address: request.UserContact.Address));

                // persistance
                _userRepository.AddUser(user);

                // generate token
                token = _jwtTokenGenerator.GenerateToken(user);
            }
            else
            {
                return Errors.User.InvalidRole;
            }



            return new AuthenticationResult(
                user,
                token);
        }
    }
}
