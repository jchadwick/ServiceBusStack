using System.Linq;
using Contracts;
using Domain;
using ServiceStack.ServiceInterface;

namespace WebServiceBus.Services
{
    public class GetBankAccountsService : Service
    {
        public IBankAccountRepository Repository { get; set; }

        public GetBankAccountsResponse Get(GetBankAccounts request)
        {
            BankAccount[] accounts = Repository.Query().ToArray();
            return new GetBankAccountsResponse { Success = true, Accounts = accounts };
        }
    }
}