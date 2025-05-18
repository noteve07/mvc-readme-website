using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MvcReadMe_Group4.Models;
using MvcReadMe_Group4.Data;
using Microsoft.EntityFrameworkCore;

namespace MvcReadMe_Group4.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly MvcReadMe_Group4Context _context;

        public UserController(ILogger<UserController> logger, MvcReadMe_Group4Context context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Home()
        {
            var books = await _context.Books.ToListAsync();
            return View(books);
        }

        public IActionResult BookDetails(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null) return NotFound();

            // First try to get books from the same category
            var sameCategoryBooks = _context.Books
                .Where(b => b.Category == book.Category && b.Id != book.Id)
                .Take(5)
                .ToList();

            // If we don't have enough books from the same category, get more from other categories
            if (sameCategoryBooks.Count < 5)
            {
                var otherCategoryBooks = _context.Books
                    .Where(b => b.Category != book.Category && b.Id != book.Id)
                    .Take(5 - sameCategoryBooks.Count)
                    .ToList();

                sameCategoryBooks.AddRange(otherCategoryBooks);
            }

            ViewBag.Recommendations = sameCategoryBooks;
            return View(book);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
