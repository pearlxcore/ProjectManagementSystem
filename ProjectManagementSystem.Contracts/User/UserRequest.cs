namespace ProjectManagementSystem.Contracts.User
{
    public record UserRequest(
        string FirstName,
        string LastName,
        string Email,
        string Password,
        string Role,
        UserContactRequest UserContact);

    public record UserContactRequest(
        string Phone,
        string Address);

}
