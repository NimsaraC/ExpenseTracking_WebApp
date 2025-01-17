﻿namespace ExpenseTracking.Models
{
    public class ExpenseView
    {
        public Expense Expense { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public Budget Budget { get; set; }
        public IEnumerable<Category> ExpenseCategories { get; set; }
        public IEnumerable<Category> IncomeCategories { get; set; }
    }
}
