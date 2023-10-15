using BSynchro_RJP_Core.Models;

namespace BSynchro_RJP.DTOs
{
    public class TransactionDTO
    {
        public int TransactionId { get; set; }
        public double Amount { get; set; }
        public string Type { get; set; }
        public bool Status { get; set; }
    }
}
