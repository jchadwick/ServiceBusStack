using ServiceStack.ServiceHost;

namespace Contracts
{
    [Route("/banking/accounts", "POST")]
    public class AddBankAccount : IReturn<AddBankAccountResponse>
    {
        public long BankId { get; set; }
        public string Nickname { get; set; }
        public string AccountNumber { get; set; }
        public string RoutingNumber { get; set; }
    }

    public class AddBankAccountResponse : ApiResponse
    {
        public long AccountId { get; set; }
    }
}