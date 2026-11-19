using JobBoardMini.Services.DTOs.Internships;

namespace JobBoardMini.Web.ViewModels.Internships
{
    public class InternshipsIndexViewModel
    {
        public List<InternshipListDto> Internships { get; set; } = new();
    }
}