using System.ComponentModel.DataAnnotations;

namespace JobBoardMini.Library
{
    public class Internship
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Въведи позиция.")]
        public string Position { get; set; } = string.Empty;

        [Required(ErrorMessage = "Въведи организация.")]
        public string Organization { get; set; } = string.Empty;

        [Required(ErrorMessage = "Въведи населено място.")]
        public string City { get; set; } = string.Empty;

        [Range(1, int.MaxValue,
            ErrorMessage = "Продължителността трябва да е положителна.")]
        public int DurationWeeks { get; set; }

        [Required(ErrorMessage = "Въведи описание.")]
        public string Description { get; set; } = string.Empty;
    }
}