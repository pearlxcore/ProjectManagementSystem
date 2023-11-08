using ProjectManagementSystem.Application.Common.Interfaces.Persistance;
using Task = ProjectManagementSystem.Domain.Aggregates.Task.Task;
namespace ProjectManagementSystem.Infrastructure.Persistance.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private static readonly List<Task> _tasks = new();
        public void AddTask(Task task)
        {
            _tasks.Add(task);
        }

        public Task? AssignTaskUser(Guid taskId, Guid userId)
        {
            var task = _tasks.FirstOrDefault(x => x.Id.Value == taskId);
            task.AssignedUserIds.Add(new(userId));
            return task;
        }

        public Task? GetTaskById(Guid taskId)
        {
            var task = _tasks.FirstOrDefault(x => x.Id.Value == taskId);
            return task;
        }

        public Task? GetTaskByName(string name)
        {
            var task = _tasks.FirstOrDefault(x => x.Name == name);
            return task;
        }

        public bool CheckUserIdExists(Guid userId)
        {
            // Use LINQ to check if the user exists in the list of projects
            var userdExists = _tasks.Any(task => task.AssignedUserIds.Any(user => user.Value == userId));

            return userdExists;
        }

    }
}
