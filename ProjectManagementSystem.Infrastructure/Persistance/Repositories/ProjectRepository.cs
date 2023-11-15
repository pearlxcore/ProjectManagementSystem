using Microsoft.EntityFrameworkCore;
using ProjectManagementSystem.Application.Common.Interfaces.Persistance;
using ProjectManagementSystem.Domain.Aggregates.Projects;

namespace ProjectManagementSystem.Infrastructure.Persistance.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ProjectManagementSystemDbContext _context;

        public ProjectRepository(ProjectManagementSystemDbContext context)
        {
            _context=context;
        }

        public async Task CreateProject(Project project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
        }

        public async void DeleteProject(Guid guid)
        {
            var project = _context.Projects.FirstOrDefault(p => p.Id.Value == guid);
            if (project is not null)
            {
                _context.Projects.Remove(project);
                await _context.SaveChangesAsync();
            }
        }

        public Task<List<Project>> GetAll()
        {
            return _context.Projects.ToListAsync();
        }

        public Project? GetProjectById(Guid guid)
        {
            return _context.Projects.AsEnumerable().FirstOrDefault(p => p.Id.Value == guid);
        }

        public Project? CheckProjectExists(string name, Guid id)
        {
            var projectExists = _context.Projects.FirstOrDefault(p => p.Name == name && p.ClientId == id);

            return projectExists;
        }

        public async Task<Project?> UpdateProject(Project updateProject)
        {
            var project = _context.Projects.FirstOrDefault(p => p.Id.Value == updateProject.Id.Value);

            if (project is not null)
            {
                project = updateProject;
                await _context.SaveChangesAsync();
            }
            else
                return null;

            return project;
        }

        public async Task<Project?> AssignProjectTask(Domain.Aggregates.Task.Task task, Guid projectId)
        {
            var project = _context.Projects.FirstOrDefault(x => x.Id.Value == projectId);
            var taskId = task.Id.Value;
            project.TaskIds.Add(new(taskId));
            await _context.SaveChangesAsync();

            return project;
        }

        public bool CheckTaskIdExists(Guid taskId)
        {
            // Use LINQ to check if the user exists in the list of projects
            var taskIdExists = _context.Projects.Any(project => project.TaskIds.Any(user => user.Value == taskId));

            return taskIdExists;
        }
    }
}
