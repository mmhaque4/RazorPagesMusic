using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesMusic.Data;
using RazorPagesMusic.Models;
using System.Threading.Tasks;

namespace RazorPagesMusic.Pages.Songs
{
    public class CreateModel : PageModel
    {
        private readonly MusicContext _context;

        public CreateModel(MusicContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Song Song { get; set; } = new Song();

        public void OnGet()
        {
            // Nothing needed here; form will be empty
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Songs.Add(Song);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
