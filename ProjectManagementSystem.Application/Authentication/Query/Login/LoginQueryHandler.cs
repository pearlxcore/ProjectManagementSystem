using ErrorOr;
using MediatR;
using ProjectManagementSystem.Application.Authentication.Common;
using ProjectManagementSystem.Application.Common.Interfaces.Authentication;
using ProjectManagementSystem.Application.Common.Interfaces.Persistance;
using ProjectManagementSystem.Domain.Aggregates.Users;
using ProjectManagementSystem.Domain.Common.Errors;

namespace ProjectManagementSystem.Application.Authentication.Query.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public LoginQueryHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
        {
            _userRepository=userRepository;
            _jwtTokenGenerator=jwtTokenGenerator;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            // check user exist
            if (_userRepository.GetUserByEmail(request.Email) is not User user)
            {
                return Errors.Authentication.InvalidCredential;
            }

            if (user.Password != request.Password)
            {
                return Errors.Authentication.InvalidCredential;
            }

            // generate token
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                token);
        }
    }
}
