using Microsoft.AspNetCore.Mvc;
using System;

namespace Application.IO.Site.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult About()
        {
            return View();
        }
    }
}
