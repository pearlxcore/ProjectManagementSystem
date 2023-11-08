using Mapster;
using ProjectManagementSystem.Application.Projects.Command.CreateProject;
using ProjectManagementSystem.Contracts.Project;
using ProjectManagementSystem.Contracts.Projects;
using ProjectManagementSystem.Domain.Aggregates.Projects;

namespace ProjectManagementSystem.Api.Common.Mapping
{
    public class ProjectMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreateProjectRequest, CreateProjectCommand>()
                .Map(dest => dest, src => src);

            config.NewConfig<Project, ProjectResponse>()
                .MapWith(dest => new ProjectResponse(
                    dest.Id.Value,
                    dest.Name,
                    dest.Description,
                    dest.StartDate,
                    dest.EndDate,
                    dest.Status,
                    dest.Priority,
                    dest.Budget,
                    dest.ClientId,
                    dest.TaskIds.Select(x => x.Value).ToList()));
        }
    }
}
