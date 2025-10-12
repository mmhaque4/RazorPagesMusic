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

        [Required(ErrorMessage = "Racer name is required.")]
        [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Name must contain only letters and spaces.")]
        [Display(Name = "Racer Name")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Home town is required.")]
        [StringLength(50, ErrorMessage = "Home town cannot exceed 50 characters.")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Home town must contain only letters and spaces.")]
        [Display(Name = "Home Town")]
        public string Home { get; set; } = string.Empty;

        [Required(ErrorMessage = "Score is required.")]
        [Range(10.00, 30.00, ErrorMessage = "Score must be between 10.00 and 30.00 seconds.")]
        [Column(TypeName = "decimal(5,2)")] // Fixed precision warning
        [Display(Name = "Score (seconds)")]
        public decimal Score { get; set; }

        [StringLength(50, ErrorMessage = "Horse name cannot exceed 50 characters.")]
        [RegularExpression(@"^[A-Za-z\s]*$", ErrorMessage = "Horse name must contain only letters and spaces.")]
        [Display(Name = "Horse Name")]
        public string? HorseName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Competition Date")]
        public DateTime CompetitionDate { get; set; }

        [StringLength(100, ErrorMessage = "Event location cannot exceed 100 characters.")]
        [Display(Name = "Event Location")]
        public string? EventLocation { get; set; }

        [Display(Name = "Is Qualified for Finals?")]
        public bool Qualified { get; set; } = false;
    }
}
