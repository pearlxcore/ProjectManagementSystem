using Mapster;
using ProjectManagementSystem.Application.Tasks.Command.AddTask;
using ProjectManagementSystem.Contracts.Task;
using Task = ProjectManagementSystem.Domain.Aggregates.Task.Task;

namespace ProjectManagementSystem.Api.Common.Mapping
{
    public class TaskMappingConfiguration : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<TaskRequest, AddTaskCommand>()
                .Map(dest => dest, src => src);

            config.NewConfig<Task, TaskResponse>()
                .MapWith(dest => new TaskResponse(
                    dest.Id.Value,
                    dest.Name,
                    dest.Description,
                    dest.StartDate,
                    dest.EndDate,
                    dest.Status,
                    dest.Priority,
                    dest.AssignedUserIds.Select(x => x.Value).ToList()));
        }
    }
}
