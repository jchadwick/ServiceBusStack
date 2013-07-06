using System.Data.Entity;
using Domain;

namespace DataAccess
{
    public class BankAccountRepository : Repository<BankAccount, long>, IBankAccountRepository
    {
        public BankAccountRepository(DbContext context) : base(context)
        {
        }
    }
}