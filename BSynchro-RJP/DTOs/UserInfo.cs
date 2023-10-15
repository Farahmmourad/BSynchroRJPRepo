namespace BSynchro_RJP.DTOs
{
    public class UserInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Balance { get; set; }
        public ICollection<AccountDTO> Accounts { get; set; }
    }
}
