using Application.IO.Site.Services.Business.Select;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Application.IO.Site.Controllers
{
    public class ValuesController : Controller
    {
        [Authorize]
        public IActionResult ListCidades(int idGeoEstado)
        {
            return Json(new GeoCidadeSelect().Get(idGeoEstado).ToList());
        }

        [Authorize]
        public IActionResult PostalCode(string pcode)
        {
            return Json(new GeoCepSelect().GetByCod(pcode));
        }
    }
}