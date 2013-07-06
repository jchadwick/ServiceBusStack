using Contracts;
using Domain;
using ServiceStack.Common;
using ServiceStack.Common.Web;
using ServiceStack.ServiceInterface;

namespace WebServiceBus.Services
{
    public class UpdateBankAccountService : Service
    {
        public IBankAccountRepository Repository { get; set; }

        public UpdateBankAccountResponse Put(UpdateBankAccount request)
        {
            var account = Repository.Find(request.AccountId);

            if (account == null)
            {
                throw HttpError.NotFound(string.Format("Bank account {0} not found", request.AccountId));
            }

            account.PopulateWith(request);
            Repository.Save();

            return new UpdateBankAccountResponse { Success = true };
        }
    }
}