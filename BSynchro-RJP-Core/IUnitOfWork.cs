using BSynchro_RJP_Core.Repositories;

namespace BSynchro_RJP_Core
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository Customers { get; }
        IAccountRepository Accounts { get; }
        ITransactionRepository Transactions { get; }
        Task<int> CommitAsync();
    }
}