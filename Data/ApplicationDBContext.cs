using Microsoft.EntityFrameworkCore;
using MyBarrelRacers.Models;

namespace MyBarrelRacers.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Racer> Racers { get; set; }
    }
}

