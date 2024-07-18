namespace ExpenseTracking.Models
{
    public class UserDashboard
    {
        public User User { get; set; }
        public IEnumerable<Expense> Expenses { get; set; }
        public IEnumerable<Budget> Budgets { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
