using Application.IO.Site.Models.Services.Abstractions;
using Application.IO.Site.Models.Source;
using Application.IO.Site.Models.SystemModels.TipoContato;
using Application.IO.Site.Services.Business.Select;
using Microsoft.EntityFrameworkCore;
using System;

namespace Application.IO.Site.Services.Business.Updade
{
    public class TipoContatoUpdate : AbstractionContext
    {
        public ReturnAction Save(TipoContatoModel model, Guid id)
        {
            ReturnAction retorno = new ReturnAction();

            var sel = new TipoContatoSelect();

            var area = sel.GetById(model.Id);
            if (area != null)
            {
                var validations = sel.GetByName(model.Nome);
                if (validations != null && validations.Id != model.Id)
                    retorno.Mensagens.Add("Nome ja cadastrado na base");
            }
            else
                retorno.Mensagens.Add("Tipo Contato não encontrada");

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
