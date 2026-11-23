using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace JobBoardMini.Data.Models
{
    public class Company
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(100)]
        public string Address { get; set; } = string.Empty;

        [MaxLength(200)]
        public string Website { get; set; } = string.Empty;

        public List<Internship> Internships { get; set; } = new();
    }
}