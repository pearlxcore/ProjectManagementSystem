using ProjectManagementSystem.Domain.Aggregates.Projects;
using Task = ProjectManagementSystem.Domain.Aggregates.Task.Task;

namespace ProjectManagementSystem.Application.Common.Interfaces.Persistance
{
    public interface IProjectRepository
    {
        System.Threading.Tasks.Task CreateProject(Project project);
        Task<Project?> UpdateProject(Project project);
        void DeleteProject(Guid guid);
        Task<List<Project>> GetAll();
        Project? GetProjectById(Guid guid);
        Project? CheckProjectExists(string name, Guid id);
        Task<Project?> AssignProjectTask(Task task, Guid projectId);
        bool CheckTaskIdExists(Guid taskId);
    }
}
