using System.Linq;
using Contracts;
using Domain;
using NServiceBus;

namespace ServiceBus.Banking
{
    public class GetBankAccountsService : IHandleMessages<GetBankAccounts>
    {
        public IBus Bus { get; set; }
        public IBankAccountRepository Repository { get; set; }

        public void Handle(GetBankAccounts request)
        {
            BankAccount[] accounts = Repository.Query().ToArray();
            Bus.Reply(new GetBankAccountsResponse { Success = true, Accounts = accounts });
        }
    }
}