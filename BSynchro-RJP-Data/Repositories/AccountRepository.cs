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
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        private readonly MyDBContext _dbContext;
        public AccountRepository(MyDBContext context) : base(context)
        {
            _dbContext = context;
        }

        public async Task<IEnumerable<Account>> GetByCustomerAsync(int customerId)
        {
            return await _dbContext.Set<Account>().Where( a => a.CustomerId == customerId && a.IsActive == true).ToListAsync();
        }
    }
}
