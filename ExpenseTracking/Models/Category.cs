namespace ExpenseTracking.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? UserId { get; set; }
        public string Type { get; set; }
    }
}
