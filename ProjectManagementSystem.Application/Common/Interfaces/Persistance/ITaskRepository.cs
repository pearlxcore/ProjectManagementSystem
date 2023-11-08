using Task = ProjectManagementSystem.Domain.Aggregates.Task.Task;

namespace ProjectManagementSystem.Application.Common.Interfaces.Persistance
{
    public interface ITaskRepository
    {
        void AddTask(Task task);
        Task? GetTaskById(Guid taskId);
        Task? GetTaskByName(string name);
        Task? AssignTaskUser(Guid taskId, Guid userId);
        bool CheckUserIdExists(Guid userId);
    }
}
