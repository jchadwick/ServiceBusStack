namespace Domain
{
    public interface IBankAccountRepository : IRepository<BankAccount, long>
    {
    }

    public class BankAccount
    {
        public long Id { get; set; }
        public long BankId { get; set; }
        public string RoutingNumber { get; set; }
        public string AccountNumber { get; set; }
        public string Nickname { get; set; }

        public decimal AvailableBalance { get; set; }
        public decimal Balance { get; set; }
    }
}
