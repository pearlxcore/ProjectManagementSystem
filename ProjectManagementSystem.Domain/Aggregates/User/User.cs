using ProjectManagementSystem.Domain.Aggregates.Common.Model;
using ProjectManagementSystem.Domain.Aggregates.User.Common;
using ProjectManagementSystem.Domain.Aggregates.Users.ValueObjects;

namespace ProjectManagementSystem.Domain.Aggregates.Users
{
    public sealed class User : AggregateRoot<UserId, Guid>
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public UserRole Role { get; private set; } // enum role
        public UserContact UserContact { get; private set; }

        private User(
            UserId userId,
            string firstName,
            string lastName,
            string email,
            string password,
            UserRole role,
            UserContact userContact) : base(userId)
        {
            UserContact = userContact;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Role = role;
        }

        public class Factory
        {
            public static User Create(
                string firstName,
                string lastName,
                string email,
                string password,
                UserRole role,
                UserContact userContact)
            {
                return new(
                    UserId.CreateUnique(),
                    firstName,
                    lastName,
                    email,
                    password,
                    role,
                    userContact);
            }

        }

        public void UpdateUser(
             string firstName,
                string lastName,
                string email,
                string password,
                UserRole role)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Role = role;
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private User()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {

        }
    }
}
