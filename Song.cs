using System;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesMusic.Models
{
    public class Song
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Artist { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Genre can only contain letters and spaces.")]
        public string Genre { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [StringLength(20)]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Rating can only contain letters and spaces.")]
        public string Rating { get; set; } = string.Empty;
    }
}
