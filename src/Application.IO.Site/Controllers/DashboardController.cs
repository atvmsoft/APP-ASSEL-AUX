using Application.IO.Site.Interfaces;
using Application.IO.Site.Models.Source;
using Application.IO.Site.Models.SystemModels.AreaAtuacao;
using Application.IO.Site.Services.Business.Core;
using Application.IO.Site.Services.Business.Select;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Application.IO.Site.Controllers
{
    [Authorize]
    public class DashboardController : ControllerBase
    {
        public DashboardController(IUser user) : base(user) { }
        
        public IActionResult Index()
        {
            return View();
        }

        #region AreaAtuacao
        [HttpGet]
        public PartialViewResult GridAreaAtuacao()
        {
            return PartialView("AreaAtuacao/Partials/_GridView", new AreaAtuacaoSelect().Get());
        }

        [HttpPost]
        public IActionResult EdtAreaAtuacao(int id)
        {
            var model = new AreaAtuacaoModel();

            var obj = new AreaAtuacaoSelect().GetById(id);
            if (obj != null)
            {
                model.Id = obj.Id;
                model.Nome = obj.Nome;
            }

            return PartialView("AreaAtuacao/Partials/_EdtPartial", model);
        }

        [HttpPost]
        public IActionResult DelAreaAtuacao(int id)
        {
            var model = new AreaAtuacaoModel();

            var obj = new AreaAtuacaoSelect().GetById(id);
            if (obj != null)
            {
                model.Id = obj.Id;
                model.Nome = obj.Nome;
            }

            return PartialView("AreaAtuacao/Partials/_DelPartial", model);
        }

        [HttpPost]
        public IActionResult SaveAreaAtuacao(AreaAtuacaoModel model)
        {
            if (!ModelState.IsValid)
            {
                var retorno = new ReturnAction();
                foreach (var item in ModelState.Values.SelectMany(s => s.Errors).Select(s => s.ErrorMessage))
                {
                    retorno.Mensagens.Add(item);
                }

                return Json(retorno);
            }


            return Json(new AreaAtuacaoCore().Save(model, UserId));
        }
        #endregion
    }
}