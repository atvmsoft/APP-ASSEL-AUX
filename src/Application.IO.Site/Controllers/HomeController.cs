using Application.IO.Site.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Application.IO.Site.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
