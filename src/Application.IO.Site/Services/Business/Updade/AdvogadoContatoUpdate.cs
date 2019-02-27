using Application.IO.Site.Models.Services.Abstractions;
using Application.IO.Site.Models.Source;
using Application.IO.Site.Models.SystemModels.Advogado;
using Application.IO.Site.Services.Business.Select;
using Microsoft.EntityFrameworkCore;
using System;

namespace Application.IO.Site.Services.Business.Updade
{
    public class AdvogadoContatoUpdate : AbstractionContext
    {
        public ReturnAction Save(AdvogadoContatoModel model, Guid idUser)
        {
            ReturnAction retorno = new ReturnAction();

            var obj = new AdvogadoContatoSelect().Get(model.Id, idUser);
            if (obj == null) retorno.Mensagens.Add("Contato não encontrado");

            if (!retorno.Valido) return retorno;

            obj.ChangeEntity(idUser, model.IdAdvogado, model.IdTipoContato, model.Contato, model.Delete);

            if (!obj.EhValido()) foreach (var item in obj.Get) retorno.Mensagens.Add(item.Value);

            if (!retorno.Valido) return retorno;

            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();

            return retorno;
        }
    }
}
