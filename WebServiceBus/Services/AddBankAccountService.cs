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
            var context = new CallbackContext<AddBankAccountResponse>();

            var asyncResult = Bus.Send(request).Register(CompletionResultCallback<AddBankAccountResponse>, context);

            asyncResult.AsyncWaitHandle.WaitOne(50000);

            return context.Result;
        }

        private static void CompletionResultCallback<T>(IAsyncResult context)
        {
            var completionResult = (CompletionResult)context.AsyncState;
            var result = (T)completionResult.Messages[0];
            ((CallbackContext<T>)completionResult.State).Result = result;
        }

        class CallbackContext<T>
        {
            public T Result { get; set; }
        }
    }
}