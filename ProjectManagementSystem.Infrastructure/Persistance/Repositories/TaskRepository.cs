using ProjectManagementSystem.Application.Common.Interfaces.Persistance;
using Task = ProjectManagementSystem.Domain.Aggregates.Task.Task;
namespace ProjectManagementSystem.Infrastructure.Persistance.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ProjectManagementSystemDbContext _context;

        public TaskRepository(ProjectManagementSystemDbContext context)
        {
            _context=context;
        }

        public async System.Threading.Tasks.Task AddTask(Task task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
        }

        public async Task<Task?> AssignTaskUserAsync(Guid taskId, Guid userId)
        {
            var task = _context.Tasks.FirstOrDefault(x => x.Id.Value == taskId);
            task.AssignedUserIds.Add(new(userId));
            await _context.SaveChangesAsync();
            return task;
        }

        public Task? GetTaskById(Guid taskId)
        {
            return _context.Tasks.AsEnumerable().FirstOrDefault(x => x.Id.Value == taskId);
        }

        public Task? GetTaskByName(string name)
        {
            return _context.Tasks.AsEnumerable().FirstOrDefault(x => x.Name == name);
        }

        public bool CheckUserIdExists(Guid userId)
        {
            // Use LINQ to check if the user exists in the list of projects
            var userdExists = _context.Tasks.Any(task => task.AssignedUserIds.Any(user => user.Value == userId));

            return userdExists;
        }

    }
}
