namespace ExpenseTracking.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public Double Amount { get; set; }
        public string CategoryName { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string Description { get; set; }
        public string Type { get; set; }
    }
}
