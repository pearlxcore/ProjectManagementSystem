using ErrorOr;

namespace ProjectManagementSystem.Domain.Common.Errors
{
    public partial class Errors
    {
        public class Authentication
        {
            public static Error InvalidCredential = Error.Validation(
                code: "Auth.InvalidCredential",
                description: "Invalid credential");
        }
    }
}
