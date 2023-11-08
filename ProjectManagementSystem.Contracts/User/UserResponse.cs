namespace ProjectManagementSystem.Contracts.User
{
    public class UserResponse
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public UserContactResponse UserContact { get; }

        public UserResponse(Guid id, string firstName, string lastName, string email, string role, UserContactResponse userContact)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Role = role;
            UserContact = userContact;
        }
    }

    public class UserContactResponse
    {
        public string Phone { get; set; }
        public string Address { get; set; }

        public UserContactResponse(string phone, string address)
        {
            Phone = phone;
            Address = address;
        }
    }

}
