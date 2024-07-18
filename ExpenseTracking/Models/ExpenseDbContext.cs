using Microsoft.EntityFrameworkCore;

namespace ExpenseTracking.Models
{
    public class ExpenseDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public ExpenseDbContext(DbContextOptions<ExpenseDbContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = @"Server=localhost;Database=ExpenseTrackingDB;Trusted_Connection=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
