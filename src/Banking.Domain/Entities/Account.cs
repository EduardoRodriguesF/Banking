namespace Banking.Domain
{
    public class Account(Guid accountNumber, Guid owner, decimal initialBalance = 0)
    {
        public readonly Guid AccountNumber = accountNumber;
        public readonly Guid CustomerId = owner;
        public Money Balance { get; private set; } = Money.Create(initialBalance, "BRL");

        public void Deposit(Money funds)
        {
            Balance = Balance.Add(funds);
        }

        public void Withdraw(Money funds)
        {
            Balance = Balance.Subtract(funds);
        }
    }
}
