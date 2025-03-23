using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Domain.Repositories
{
    public interface IAccountRepository
    {
        public Task<Account> GetById(Guid id);
        public Task<IEnumerable<Account>> GetAll();
        public Task<Account> Create(Guid ownerId);
        public Task Delete(Guid id);
        public Task Update(Account account);
    }
}
