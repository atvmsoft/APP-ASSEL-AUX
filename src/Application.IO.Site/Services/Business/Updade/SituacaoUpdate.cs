using Application.IO.Site.Models.Services.Abstractions;
using Application.IO.Site.Models.Source;
using Application.IO.Site.Models.SystemModels.Situacao;
using Application.IO.Site.Services.Business.Select;
using Microsoft.EntityFrameworkCore;
using System;

namespace Application.IO.Site.Services.Business.Updade
{
    public class SituacaoUpdate : AbstractionContext
    {
        public ReturnAction Save(SituacaoModel model, Guid id)
        {
            ReturnAction retorno = new ReturnAction();

            var sel = new SituacaoSelect();

            var area = sel.GetById(model.Id);
            if (area != null)
            {
                var validations = sel.GetByName(model.Nome);
                if (validations != null && validations.Id != model.Id)
                    retorno.Mensagens.Add("Nome ja cadastrado na base");
            }
            else
                retorno.Mensagens.Add("Situacao não encontrada");

            if (retorno.Valido)
            {
                area.ChangeEntity(model.Nome, model.Delete);
                db.Entry(area).State = EntityState.Modified;
                db.SaveChanges();
            }

            return retorno;
        }
    }
}
