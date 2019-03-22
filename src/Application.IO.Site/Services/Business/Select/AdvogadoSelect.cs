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
        public Advogado GetByNumOrdem(string numOrdem, int idGeoCidade)
        {
            var obj = db.Advogado.AsNoTracking().Where(w => w.NumOrdem == numOrdem).ToList();
            //os numeros da OAB podem ser repetidos desde que estejam em estados diferentes
            if (obj.Any())
            {
                var estado = (from A in obj
                              join C in db.GeoCidade.AsNoTracking() on A.IdGeoCidade equals C.Id
                              where A.NumOrdem == numOrdem
                              select C.IdGeoEstado).FirstOrDefault();

                var cidade = new GeoCidadeSelect().GetById(idGeoCidade);
                if (cidade != null && cidade.FirstOrDefault().IdGeoEstado != estado) return null;
            }

            return obj.FirstOrDefault();
        }

        public AdvogadoModel GetById(int id, Guid idUser)
        {
            var retorno = (from A in db.Advogado.AsNoTracking()
                           join C in db.GeoCidade.AsNoTracking() on A.IdGeoCidade equals C.Id
                           join E in db.GeoEstado.AsNoTracking() on C.IdGeoEstado equals E.Id
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
                               EstadoSigla = E.Sigla,
                               Id = A.Id,
                               Foto = A.Foto
                           }).FirstOrDefault();

            if (retorno == null)
                return new AdvogadoModel();

            return retorno;
        }

        public Advogado Get(int id, Guid idUser)
        {
            return db.Advogado.Where(w => w.Id == id && w.IdUser == idUser).FirstOrDefault();
        }

        public AdvogadoAvatarModel GetAvatar(int id, Guid idUser)
        {
            var obj = Get(id, idUser);

            if (obj != null)
                return new AdvogadoAvatarModel()
                {
                    Nome = obj.Nome,
                    Id = obj.Id,
                    Foto = obj.Foto ?? "icon-user.png"
                };

            return null;
        }

        public IQueryable<AdvogadoModel> GetGrid(Guid idUser)
        {
            return from A in db.Advogado.AsNoTracking()
                   join C in db.GeoCidade.AsNoTracking() on A.IdGeoCidade equals C.Id
                   join E in db.GeoEstado.AsNoTracking() on C.IdGeoEstado equals E.Id
                   where A.Delete == false && A.IdUser == idUser
                   select new AdvogadoModel()
                   {
                       Id = A.Id,
                       Delete = A.Delete,
                       Nome = A.Nome,
                       NumOrdem = $"{ E.Sigla }/{ A.NumOrdem }",
                       Date = A.Date
                   };
        }
    }
}
