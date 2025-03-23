namespace Banking.Domain
{
    public class Account(Guid accountNumber, Guid owner, decimal initialBalance = 0)
    {
        public readonly Guid AccountNumber = accountNumber;
        public readonly Guid CustomerId = owner;
        public decimal Balance { get; private set; } = initialBalance;

        public void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            Balance -= amount;
        }
    }
}
