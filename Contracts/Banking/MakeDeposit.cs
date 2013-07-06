using ServiceStack.ServiceHost;

namespace Contracts
{
    [Route("/banking/accounts/{AccountId}/deposit", "POST")]
    public class MakeDeposit : IReturn<MakeDepositResponse>
    {
        public long AccountId { get; set; }
        public decimal DepositAmount { get; set; }
    }

    public class MakeDepositResponse : ApiResponse
    {
        public decimal Balance { get; set; }
        public decimal AvailableBalance { get; set; }
    }
}