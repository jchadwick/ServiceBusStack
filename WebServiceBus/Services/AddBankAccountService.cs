using Contracts;
using Domain;
using ServiceStack.Common;
using ServiceStack.ServiceInterface;

namespace WebServiceBus.Services
{
    public class AddBankAccountService : Service
    {
        public IBankAccountRepository Repository { get; set; }

        public AddBankAccountResponse Post(AddBankAccount request)
        {
            var newAccount = new BankAccount().PopulateWith(request);

            Repository.Insert(newAccount);
            Repository.Save();

            return new AddBankAccountResponse
                {
                    AccountId = newAccount.Id,
                    Success = newAccount.Id != 0, 
                };
        }
    }
}