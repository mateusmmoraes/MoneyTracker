using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace MoneyTracker.Models
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public double CurrentBalance { get; set; }

        public int Order { get; set; }

        public virtual List<Balance> Balances { get; set; } = new();
        public virtual List<Transaction> Transactions { get; set; } = new();
        private readonly List<Account> _Accounts;
        //public IEnumerable<SelectListItem> AccountsNames
        //{
        //    get
        //    { return new SelectList(_Accounts, "Id", "Name"); }
        //}
    }
}
