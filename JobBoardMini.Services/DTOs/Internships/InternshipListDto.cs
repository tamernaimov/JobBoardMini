namespace JobBoardMini.Services.DTOs.Internships
{
    public class InternshipListDto
    {
        public int Id { get; set; }
        public string Position { get; set; } = string.Empty;
        public string Organization { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public int DurationWeeks { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}