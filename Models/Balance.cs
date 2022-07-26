﻿using System.ComponentModel.DataAnnotations;

namespace MoneyTracker.Models
{
    public class Balance
    {
        [Required]
        public string AccountName { get; set; }
        public virtual Account Account { get; set; }

        public int Id { get; set; }

        public double Value { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
