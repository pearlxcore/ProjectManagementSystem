using ProjectManagementSystem.Domain.Aggregates.Common.Model;

namespace ProjectManagementSystem.Domain.Aggregates.Projects.ValueObjects
{
    public sealed class ClientContact : ValueObject
    {
        public string Phone { get; private set; }
        public string Address { get; private set; }

        private ClientContact(string phone, string address)
        {
            Phone=phone;
            Address=address;
        }

        public void Update(string phone = null, string address = null)
        {
            Phone=phone;
            Address=address;
        }

        public static ClientContact Create(string phone = null, string address = null)
        {
            return new(phone, address);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Phone;
            yield return Address;
        }

        private ClientContact() { }
    }
}
