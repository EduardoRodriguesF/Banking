namespace Banking.Domain
{
    public enum TransactionType
    {
        Deposit,
        Withdrawal,
        Fee,
        TransferIn,
        TransferOut,
    }
    public record Transaction(
        Guid Id,
        Guid AccountId,
        Money Amount,
        TransactionType Type,
        DateTime Date,
        string? Description
    )
    {
        public Transaction(Guid accountId, Money amount, TransactionType type, string? description = null)
            : this(Guid.Empty, accountId, amount, type, DateTime.UtcNow, description)
        {
        }
    };
}
