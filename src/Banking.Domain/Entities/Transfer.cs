namespace Banking.Domain
{
    public enum TransferStatus
    {
        Pending,
        Completed,
        Failed,
    }

    public record Transfer(
        Guid Id,
        Guid SourceAccountId,
        Guid DestinationAccountId,
        Money Amount,
        TransferStatus Status,
        DateTime Date
    );
}
