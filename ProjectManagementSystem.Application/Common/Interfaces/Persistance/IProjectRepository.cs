using ProjectManagementSystem.Domain.Aggregates.Projects;
using Task = ProjectManagementSystem.Domain.Aggregates.Task.Task;

namespace ProjectManagementSystem.Application.Common.Interfaces.Persistance
{
    public interface IProjectRepository
    {
        void CreateProject(Project project);
        Project? UpdateProject(Project project);
        void DeleteProject(Guid guid);
        List<Project> GetAll();
        Project? GetProjectById(Guid guid);
        Project? CheckProjectExists(string name, Guid id);
        Project? AssignProjectTask(Task task, Guid projectId);
        bool CheckTaskIdExists(Guid taskId);
    }
}
