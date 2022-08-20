using Microsoft.EntityFrameworkCore;
namespace MoneyTracker.Models
{
    public partial class MoneyTrackerContext : DbContext
    {
        public MoneyTrackerContext()
        {

        }
        public MoneyTrackerContext(DbContextOptions<MoneyTrackerContext> options) : base(options)
        {

        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Balance> Balances { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
