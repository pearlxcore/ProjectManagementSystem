using ErrorOr;
using MediatR;
using ProjectManagementSystem.Domain.Aggregates.Users;

namespace ProjectManagementSystem.Application.Users.Query.GetUser
{
    public class GetUserQuery : IRequest<ErrorOr<User>>
    {
        public Guid Id { get; set; }
    }
}
