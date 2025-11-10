using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMusic.Data;
using RazorPagesMusic.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RazorPagesMusic.Pages.Songs
{
    public class IndexModel : PageModel
    {
        private readonly MusicContext _context;

        public IndexModel(MusicContext context)
        {
            _context = context;
        }

        // List of songs to display
        public IList<Song> Songs { get; set; } = default!;

        // For search functionality
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; } = string.Empty;

        public async Task OnGetAsync()
        {
            var songs = from s in _context.Songs
                        select s;

            if (!string.IsNullOrEmpty(SearchString))
            {
                songs = songs.Where(s => s.Title.Contains(SearchString));
            }

            Songs = await songs.ToListAsync();
        }
    }
}
