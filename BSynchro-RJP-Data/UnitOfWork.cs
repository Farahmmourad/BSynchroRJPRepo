using BSynchro_RJP_Core;
using BSynchro_RJP_Core.Data;
using BSynchro_RJP_Core.Repositories;
using BSynchro_RJP_Data.Repositories;

namespace BSynchro_RJP_Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyDBContext _context;
        private CustomerRepository _customerRepository;
        private AccountRepository _accountRepository;
        private TransactionRepository _transactionRepository;

        public UnitOfWork(MyDBContext myDBContext)
        {
            _context = myDBContext;
        }

        public ICustomerRepository Customers => _customerRepository = _customerRepository ?? new CustomerRepository(_context);

        public IAccountRepository Accounts => _accountRepository = _accountRepository ?? new AccountRepository(_context);

        public ITransactionRepository Transactions => _transactionRepository = _transactionRepository ?? new TransactionRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}