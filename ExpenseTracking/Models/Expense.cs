namespace ExpenseTracking.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public Double Amount { get; set; }
        public int CategoryId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}
