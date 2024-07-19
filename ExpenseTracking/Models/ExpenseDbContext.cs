using Microsoft.EntityFrameworkCore;

namespace ExpenseTracking.Models
{
    public class ExpenseDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Budget> Budgets { get; set; }

        public ExpenseDbContext(DbContextOptions<ExpenseDbContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Food", Type= "Expenses" },
                new Category { Id = 2, Name = "Transport", Type = "Expenses" },
                new Category { Id = 3, Name = "Utilities", Type = "Expenses" },
                new Category { Id = 4, Name = "Entertainment", Type = "Expenses" },
                new Category { Id = 5, Name = "Rental", Type = "Income" },
                new Category { Id = 6, Name = "Salary", Type = "Income" },
                new Category { Id = 7, Name = "Others", Type = "Income" },
                new Category { Id = 8, Name = "Others", Type = "Expenses" }
            );

            modelBuilder.Entity<User>().HasData(
                new User {Id= 1, Name = "User", Email = "email@gmail.com", Password = "1234", Phone = "119"}
            );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = @"Server=localhost;Database=ExpenseTrackingDB;Trusted_Connection=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
