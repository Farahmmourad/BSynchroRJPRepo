using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSynchro_RJP_Core.Models
{
    public class Account
    {
        public int AccountId { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public double Balance { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
