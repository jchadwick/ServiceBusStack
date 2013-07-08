namespace ServiceBus.Banking
{
    public class GetBankAccountService : Service
    {
        public IBankAccountRepository Repository { get; set; }

        public GetBankAccountResponse Get(GetBankAccount request)
        {
            var account = Repository.Find(request.AccountId);

            if (account == null)
                throw HttpError.NotFound(string.Format("Bank account {0} not found", request.AccountId));

            return new GetBankAccountResponse { Success = (account != null) }.PopulateWith(account);
        }
    }
}