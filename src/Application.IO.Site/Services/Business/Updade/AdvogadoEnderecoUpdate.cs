using Application.IO.Site.Models.Domain;
using Application.IO.Site.Models.Services.Abstractions;
using Application.IO.Site.Models.Source;
using Application.IO.Site.Models.SystemModels.Advogado;
using Application.IO.Site.Services.Business.Select;
using Microsoft.EntityFrameworkCore;
using System;

namespace Application.IO.Site.Services.Business.Updade
{
    public class AdvogadoEnderecoUpdate : AbstractionContext
    {
        public ReturnAction Save(AdvogadoEnderecoModel model, Guid idUser)
        {
            ReturnAction retorno = new ReturnAction();

            var obj = new AdvogadoEnderecoSelect().GetById(model.IdEnd, idUser);
            if (obj == null)
            {
                retorno.Mensagens.Add("Endereço não encontrado");
                return retorno;
            }

            if (!model.Delete && model.IdGeoCep == 0) // SE O CEP NÃO EXISTIR SERÁ CRIADO
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

            obj.ChangeEntity(idUser, model.IdAdvogado, model.IdTipoEndereco, model.IdGeoCep, model.Numero, model.Complemento, model.Delete);

            if (!retorno.Valido) return retorno;

            if (!obj.EhValido())
            {
                foreach (var item in obj.Get) retorno.Mensagens.Add(item.Value);
                return retorno;
            }

            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();

            return retorno;
        }
    }
}
