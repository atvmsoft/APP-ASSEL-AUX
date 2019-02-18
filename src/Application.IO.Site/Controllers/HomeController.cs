using Microsoft.AspNetCore.Mvc;

namespace Application.IO.Site.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
    }
}
