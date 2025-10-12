using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyBarrelRacers.Data;
using MyBarrelRacers.Models;
using System.Threading.Tasks;

namespace MyBarrelRacers.Pages
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Racer Racer { get; set; } = new Racer();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Racer = await _context.Racers.FindAsync(id);

            if (Racer == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Racer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RacerExists(Racer.Number))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("Index");
        }

        private bool RacerExists(int id)
        {
            return _context.Racers.Any(e => e.Number == id);
        }
    }
}
