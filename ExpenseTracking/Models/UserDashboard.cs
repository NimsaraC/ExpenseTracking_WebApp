namespace ExpenseTracking.Models
{
    public class UserDashboard
    {
        public User User { get; set; }
        public IEnumerable<Expense> Expenses { get; set; }
        public IEnumerable<Budget> Budgets { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public double TotalBudget { get; set; }
        public double TotalIncome { get; set; }
        public double TotalExpenses { get; set; }
        public Budget CurrentBudget { get; set; }
    }
}
