using System.Security.Claims;
using LibraryManager.Data;
using LibraryManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Controllers
{
    public class BooksController : Controller
    {
        private readonly LibraryContext _context;

        public BooksController(LibraryContext context)
        {
            _context = context;
        }

        private int GetCurrentUserId()
        {
            var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userIdClaim)) return 0;
            return int.Parse(userIdClaim);
        }

        public async Task<IActionResult> Index(string search)
        {
            var books = _context.Books.Include(b => b.Author).AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                books = books.Where(b => b.Title.Contains(search));
            }
           
            ViewBag.CurrentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            return View(await books.ToListAsync());
        }

        [Authorize]
        public IActionResult Create()
        {
            ViewBag.Authors = new SelectList(_context.Authors, "Id", "Name");
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book book)
        {
            book.UserId = GetCurrentUserId();

            ModelState.Remove("User");
            ModelState.Remove("Author");

            if (ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Authors = new SelectList(_context.Authors, "Id", "Name", book.AuthorId);
            return View(book);
        }

        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var book = await _context.Books.FindAsync(id);
            if (book == null) return NotFound();

            if (book.UserId != GetCurrentUserId()) return Forbid();

            ViewBag.Authors = new SelectList(_context.Authors, "Id", "Name", book.AuthorId);
            return View(book);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Book book)
        {
            if (id != book.Id) return NotFound();

            var currentUserId = GetCurrentUserId();
            var existingBook = await _context.Books.AsNoTracking().FirstOrDefaultAsync(b => b.Id == id);

            if (existingBook == null || existingBook.UserId != currentUserId)
                return Forbid();

            book.UserId = currentUserId; 

            ModelState.Remove("User");
            ModelState.Remove("Author");

            if (ModelState.IsValid)
            {
                _context.Update(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Authors = new SelectList(_context.Authors, "Id", "Name", book.AuthorId);
            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null) return NotFound();

            if (book.UserId != GetCurrentUserId()) return Forbid();

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}