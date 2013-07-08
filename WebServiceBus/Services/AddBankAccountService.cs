using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts;
using NServiceBus;
using ServiceStack.ServiceInterface;

namespace WebServiceBus.Services
{
    public class AddBankAccountService : Service
    {
        public IBus Bus { get; set; }

        public AddBankAccountResponse Post(AddBankAccount request)
        {
            AddBankAccountResponse response = null;

            var asyncResult = Bus.Send(request).Register(x => response = CompletionResultCallback<AddBankAccountResponse>(x), null);

            asyncResult.AsyncWaitHandle.WaitOne();

            return response;
        }

        private static T CompletionResultCallback<T>(IAsyncResult result)
        {
            var completionResult = (CompletionResult)result.AsyncState;
            var response = (T)completionResult.Messages[0];
            return response;
        }
    }
}