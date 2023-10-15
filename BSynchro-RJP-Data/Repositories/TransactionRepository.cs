using BSynchro_RJP_Core.Data;
using BSynchro_RJP_Core.Models;
using BSynchro_RJP_Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSynchro_RJP_Data.Repositories
{
    public class TransactionRepository : Repository<Transaction>, ITransactionRepository
    {
        private readonly MyDBContext _dbContext;
        public TransactionRepository(MyDBContext context) : base(context)
        {
            _dbContext = context;
        }

        public async Task<IEnumerable<Transaction>> GetByAccountAsync(int accountId)
        {
            return await _dbContext.Set<Transaction>().Where(a => a.AccountId == accountId).ToListAsync();
        }
    }
}
