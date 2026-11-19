
using JobBoardMini.Library;

namespace JobBoardMini.Data
{
    public static class DemoData
    {
        public static void Seed(JobBoardDbContext db)
        {
            if (db.Internships.Any())
            {
                return;
            }

            var internships = new List<Internship>
            {
                new Internship
                {
                    Position = "Junior C# Developer",
                    Organization = "Telerik",
                    City = "София",
                    DurationWeeks = 12,
                    Description = "Стаж по C# и ASP.NET Core."
                },

                new Internship
                {
                    Position = "Web Developer Intern",
                    Organization = "SAP",
                    City = "София",
                    DurationWeeks = 10,
                    Description = "Работа по уеб приложения и бази данни."
                },

                new Internship
                {
                    Position = "Frontend Developer Intern",
                    Organization = "Progress",
                    City = "Пловдив",
                    DurationWeeks = 8,
                    Description = "Практика с HTML, CSS и JavaScript."
                }
            };

            db.Internships.AddRange(internships);
            db.SaveChanges();
        }
    }
}
