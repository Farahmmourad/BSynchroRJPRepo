using BSynchro_RJP_Core.Models;

namespace BSynchro_RJP.DTOs
{
    public class AccountDTO
    {
        public int AccountId { get; set; }
        public double Balance { get; set; }
        public ICollection<TransactionDTO> Transactions { get; set; }

    }
}
