namespace ProjectManagementSystem.Contracts.Client
{
    public record ClientRequest(
        string Name,
        string Email,
        ClientContactRequest ClientContact);

    public record ClientContactRequest(
        string Phone,
        string Address);

}
