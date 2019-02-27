using Application.IO.Site.Models.Domain;
using Application.IO.Site.Models.Services.Abstractions;
using Application.IO.Site.Models.Source;
using Application.IO.Site.Models.SystemModels.Advogado;
using Microsoft.EntityFrameworkCore;
using System;

namespace Application.IO.Site.Services.Business.Insert
{
    public class AdvogadoContatoInsert : AbstractionContext
    {
        public ReturnAction Save(AdvogadoContatoModel model, Guid idUser)
        {
            ReturnAction retorno = new ReturnAction();

            var obj = new AdvogadoContato(idUser, model.IdAdvogado, model.IdTipoContato, model.Contato);

            if (!obj.EhValido())
            {
                foreach (var item in obj.Get) retorno.Mensagens.Add(item.Value);
                return retorno;
            }

            db.Entry(obj).State = EntityState.Added;
            db.SaveChanges();

            return retorno;
        }
    }
}
