using JobBoardMini.Data.Models;

namespace JobBoardMini.Data
{
    public static class DemoData
    {
        public static void Seed(JobBoardDbContext db)
        {
            if (!db.Companies.Any())
            {
                db.Companies.AddRange(
                    new Company
                    {
                        Name = "Telerik",
                        Address = "София",
                        Website = "https://www.telerik.com"
                    },
                    new Company
                    {
                        Name = "SAP",
                        Address = "София",
                        Website = "https://www.sap.com"
                    },
                    new Company
                    {
                        Name = "Progress",
                        Address = "София",
                        Website = "https://www.progress.com"
                    });

                db.SaveChanges();
            }

            if (!db.Categories.Any())
            {
                db.Categories.AddRange(
                    new Category { Name = "Backend Development" },
                    new Category { Name = "Frontend Development" },
                    new Category { Name = "QA" });

                db.SaveChanges();
            }

            if (db.Internships.Any())
            {
                return;
            }

            var telerik = db.Companies.First(c => c.Name == "Telerik");
            var sap = db.Companies.First(c => c.Name == "SAP");
            var progress = db.Companies.First(c => c.Name == "Progress");

            var backend = db.Categories.First(c => c.Name == "Backend Development");
            var frontend = db.Categories.First(c => c.Name == "Frontend Development");
            var qa = db.Categories.First(c => c.Name == "QA");

            db.Internships.AddRange(
                new Internship
                {
                    Position = "Junior C# Developer",
                    CompanyId = telerik.Id,
                    CategoryId = backend.Id,
                    City = "София",
                    DurationWeeks = 12,
                    Description = "Стаж по C# и ASP.NET Core."
                },
                new Internship
                {
                    Position = "Web Developer Intern",
                    CompanyId = sap.Id,
                    CategoryId = frontend.Id,
                    City = "София",
                    DurationWeeks = 10,
                    Description = "Работа по уеб приложения и бази данни."
                },
                new Internship
                {
                    Position = "QA Intern",
                    CompanyId = progress.Id,
                    CategoryId = qa.Id,
                    City = "Пловдив",
                    DurationWeeks = 8,
                    Description = "Практика по тестване на софтуер."
                });

            db.SaveChanges();
        }
    }
}