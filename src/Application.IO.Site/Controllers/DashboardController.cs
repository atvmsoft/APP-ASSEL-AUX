using Application.IO.Site.Interfaces;
using Application.IO.Site.Models.Source;
using Application.IO.Site.Models.SystemModels.AreaAtuacao;
using Application.IO.Site.Models.SystemModels.Situacao;
using Application.IO.Site.Models.SystemModels.TipoContato;
using Application.IO.Site.Models.SystemModels.TipoEndereco;
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

        #region Situacao
        [HttpGet]
        public PartialViewResult GridSituacao()
        {
            return PartialView("Situacao/Partials/_GridView", new SituacaoSelect().Get());
        }

        [HttpPost]
        public IActionResult EdtSituacao(int id)
        {
            var model = new SituacaoModel();

            var obj = new SituacaoSelect().GetById(id);
            if (obj != null)
            {
                model.Id = obj.Id;
                model.Nome = obj.Nome;
            }

            return PartialView("Situacao/Partials/_EdtPartial", model);
        }

        [HttpPost]
        public IActionResult DelSituacao(int id)
        {
            var model = new SituacaoModel();

            var obj = new SituacaoSelect().GetById(id);
            if (obj != null)
            {
                model.Id = obj.Id;
                model.Nome = obj.Nome;
            }

            return PartialView("Situacao/Partials/_DelPartial", model);
        }

        [HttpPost]
        public IActionResult SaveSituacao(SituacaoModel model)
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


            return Json(new SituacaoCore().Save(model, UserId));
        }
        #endregion

        #region TipoContato
        [HttpGet]
        public PartialViewResult GridTipoContato()
        {
            return PartialView("TipoContato/Partials/_GridView", new TipoContatoSelect().Get());
        }

        [HttpPost]
        public IActionResult EdtTipoContato(int id)
        {
            var model = new TipoContatoModel();

            var obj = new TipoContatoSelect().GetById(id);
            if (obj != null)
            {
                model.Id = obj.Id;
                model.Nome = obj.Nome;
            }

            return PartialView("TipoContato/Partials/_EdtPartial", model);
        }

        [HttpPost]
        public IActionResult DelTipoContato(int id)
        {
            var model = new TipoContatoModel();

            var obj = new TipoContatoSelect().GetById(id);
            if (obj != null)
            {
                model.Id = obj.Id;
                model.Nome = obj.Nome;
            }

            return PartialView("TipoContato/Partials/_DelPartial", model);
        }

        [HttpPost]
        public IActionResult SaveTipoContato(TipoContatoModel model)
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


            return Json(new TipoContatoCore().Save(model, UserId));
        }
        #endregion

        #region TipoEndereco
        [HttpGet]
        public PartialViewResult GridTipoEndereco()
        {
            return PartialView("TipoEndereco/Partials/_GridView", new TipoEnderecoSelect().Get());
        }

        [HttpPost]
        public IActionResult EdtTipoEndereco(int id)
        {
            var model = new TipoEnderecoModel();

            var obj = new TipoEnderecoSelect().GetById(id);
            if (obj != null)
            {
                model.Id = obj.Id;
                model.Nome = obj.Nome;
            }

            return PartialView("TipoEndereco/Partials/_EdtPartial", model);
        }

        [HttpPost]
        public IActionResult DelTipoEndereco(int id)
        {
            var model = new TipoEnderecoModel();

            var obj = new TipoEnderecoSelect().GetById(id);
            if (obj != null)
            {
                model.Id = obj.Id;
                model.Nome = obj.Nome;
            }

            return PartialView("TipoEndereco/Partials/_DelPartial", model);
        }

        [HttpPost]
        public IActionResult SaveTipoEndereco(TipoEnderecoModel model)
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


            return Json(new TipoEnderecoCore().Save(model, UserId));
        }
        #endregion
    }
}