using System.ComponentModel.DataAnnotations;

namespace JobBoardMini.Data.Models
{
    public class Internship
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Position { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string City { get; set; } = string.Empty;

        [Range(1, 52, ErrorMessage = "Продължителността трябва да е между 1 и 52 седмици.")]
        public int DurationWeeks { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; } = string.Empty;

        [Range(1, int.MaxValue, ErrorMessage = "Избери компания.")]
        public int CompanyId { get; set; }

        public Company? Company { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Избери категория.")]
        public int CategoryId { get; set; }

        public Category? Category { get; set; }
    }
}