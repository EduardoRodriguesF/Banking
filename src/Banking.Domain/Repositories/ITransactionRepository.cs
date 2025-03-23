namespace Banking.Domain
{
    public interface ITransactionRepository
    {
        public Task<Transaction> GetById(Guid id);
        public Task<IEnumerable<Transaction>> GetByAccountId(Guid accountId);
        public Task Create(Transaction transaction);
    }
}
