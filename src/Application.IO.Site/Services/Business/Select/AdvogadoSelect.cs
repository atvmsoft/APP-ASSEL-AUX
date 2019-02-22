using Application.IO.Site.Models.Domain;
using Application.IO.Site.Models.Services.Abstractions;
using Application.IO.Site.Models.SystemModels.Advogado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Application.IO.Site.Services.Business.Select
{
    public class AdvogadoSelect : AbstractionContext
    {
        public Advogado GetByNumOrdem(string numOrdem)
        {
            return db.Advogado.Where(w => w.NumOrdem == numOrdem).FirstOrDefault();
        }

        public AdvogadoModel GetById(int id, Guid idUser)
        {
            var retorno = (from A in db.Advogado.AsNoTracking()
                           join C in db.GeoCidade.AsNoTracking() on A.IdGeoCidade equals C.Id
                           where A.Id == id && A.IdUser == idUser
                           select new AdvogadoModel
                           {
                               DateAtualizacao = A.DateAtualizacao,
                               DateInscricaoOAB = A.DateInscricaoOAB,
                               IdGeoEstado = C.IdGeoEstado,
                               IdGeoCidade = A.IdGeoCidade,
                               Nome = A.Nome,
                               NomeMae = A.NomeMae,
                               NomePai = A.NomePai,
                               NumOrdem = A.NumOrdem,
                               Delete = A.Delete,
                               Id = A.Id,
                               Foto = A.Foto
                           }).FirstOrDefault();

            if (retorno == null)
                return new AdvogadoModel();

            return retorno;
        }
    }
}
