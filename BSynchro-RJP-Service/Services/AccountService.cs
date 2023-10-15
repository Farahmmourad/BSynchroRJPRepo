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
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AccountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Account> CreateAccount(int customerId)
        {
            Account account = new Account
            {
                Balance = 0,
                CustomerId = customerId,
                IsActive = true,
            };
            await _unitOfWork.Accounts.CreateAsync(account);
            await _unitOfWork.CommitAsync();
            return account;
        }
    }
}
