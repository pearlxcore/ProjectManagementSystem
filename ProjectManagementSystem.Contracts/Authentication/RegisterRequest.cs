namespace ProjectManagementSystem.Contracts.Authentication
{
    public record RegisterRequest(
       string FirstName,
       string LastName,
       string Email,
       string Password,
       string Role,
       RegisterContactRequest RegisterContact);

    public record RegisterContactRequest(
        string Phone,
        string Address);
}
