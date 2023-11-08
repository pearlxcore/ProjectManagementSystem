using ProjectManagementSystem.Application.Common.Interfaces.Persistance;
using ProjectManagementSystem.Domain.Aggregates.Projects;

namespace ProjectManagementSystem.Infrastructure.Persistance.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ITaskRepository _taskRepository;

        public ProjectRepository(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        private static readonly List<Project> _projects = new List<Project>();

        public void CreateProject(Project project)
        {
            _projects.Add(project);
            return;
        }

        public void DeleteProject(Guid guid)
        {
            var project = _projects.FirstOrDefault(p => p.Id.Value == guid);
            if (project is not null)
            {
                _projects.Remove(project);
            }
        }

        public List<Project> GetAll()
        {
            return _projects.ToList();
        }

        public Project? GetProjectById(Guid guid)
        {
            var project = _projects.FirstOrDefault(p => p.Id.Value == guid);
            if (project is not null)
            {
                return project;
            }
            return null;
        }

        public Project? CheckProjectExists(string name, Guid id)
        {
            var projectExists = _projects.FirstOrDefault(p => p.Name == name && p.ClientId == id);

            return projectExists;
        }

        public Project? UpdateProject(Project updateProject)
        {
            var project = _projects.FirstOrDefault(p => p.Id.Value == updateProject.Id.Value);

            if (project is not null)
            {
                project = updateProject;
            }
            else
                return null;

            return project;
        }

        public Project? AssignProjectTask(Domain.Aggregates.Task.Task task, Guid projectId)
        {
            var project = _projects.FirstOrDefault(x => x.Id.Value == projectId);
            var taskId = task.Id.Value;
            project.TaskIds.Add(new(taskId));
            return project;
        }

        public bool CheckTaskIdExists(Guid taskId)
        {
            // Use LINQ to check if the user exists in the list of projects
            var taskIdExists = _projects.Any(project => project.TaskIds.Any(user => user.Value == taskId));

            return taskIdExists;
        }
    }
}
