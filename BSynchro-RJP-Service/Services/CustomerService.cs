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
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Customer> GetCustomer(int customerId)
        {
            var customer = await _unitOfWork.Customers.FindByIdAsync(customerId);

            if (customer == null)
            {
                return null;
            }

            var customerAccounts = await _unitOfWork.Accounts.GetByCustomerAsync(customerId);

            customer.Accounts = new List<Account>();
            customer.Accounts = customerAccounts.ToList();

            foreach (var account in customerAccounts)
            {
                var accountTransactions = await _unitOfWork.Transactions.GetByAccountAsync(account.AccountId);

                if (accountTransactions != null)
                {
                    account.Transactions = new List<Transaction>();
                    account.Transactions = accountTransactions.ToList();
                }
            }

            return customer;
        }

    }
}
