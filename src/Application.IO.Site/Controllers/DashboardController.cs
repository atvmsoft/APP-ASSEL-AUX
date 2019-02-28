using Application.IO.Site.Interfaces;
using Application.IO.Site.Models.Domain;
using Application.IO.Site.Models.SystemModels.Advogado;
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

        #region Situacao
        [HttpGet]
        public PartialViewResult GridSituacao()
        {
            return PartialView("Situacao/Partials/_GridView", new SituacaoSelect().Get());
        }

        [HttpPost]
        public IActionResult EdtSituacao(int id, bool insCadAdv = false)
        {
            var model = new SituacaoModel();
            ViewBag.InsCadAdv = insCadAdv;

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
            if (!ModelState.IsValid) return Json(NegativeReturn);

            return Json(new SituacaoCore().Save(model, UserId));
        }

        [HttpPost]
        public IActionResult GetSituacao(int idAdv)
        {
            return Json(new SituacaoSelect().SituacaoAdvogado(idAdv));
        }
        #endregion

        #region AreaAtuacao
        [HttpGet]
        public PartialViewResult GridAreaAtuacao()
        {
            return PartialView("AreaAtuacao/Partials/_GridView", new AreaAtuacaoSelect().Get());
        }

        [HttpPost]
        public IActionResult EdtAreaAtuacao(int id, bool insCadAdv = false)
        {
            var model = new AreaAtuacaoModel();
            ViewBag.InsCadAdv = insCadAdv;

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
            if (!ModelState.IsValid) return Json(NegativeReturn);

            return Json(new AreaAtuacaoCore().Save(model, UserId));
        }

        [HttpPost]
        public IActionResult GetAreaAtuacao(int idAdv)
        {
            return Json(new AreaAtuacaoSelect().AreaAtuacaoAdvogado(idAdv));
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
            if (!ModelState.IsValid) return Json(NegativeReturn);

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
            if (!ModelState.IsValid) return Json(NegativeReturn);

            return Json(new TipoEnderecoCore().Save(model, UserId));
        }
        #endregion

        #region Advogado
        [HttpGet]
        public IActionResult Lawyer(int id)
        {
            var model = new AdvogadoSelect().GetById(id, UserId);

            ViewBag.Estados = new GeoEstadoSelect().Get().ToList();

            if (model.Id != 0)
                ViewBag.Cidades = new GeoCidadeSelect().Get(model.IdGeoEstado).ToList();

            ViewBag.Situacao = new SituacaoSelect().SituacaoAdvogado(model.Id);
            ViewBag.AreaAtuacao = new AreaAtuacaoSelect().AreaAtuacaoAdvogado(model.Id);

            return View("Advogado/Index", model);
        }

        [HttpPost]
        public IActionResult SaveAdvogado(AdvogadoModel model)
        {
            if (!ModelState.IsValid) return Json(NegativeReturn);
            
            return Json(new AdvogadoCore().Save(model, UserId));
        }

        [HttpPost]
        public IActionResult EdtAdvAvatar(int id)
        {
            return PartialView("Advogado/Partials/_ChangeAvatar", new AdvogadoSelect().GetAvatar(id, UserId));
        }

        [HttpPost]
        public IActionResult SaveAdvAvatar(AdvogadoAvatarModel model)
        {
            if (!ModelState.IsValid) return Json(NegativeReturn);

            return Json(new AdvogadoCore().SaveAvatar(model, UserId));
        }

        #region Contatos
        [HttpGet]
        public PartialViewResult GridAdvogadoContato(int idAdvogado)
        {
            return PartialView("Advogado/Contato/_GridView", new AdvogadoContatoSelect().GetGrid(idAdvogado, UserId));
        }

        [HttpPost]
        public IActionResult EdtAdvContato(int id, int idAdv)
        {
            ViewBag.TipoContato = new TipoContatoSelect().Get();
            return PartialView("Advogado/Contato/_EdtPartial", new AdvogadoContatoSelect().Get(id, idAdv, UserId));
        }

        [HttpPost]
        public IActionResult DelAdvContato(int id, int idAdv)
        {
            return PartialView("Advogado/Contato/_DelPartial", new AdvogadoContatoSelect().Get(id, idAdv, UserId));
        }

        [HttpPost]
        public IActionResult SaveAdvContato(AdvogadoContatoModel model)
        {
            if (!ModelState.IsValid) return Json(NegativeReturn);

            return Json(new AdvogadoContatoCore().Save(model, UserId));
        }
        #endregion

        #region Enderecos
        [HttpGet]
        public PartialViewResult GridAdvogadoEndereco(int idAdvogado)
        {
            return PartialView("Advogado/Endereco/_GridView", new AdvogadoEnderecoSelect().GetGrid(idAdvogado, UserId));
        }

        [HttpPost]
        public IActionResult EdtAdvEndereco(int id, int idAdv)
        {
            var model = new AdvogadoEnderecoSelect().GetModel(idAdv, UserId, id) ?? new AdvogadoEnderecoModel() {
                IdAdvogado = idAdv
            };

            var estados = new GeoEstadoSelect().Get().ToList();
            ViewBag.Estados = estados;

            if (model.IdEnd != 0)
                ViewBag.Cidades = new GeoCidadeSelect().Get(model.IdEndGeoEstado).ToList();
            else
                ViewBag.Cidades = new GeoCidadeSelect().Get(estados.Any() ? estados.FirstOrDefault().Id : 0).ToList();

            ViewBag.TipoEndereco = new TipoEnderecoSelect().Get().ToList();

            return PartialView("Advogado/Endereco/_EdtPartial", model);
        }

        [HttpPost]
        public IActionResult DelAdvEndereco(int id, int idAdv)
        {
            return PartialView("Advogado/Endereco/_DelPartial", new AdvogadoEnderecoSelect().GetModel(idAdv, UserId, id));
        }

        [HttpPost]
        public IActionResult SaveAdvEndereco(AdvogadoEnderecoModel model)
        {
            if (!ModelState.IsValid) return Json(NegativeReturn);

            return Json(new AdvogadoEnderecoCore().Save(model, UserId));
        }
        #endregion
        #endregion
    }
}