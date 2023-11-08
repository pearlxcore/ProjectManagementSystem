using ErrorOr;
using MediatR;
using ProjectManagementSystem.Application.Common.Interfaces.Persistance;
using ProjectManagementSystem.Domain.Aggregates.Users;
using ProjectManagementSystem.Domain.Common.Errors;

namespace ProjectManagementSystem.Application.Users.Query.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, ErrorOr<User>>
    {
        private readonly IUserRepository _userRepository;

        public GetUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository=userRepository;
        }

        public async Task<ErrorOr<User>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            // get user
            if (_userRepository.GetUserById(request.Id) is not User user)
            {
                return Errors.User.NotFound;
            }

            return user;
        }
    }
}
