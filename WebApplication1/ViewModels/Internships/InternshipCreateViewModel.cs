using JobBoardMini.Data.Models;

namespace JobBoardMini.Web.ViewModels.Internships
{
    public class InternshipCreateViewModel
    {
        public Internship Internship { get; set; } = new();

        public List<Company> Companies { get; set; } = new();

        public List<Category> Categories { get; set; } = new();
    }
}