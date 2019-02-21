using Application.IO.Site.Services.Business.Select;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Application.IO.Site.Controllers
{
    public class ValuesController : Controller
    {
        public IActionResult ListCidades(int idGeoEstado)
        {
            return Json(new GeoCidadeSelect().Get(idGeoEstado).ToList());
        }
    }
}