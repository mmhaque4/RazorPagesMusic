using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyBarrelRacers.Data;
using MyBarrelRacers.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MyBarrelRacers.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Racer> Racer { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public async Task OnGetAsync()
        {
            var racers = from r in _context.Racers
                         select r;

            if (!string.IsNullOrEmpty(SearchString))
            {
                racers = racers.Where(r => r.Name.Contains(SearchString));
            }

            Racer = await racers.ToListAsync();
        }
    }
}
