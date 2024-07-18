namespace ExpenseTracking.Models
{
    public class Budget
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public Double Amount { get; set; }
        public string Period { get; set; }
    }
}
