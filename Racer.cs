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
        [Display(Name = "Racer Name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Home Town")]
        public string Home { get; set; } = string.Empty;

        [Required]
        [Range(10.00, 30.00)]
        [Column(TypeName = "decimal(5,2)")] // Fixed precision warning
        [Display(Name = "Score (seconds)")]
        public decimal Score { get; set; }

        // 🆕 New Fields Added

        [Display(Name = "Horse Name")]
        [StringLength(50)]
        public string? HorseName { get; set; }

        [Display(Name = "Competition Date")]
        [DataType(DataType.Date)]
        public DateTime CompetitionDate { get; set; }

        [Display(Name = "Event Location")]
        [StringLength(100)]
        public string? EventLocation { get; set; }

        [Display(Name = "Is Qualified for Finals?")]
        public bool Qualified { get; set; } = false;
    }
}
