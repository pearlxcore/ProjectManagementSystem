using ErrorOr;
using MediatR;
using ProjectManagementSystem.Application.Common.Interfaces.Persistance;
using ProjectManagementSystem.Domain.Aggregates.Projects;
using ProjectManagementSystem.Domain.Common.Errors;

namespace ProjectManagementSystem.Application.Projects.Query.GetProject
{
    public class GetProjectQueryHandler : IRequestHandler<GetProjectQuery, ErrorOr<Project>>
    {
        private readonly IProjectRepository _projectRepository;

        public GetProjectQueryHandler(IProjectRepository projectRepository)
        {
            _projectRepository=projectRepository;
        }

        public async Task<ErrorOr<Project>> Handle(GetProjectQuery request, CancellationToken cancellationToken)
        {
            if (_projectRepository.GetProjectById(request.Id) is not Project project)
            {
                return Errors.Project.NotFound;
            }

            return project;
        }
    }
}
