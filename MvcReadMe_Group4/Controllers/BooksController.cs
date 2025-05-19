using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcReadMe_Group4.Data;
using MvcReadMe_Group4.Models;
using System;
using System.Threading.Tasks;

namespace MvcReadMe_Group4.Controllers
{
    public class BooksController : Controller
    {
        private readonly MvcReadMe_Group4Context _context;

        public BooksController(MvcReadMe_Group4Context context)
        {
            _context = context;
        }

        // GET: /Books/Read/5
        public async Task<IActionResult> Read(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            // Increment total reads
            book.NumberOfReads++;

            // Get or create today's BookRead record
            var today = DateTime.Today;
            var bookRead = await _context.BookReads
                .FirstOrDefaultAsync(br => br.ReadDate == today);

            if (bookRead == null)
            {
                bookRead = new BookRead
                {
                    ReadDate = today,
                    ReadCount = 1
                };
                _context.BookReads.Add(bookRead);
            }
            else
            {
                bookRead.ReadCount++;
            }

            await _context.SaveChangesAsync();
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IncrementReads(int bookId)
        {
            // This endpoint is no longer needed as we handle increment in the Read action
            return NotFound();
        }
    }
} 