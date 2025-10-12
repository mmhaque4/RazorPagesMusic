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
    public class DetailsModel : PageModel
    {
        private readonly MyBarrelRacers.Data.ApplicationDbContext _context;

        public DetailsModel(MyBarrelRacers.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
