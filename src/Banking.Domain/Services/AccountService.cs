
using Banking.Domain.Repositories;

namespace Banking.Domain
{
    public class AccountService
    {
        private readonly ITransferRepository _transferRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IAccountRepository _accountRepository;

        public AccountService(ITransferRepository transferRepository, ITransactionRepository transactionRepository, IAccountRepository accountRepository)
        {
            _transferRepository = transferRepository;
            _transactionRepository = transactionRepository;
            _accountRepository = accountRepository;
        }

        public async Task<Transfer> TransferAmount(Guid sourceAccountId, Guid destinationAccountId, Money amount)
        {
            var sourceAccount = await _accountRepository.GetById(sourceAccountId);
            var destinationAccount = await _accountRepository.GetById(destinationAccountId);

            if (sourceAccount == null || destinationAccount == null)
            {
                throw new Exception("Account not found.");
            }

            if (sourceAccount.Balance < amount)
            {
                throw new Exception("Insufficient funds.");
            }

            var transfer = new Transfer(sourceAccountId, destinationAccountId, amount);
            await _transferRepository.Create(transfer);

            sourceAccount.Withdraw(amount);
            destinationAccount.Deposit(amount);

            await _transactionRepository.Create(new Transaction(sourceAccountId, amount, TransactionType.TransferOut));
            await _transactionRepository.Create(new Transaction(destinationAccountId, amount, TransactionType.TransferIn));

            await _accountRepository.Update(sourceAccount);
            await _accountRepository.Update(destinationAccount);

            return transfer;
        }
    }
}
