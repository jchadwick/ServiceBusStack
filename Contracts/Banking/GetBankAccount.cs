using Domain;
using ServiceStack.ServiceHost;

namespace Contracts
{
    [Route("/banking/accounts/{AccountId}")]
    public class GetBankAccount : IReturn<GetBankAccountResponse>
    {
        public long AccountId { get; set; }
    }

    public class GetBankAccountResponse : ApiResponse
    {
        public long AccountId { get; set; }
        public long BankId { get; set; }
        public string RoutingNumber { get; set; }
        public string AccountNumber { get; set; }
        public string Nickname { get; set; }
        public decimal AvailableBalance { get; set; }
    }
}
