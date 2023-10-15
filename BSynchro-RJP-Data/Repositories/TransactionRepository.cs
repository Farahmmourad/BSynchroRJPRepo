﻿using BSynchro_RJP_Core.Data;
using BSynchro_RJP_Core.Models;
using BSynchro_RJP_Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSynchro_RJP_Data.Repositories
{
    public class TransactionRepository : Repository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(MyDBContext context) : base(context)
        {
        }
    }
}
