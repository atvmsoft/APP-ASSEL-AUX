using Application.IO.Site.Models.Services.Abstractions;
using Application.IO.Site.Models.Source;
using Application.IO.Site.Models.SystemModels.Advogado;
using System;

namespace Application.IO.Site.Services.Business.Updade
{
    public class AdvogadoUpdate : AbstractionContext
    {
        public ReturnAction Save(AdvogadoModel model, Guid id)
        {
            ReturnAction retorno = new ReturnAction();

            //var sel = new TipoEnderecoSelect();
            //var area = sel.GetById(model.Id);
            //if (area != null)
            //{
            //    var validations = sel.GetByName(model.Nome);
            //    if (validations != null && validations.Id != model.Id)
            //        retorno.Mensagens.Add("Nome ja cadastrado na base");
            //}
            //else
            //    retorno.Mensagens.Add("Tipo Endereco não encontrada");

            //if (retorno.Valido)
            //{
            //    area.ChangeEntity(model.Nome, model.Delete);
            //    db.Entry(area).State = EntityState.Modified;
            //    db.SaveChanges();
            //}

            return retorno;
        }
    }
}
