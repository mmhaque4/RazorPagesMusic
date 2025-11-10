using Microsoft.EntityFrameworkCore;
using RazorPagesMusic.Models; // Updated to your new Song model

namespace RazorPagesMusic.Data
{
    public class MusicContext : DbContext
    {
        public MusicContext(DbContextOptions<MusicContext> options)
            : base(options)
        {
        }

        public DbSet<Song> Songs { get; set; } // Updated from Racers to Songs

        // Seed initial data for the assignment
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Song>().HasData(
                new Song { Id = 1, Title = "Midnight Sun", Artist = "Aurora Ray", Genre = "Indie Pop", ReleaseDate = new DateTime(2018, 9, 14), Rating = "Good" },
                new Song { Id = 2, Title = "Desert Roads", Artist = "The Nomads", Genre = "Folk-Rock", ReleaseDate = new DateTime(2020, 6, 1), Rating = "Better" },
                new Song { Id = 3, Title = "Neon Skyline", Artist = "Vivid Echo", Genre = "Synthwave", ReleaseDate = new DateTime(2022, 11, 5), Rating = "Best" },
                new Song { Id = 4, Title = "Blue Harbor", Artist = "Harbour Lights", Genre = "Jazz", ReleaseDate = new DateTime(2015, 3, 20), Rating = "Good" }
            );
        }
    }
}

