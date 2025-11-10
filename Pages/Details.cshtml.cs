using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMusic.Data;
using RazorPagesMusic.Models;

namespace RazorPagesMusic.Pages.Songs
{
    public class DetailsModel : PageModel
    {
        private readonly MusicContext _context;

        public DetailsModel(MusicContext context)
        {
            _context = context;
        }

        public Song Song { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var song = await _context.Songs.FirstOrDefaultAsync(s => s.Id == id);

            if (song == null)
            {
                return NotFound();
            }

            Song = song;
            return Page();
        }
    }
}
