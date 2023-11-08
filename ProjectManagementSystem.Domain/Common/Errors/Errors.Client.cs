using ErrorOr;

namespace ProjectManagementSystem.Domain.Common.Errors
{
    public partial class Errors
    {
        public static class Client
        {
            public static Error NotFound = Error.NotFound(
                code: "Client.NotFound",
                description: "Client not found.");

            public static Error DuplicateEmail = Error.Conflict(
               code: "Client.DuplicateEmail",
               description: "Email already in use.");
        }
    }
}
