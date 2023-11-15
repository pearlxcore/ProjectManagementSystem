using ErrorOr;

namespace ProjectManagementSystem.Domain.Common.Errors
{
    public partial class Errors
    {
        public class Project
        {
            public static Error NotFound = Error.NotFound(
                "Project.ProjectNotFound",
                "Project not found.");

            public static Error DuplicateName = Error.Conflict(
                "Project.DuplicateName",
                "Project Name already exists.");

            public static Error DuplicateId = Error.Conflict(
                "Project.DuplicateId",
                "Task id already exists.");

            public static Error TaskAssignmentFailed = Error.Failure(
                code: "Project.TaskAssignmentFailed",
                description: "Failed to assign task to project.");
        }
    }
}
