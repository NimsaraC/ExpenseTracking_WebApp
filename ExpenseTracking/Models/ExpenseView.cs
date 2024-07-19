namespace ExpenseTracking.Models
{
    public class ExpenseView
    {
        public Expense Expense { get; set; }
        public IEnumerable<Category> Categories { get; set; }


    }
}
