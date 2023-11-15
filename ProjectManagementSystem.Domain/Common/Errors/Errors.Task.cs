using ErrorOr;

namespace ProjectManagementSystem.Domain.Common.Errors
{
    public partial class Errors
    {
        public static class Task
        {
            public static Error NotFound = Error.NotFound(
                code: "Task.NotFound",
                description: "Task not found.");

            public static Error DuplicateName = Error.Conflict(
               code: "Task.DuplicateName",
               description: "Task name already exists.");

            public static Error DuplicateUserId = Error.Conflict(
                code: "Task.DuplicateUserId",
                description: "User Id already assigned.");

            public static Error UserAssignmentFailed = Error.Failure(
                code: "Task.UserAssignmentFailed",
                description: "Failed to assign user to Task.");
        }
    }
}
