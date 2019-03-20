using Application.IO.Site.Models.Domain;
using Application.IO.Site.Models.Services.Abstractions;
using Application.IO.Site.Models.Source;
using Application.IO.Site.Models.SystemModels.Advogado;
using Application.IO.Site.Services.Business.Select;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace Application.IO.Site.Services.Business.Insert
{
    public class AdvogadoInsert : AbstractionContext
    {
        public ReturnAction Save(AdvogadoModel model, Guid id)
        {
            ReturnAction retorno = new ReturnAction();

            int idSituacao = 0, idAreaAtuacao = 0;
            if (string.IsNullOrEmpty(model.ListSituacao)) retorno.Mensagens.Add($"A Situação não foi informada");
            else
                foreach (var item in model.ListSituacao.Split("-"))
                {
                    if (!int.TryParse(item, out idSituacao) || new SituacaoSelect().GetById(idSituacao) == null)
                    {
                        retorno.Mensagens.Add($"Situação não encontrada");
                        break;
                    }
                }

            if (!string.IsNullOrEmpty(model.ListAreaAtuacao)) //retorno.Mensagens.Add($"A Área de Atuação não foi informada");
                foreach (var item in model.ListAreaAtuacao.Split("-"))
                {
                    if (!int.TryParse(item, out idAreaAtuacao) || new AreaAtuacaoSelect().GetById(idAreaAtuacao) == null)
                    {
                        retorno.Mensagens.Add($"Área de Atuação não encontrada");
                        break;
                    }
                }

            var obj = new Advogado(id, model.IdGeoCidade, model.Nome, model.NumOrdem, $"{ Guid.NewGuid().ToString() }{ model.IFoto.FileName.Substring(model.IFoto.FileName.LastIndexOf(".")) }", model.NomePai, model.NomeMae, model.DateInscricaoOAB, model.DateAtualizacao);
            foreach (var item in obj.Get) retorno.Mensagens.Add(item.Value);

            if (!retorno.Valido) return retorno;

            db.Entry(obj).State = EntityState.Added;
            db.SaveChanges();

            if (!Directory.Exists($"{ Directory.GetCurrentDirectory() }\\wwwroot\\images\\Avatar")) Directory.CreateDirectory($"{ Directory.GetCurrentDirectory() }\\wwwroot\\images\\Avatar");

            var directoryRoot = $"{ Directory.GetCurrentDirectory() }\\wwwroot\\images\\Avatar";
            var memoryStream = new MemoryStream();
            model.IFoto.CopyToAsync(memoryStream);

            FileStream file = new FileStream($"{ directoryRoot }\\{ obj.Foto }", FileMode.Create, FileAccess.Write);
            memoryStream.WriteTo(file);
            file.Close();
            memoryStream.Close();

            foreach (var item in model.ListSituacao.Split("-"))
            {
                var sit = new AdvogadoSituacao(id, obj.Id, Convert.ToInt32(item));
                if (sit.EhValido())
                    db.Entry(sit).State = EntityState.Added;
            }

            foreach (var item in model.ListAreaAtuacao.Split("-"))
            {
                var sit = new AdvogadoAreaAtuacao(id, obj.Id, Convert.ToInt32(item));
                if (sit.EhValido())
                    db.Entry(sit).State = EntityState.Added;
            }
            db.SaveChanges();

            retorno.objRetorno = obj.Id;

            return retorno;
        }
    }
}
