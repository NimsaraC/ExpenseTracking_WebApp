using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExpenseTracking.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace ExpenseTracking.Controllers
{
    public class UsersController : Controller
    {
        private readonly ExpenseDbContext _context;

        public UsersController(ExpenseDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            var categories = GetCategoriesByUserIdAsync(id);
            var expenses = GetExpensesByUserIdAsync(id);
            var budgets = GetBudgetsByUserIdAsync(id);

            var userDashboard = new UserDashboard
            {
                User = user,
                Categories = await categories,
                Expenses = await expenses,
                Budgets = await budgets
            };

            if (user == null)
            {
                return NotFound();
            }

            return View(userDashboard);
        }

        private async Task<IEnumerable<Category>> GetCategoriesByUserIdAsync(int? userId)
        {
            return await _context.Categories.Where(r => r.UserId == userId.ToString()).ToListAsync();
        }
        private async Task<IEnumerable<Expense>> GetExpensesByUserIdAsync(int? userId)
        {
            return await _context.Expenses.Where(r => r.UserID == userId).ToListAsync();
        }
        private async Task<IEnumerable<Budget>> GetBudgetsByUserIdAsync(int? userId)
        {
            return await _context.Budgets.Where(r => r.UserId == userId).ToListAsync();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,Password,Phone,Currency")] User user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(user);
                    await _context.SaveChangesAsync();
                    ModelState.Clear();
                    ViewBag.Message = $"{user.Name} registered successfully. Please log in.";
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Please enter a unique email and password.");
                    return View(user);
                }
                return View();
            }
            return View(user);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,Password,Phone,Currency")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLogin userLogin)
        {
            if (ModelState.IsValid)
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == userLogin.Email && x.Password == userLogin.Password);
                if (user != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Name, user.Email),
                        new Claim("Name", user.Name),
                        new Claim(ClaimTypes.Role, "User"),
                    };
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                    return RedirectToAction("Details", "Users", new { area = "", id = user.Id });
                }
                else
                {
                    ModelState.AddModelError("", "Email or Password is not correct.");
                    ViewBag.Message = $"Email or Password is not correct.";
                }
            }
            return View();
        }
    }
}
