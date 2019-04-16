using Application.IO.Site.Models.Domain;
using Application.IO.Site.Models.Services.Abstractions;
using Application.IO.Site.Models.Source;
using Application.IO.Site.Models.SystemModels.Advogado;
using Microsoft.EntityFrameworkCore;
using System;

namespace Application.IO.Site.Services.Business.Insert
{
    public class AdvogadoEnderecoInsert : AbstractionContext
    {
        public ReturnAction Save(AdvogadoEnderecoModel model, Guid idUser)
        {
            ReturnAction retorno = new ReturnAction();

            if (model.IdGeoCep == 0) // SE O CEP NÃO EXISTIR SERÁ CRIADO
            {
                var cep = new GeoCep(idUser, model.CodCep, model.Logradouro, model.Bairro, model.IdEndGeoCidade, model.IdEndGeoEstado);

                if (!cep.EhValido()) foreach (var item in cep.Get) retorno.Mensagens.Add(item.Value);
                else
                {
                    db.Entry(cep).State = EntityState.Added;
                    db.SaveChanges();

                    model.IdGeoCep = cep.Id;
                }
            }

            if (!retorno.Valido) return retorno;

            var obj = new AdvogadoEndereco(idUser, model.IdAdvogado, model.IdTipoEndereco, model.IdGeoCep, model.Numero, model.Complemento);

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
