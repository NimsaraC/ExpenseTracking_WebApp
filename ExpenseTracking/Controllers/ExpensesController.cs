using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExpenseTracking.Models;
using System.Security.Claims;

namespace ExpenseTracking.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly ExpenseDbContext _context;

        public ExpensesController(ExpenseDbContext context)
        {
            _context = context;
        }

        // GET: Expenses
        public async Task<IActionResult> Index()
        {
            return View(await _context.Expenses.ToListAsync());
        }

        // GET: Expenses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expense = await _context.Expenses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (expense == null)
            {
                return NotFound();
            }

            return View(expense);
        }

        // GET: Expenses/Create
        public IActionResult Create()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var allCategories = _context.Categories
                .Where(c => c.UserId == userId || c.UserId == null)
                .ToList();

            var expenseCategories = allCategories.Where(c => c.Type == "Expenses").ToList();
            var incomeCategories = allCategories.Where(c => c.Type == "Income").ToList();

            var data = new ExpenseView
            {
                Expense = new Expense(),
                Categories = allCategories,
                ExpenseCategories = expenseCategories,
                IncomeCategories = incomeCategories
            };

            return View(data);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserID,Amount,CategoryName,Date,Description,Type")] Expense expense)
        {
            if (ModelState.IsValid)
            {
                _context.Add(expense);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Users", new { id = expense.UserID });
            }
            return View(expense);
        }


        // GET: Expenses/Edit/5
        // GET: Expenses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expense = await _context.Expenses.FindAsync(id);
            if (expense == null)
            {
                return NotFound();
            }

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var allCategories = _context.Categories
                .Where(c => c.UserId == userId || c.UserId == null)
                .ToList();

            var expenseCategories = allCategories.Where(c => c.Type == "Expenses").ToList();
            var incomeCategories = allCategories.Where(c => c.Type == "Income").ToList();

            var viewModel = new ExpenseView
            {
                Expense = expense,
                Categories = allCategories,
                ExpenseCategories = expenseCategories,
                IncomeCategories = incomeCategories
            };

            return View(viewModel);
        }

        // POST: Expenses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserID,Amount,CategoryName,Date,Description,Type")] Expense expense)
        {
            if (id != expense.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(expense);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpenseExists(expense.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "Users", new { id = expense.UserID });
            }

            // If the model state is not valid, reload categories for the view
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var allCategories = _context.Categories
                .Where(c => c.UserId == userId || c.UserId == null)
                .ToList();

            var expenseCategories = allCategories.Where(c => c.Type == "Expenses").ToList();
            var incomeCategories = allCategories.Where(c => c.Type == "Income").ToList();

            var viewModel = new ExpenseView
            {
                Expense = expense,
                Categories = allCategories,
                ExpenseCategories = expenseCategories,
                IncomeCategories = incomeCategories
            };

            return View(viewModel);
        }


        // GET: Expenses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expense = await _context.Expenses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (expense == null)
            {
                return NotFound();
            }

            return View(expense);
        }

        // POST: Expenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var expense = await _context.Expenses.FindAsync(id);
            if (expense != null)
            {
                _context.Expenses.Remove(expense);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Users", new { id = expense.UserID });
        }

        private bool ExpenseExists(int id)
        {
            return _context.Expenses.Any(e => e.Id == id);
        }
    }
}
