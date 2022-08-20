namespace MoneyTracker.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Account> Accounts { get; set; } = new();

    }
}
