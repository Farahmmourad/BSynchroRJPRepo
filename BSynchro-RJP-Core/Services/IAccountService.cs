using BSynchro_RJP_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSynchro_RJP_Core.Services
{
    public interface IAccountService
    {
        Task<Account> CreateAccount(int customerId);
    }
}
