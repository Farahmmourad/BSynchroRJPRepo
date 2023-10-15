using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSynchro_RJP_Core.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public double Amount { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }
        public string Type { get; set; }
        public bool Status { get; set; }
    }
}
