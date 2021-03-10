using System.Threading.Tasks;
using BookListRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor.Pages.BookList
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty] public Book Book { get; set; }

        public async Task OnGet(int id)
        {
            Book = await _db.Books.FindAsync(id);
        }

        public async Task<ActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var BookFromDB = await _db.Books.FindAsync(Book.Id);
                BookFromDB.Name = Book.Name;
                BookFromDB.ISBN = Book.ISBN;
                BookFromDB.Author = Book.Author;

                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }

            return RedirectToPage("Index");
        }
    }
}
