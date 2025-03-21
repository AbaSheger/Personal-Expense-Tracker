using System;

namespace PersonalExpenseTracker
{
    public class Expense
    {
        public decimal Amount { get; set; }
        public CategoryEnum Category { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}
