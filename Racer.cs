using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // Needed for [Column]

namespace MyBarrelRacers.Models
{
    public class Racer
    {
        [Key]
        [Display(Name = "Racer Number")]
        public int Number { get; set; }

        [Required]
        [StringLength(50)]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Name can only contain letters and spaces.")]
        [Display(Name = "Racer Name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        [Display(Name = "Home Town")]
        public string Home { get; set; } = string.Empty;

        [Required]
        [Range(10.00, 30.00, ErrorMessage = "Score must be between 10.00 and 30.00 seconds.")]
        [Column(TypeName = "decimal(5,2)")] // Fixed precision warning
        [Display(Name = "Score (seconds)")]
        public decimal Score { get; set; }

        [Display(Name = "Horse Name")]
        [StringLength(50, ErrorMessage = "Horse name cannot exceed 50 characters.")]
        public string? HorseName { get; set; }

        [Display(Name = "Competition Date")]
        [DataType(DataType.Date)]
        public DateTime CompetitionDate { get; set; }

        [Display(Name = "Event Location")]
        [StringLength(100, ErrorMessage = "Event location cannot exceed 100 characters.")]
        public string? EventLocation { get; set; }

        [Display(Name = "Is Qualified for Finals?")]
        public bool Qualified { get; set; } = false;
    }
}
