namespace ProjectManagementSystem.Contracts.Client
{
    public class ClientResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public ClientContactResponse ClientContact { get; }
        public List<Guid> ProjectIds { get; set; }

        public ClientResponse(Guid id, string name, string email, ClientContactResponse clientContact, List<Guid> projectIds)
        {
            Id = id;
            Name = name;
            Email = email;
            ClientContact = clientContact;
            ProjectIds = projectIds;
        }
    }

    public class ClientContactResponse
    {
        public string Phone { get; set; }
        public string Address { get; set; }

        public ClientContactResponse(string phone, string address)
        {
            Phone = phone;
            Address = address;
        }
    }

}
