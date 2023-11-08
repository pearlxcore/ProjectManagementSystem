using ErrorOr;

namespace ProjectManagementSystem.Domain.Common.Errors
{
    public partial class Errors
    {
        public static class DateTime
        {
            public static Error InvalidDateTime = Error.Custom(
                    10,
                    code: "DateTime.InvalidDateTime",
                    description: "Invalid DateTime.");
        }
    }
}
