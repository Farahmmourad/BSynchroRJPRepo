using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSynchro_RJP_Core.Services
{
    public interface ITransactionService
    {
        Task<bool> CreateTransaction(int accountId, double intialCredit);
    }
}
