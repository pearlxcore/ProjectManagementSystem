using ErrorOr;
using MediatR;
using ProjectManagementSystem.Domain.Aggregates.Projects;

namespace ProjectManagementSystem.Application.Projects.Query.GetProject
{
    public class GetProjectQuery : IRequest<ErrorOr<Project>>
    {
        public Guid Id { get; set; }
    }
}
