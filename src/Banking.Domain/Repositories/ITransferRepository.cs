namespace Banking.Domain
{
    public interface ITransferRepository
    {
        public Task<Transfer> GetById(Guid id);
        public Task Create(Transfer transfer);
        public Task MarkAsComplete(Guid id);
        public Task Cancel(Guid id);
    }
}
