using ErrorOr;

namespace ProjectManagementSystem.Domain.Common.Errors
{
    public partial class Errors
    {
        public class User
        {
            public static Error DuplicateEmail = Error.Conflict(
                code: "User.DuplicateEmail",
                description: "Email already in use.");

            public static Error NotFound = Error.NotFound(
                code: "User.NotFound",
                description: "User not found.");

            public static Error InvalidRole = Error.Validation(
                code: "User.InvalidRole",
                description: "Invalid role.");
        }
    }
}
