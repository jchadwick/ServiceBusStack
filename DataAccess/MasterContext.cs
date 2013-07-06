using System.Data.Entity;
using Domain;

namespace DataAccess
{
    public class MasterContext : DbContext
    {
        public DbSet<BankAccount> BankAccounts { get; set; }

        public MasterContext()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MasterContext>());
        }
    }
}