using System.ComponentModel.DataAnnotations;

namespace ExpenseTracking.Models
{
    public class User
    {
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Currency { get; set; }
    }
}
