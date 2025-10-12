using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyBarrelRacers.Data;
using MyBarrelRacers.Models;
using System.Threading.Tasks;

namespace MyBarrelRacers.Pages
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Racer Racer { get; set; } = new Racer();

        public void OnGet()
        {
            // Nothing needed here, form will be empty
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Racers.Add(Racer);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}

