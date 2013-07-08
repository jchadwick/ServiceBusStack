using System;
using System.Threading;
using Contracts;
using Domain;
using NServiceBus;

namespace ServiceBus.Banking
{
    public class AddBankAccountService : IHandleMessages<AddBankAccount>
    {
        public IBus Bus { get; set; }
        public IBankAccountRepository Repository { get; set; }

        public void Handle(AddBankAccount message)
        {
            Thread.Sleep(500);
            var newAccount = AutoMapper.Mapper.DynamicMap<BankAccount>(message);

/*
            Repository.Insert(newAccount);
            Repository.Save();
*/

            Console.WriteLine("======= AddBankAccount: {0} =======", newAccount.AccountNumber);

            newAccount.Id = 1;

            var response = new AddBankAccountResponse
                {
                    AccountId = newAccount.Id,
                    Success = newAccount.Id != 0, 
                };

            Bus.Reply(response);
        }
    }
}