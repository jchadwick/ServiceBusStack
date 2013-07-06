using System;
using Contracts;
using Domain;
using ServiceStack.Common;
using ServiceStack.Common.Web;
using ServiceStack.ServiceInterface;

namespace WebServiceBus.Services
{
    public class MakeDepositService : Service
    {
        public IBankAccountRepository Repository { get; set; }

        public MakeDepositResponse Post(MakeDeposit request)
        {
            if (request.DepositAmount <= 0)
            {
                throw new ArgumentException("Deposit amount must be positive", "DepositAmount");
            }

            var account = Repository.Find(request.AccountId);

            if (account == null)
            {
                throw HttpError.NotFound(string.Format("Bank account {0} not found", request.AccountId));
            }

            account.Balance += request.DepositAmount;
            Repository.Save();

            return new MakeDepositResponse { Success = true }.PopulateWith(account);
        }
    }
}