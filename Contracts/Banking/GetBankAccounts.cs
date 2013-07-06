using Domain;
using ServiceStack.ServiceHost;

namespace Contracts
{
    [Route("/banking/accounts", "GET")]
    public class GetBankAccounts : IReturn<GetBankAccountsResponse>
    {
    }

    public class GetBankAccountsResponse : ApiResponse
    {
        public BankAccount[] Accounts { get; set; }
    }
}