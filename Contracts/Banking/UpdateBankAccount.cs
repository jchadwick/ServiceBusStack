using ServiceStack.ServiceHost;

namespace Contracts
{
    [Route("/banking/accounts/{AccountId}", "PUT")]
    public class UpdateBankAccount : IReturn<UpdateBankAccountResponse>
    {
        public long AccountId { get; set; }
        public long BankId { get; set; }
        public string Nickname { get; set; }
        public string AccountNumber { get; set; }
        public string RoutingNumber { get; set; }
    }

    public class UpdateBankAccountResponse : ApiResponse
    {
    }
}