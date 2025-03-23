namespace Banking.Domain
{
    public class Customer(Guid id, string firstName, string lastName)
    {
        public readonly Guid Id = id;

        public string FirstName { get; private set; } = firstName;
        public string LastName { get; private set; } = lastName;
    }
}
