using BSynchro_RJP_Core;
using BSynchro_RJP_Core.Models;
using BSynchro_RJP_Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSynchro_RJP_Service.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TransactionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> CreateTransaction(int accountId, double intialCredit)
        {
            var account = await _unitOfWork.Accounts.FindByIdAsync(accountId);
            var customer = await _unitOfWork.Customers.FindByIdAsync(account.CustomerId);
            Transaction transaction = new Transaction
            {
                AccountId = accountId,
                CustomerId = customer.CustomerId,
                Amount = intialCredit,
                Type = "Deposit"
            };

            if (intialCredit > customer.Balance)
            {
                transaction.Status = false;
            }
            else
            {
                transaction.Status = true;
            }
            
            customer.Balance -= intialCredit;
            account.Balance = intialCredit;
            await _unitOfWork.Transactions.CreateAsync(transaction);
            await _unitOfWork.CommitAsync();

            return transaction.Status;
        }
    }
}
