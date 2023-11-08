using ProjectManagementSystem.Domain.Aggregates.Common.Model;

namespace ProjectManagementSystem.Domain.Aggregates.Users.ValueObjects
{
    public sealed class UserContact : ValueObject
    {
        public string Phone { get; private set; }
        public string Address { get; private set; }

        private UserContact(string phone, string address)
        {
            Phone = phone;
            Address = address;
        }

        public static UserContact Create(string phone = null, string address = null)
        {
            return new(phone, address);
        }

        public void Update(string phone = null, string address = null)
        {
            Phone = phone;
            Address = address;
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Phone;
            yield return Address;
        }

        private UserContact() { }
    }
}
