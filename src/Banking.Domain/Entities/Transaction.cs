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
        string Description
    );
}
