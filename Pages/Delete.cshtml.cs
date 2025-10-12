using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyBarrelRacers.Data;
using MyBarrelRacers.Models;

namespace MyBarrelRacers.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly MyBarrelRacers.Data.ApplicationDbContext _context;

        public DeleteModel(MyBarrelRacers.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Racer Racer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var racer = await _context.Racers.FirstOrDefaultAsync(m => m.Number == id);

            if (racer == null)
            {
                return NotFound();
            }
            else
            {
                Racer = racer;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var racer = await _context.Racers.FindAsync(id);
            if (racer != null)
            {
                Racer = racer;
                _context.Racers.Remove(Racer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
