
using Microsoft.AspNetCore.Mvc;

namespace JobBoardMini.Web.Controllers
{
    public class InternshipsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
