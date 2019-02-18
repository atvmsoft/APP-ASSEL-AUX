using Application.IO.Site.Models.Domain;
using Application.IO.Site.Models.Services.Abstractions;
using Application.IO.Site.Models.Source;
using Application.IO.Site.Models.SystemModels.TipoContato;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Application.IO.Site.Services.Business.Insert
{
    public class TipoContatoInsert : AbstractionContext
    {
        public ReturnAction Save(TipoContatoModel model, Guid id)
        {
            ReturnAction retorno = new ReturnAction();

            var sit = db.TipoContato.AsNoTracking().Where(w => w.Id == model.Id);
            if (sit.Any())
                retorno.Mensagens.Add("O indexador do item já está cadastrado.");
            else
            {
                var obj = new TipoContato(id, model.Nome);

                if (!obj.EhValido())
                    foreach (var item in obj.Get)
                        retorno.Mensagens.Add(item.Value);
                else
                {
                    db.Entry(obj).State = EntityState.Added;
                    db.SaveChanges();
                }
            }

            return retorno;
        }
    }
}
