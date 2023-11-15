using Task = ProjectManagementSystem.Domain.Aggregates.Task.Task;

namespace ProjectManagementSystem.Application.Common.Interfaces.Persistance
{
    public interface ITaskRepository
    {
        System.Threading.Tasks.Task AddTask(Task task);
        Task? GetTaskById(Guid taskId);
        Task? GetTaskByName(string name);
        Task<Task?> AssignTaskUserAsync(Guid taskId, Guid userId);
        bool CheckUserIdExists(Guid userId);
    }
}
