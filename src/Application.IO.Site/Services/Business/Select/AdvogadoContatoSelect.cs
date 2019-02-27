using Application.IO.Site.Models.Domain;
using Application.IO.Site.Models.Services.Abstractions;
using Application.IO.Site.Models.SystemModels.Advogado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Application.IO.Site.Services.Business.Select
{
    public class AdvogadoContatoSelect : AbstractionContext
    {
        public AdvogadoContato GetByAdvContato(int idAdvogado, int idTipoContato, string contato)
        {
            return db.AdvogadoContato.AsNoTracking().Where(w => w.Contato == contato && w.IdAdvogado == idAdvogado && w.IdTipoContato == idTipoContato && w.Delete == false).FirstOrDefault();
        }

        public IQueryable<AdvogadoContatoModel> GetGrid(int idAdvogado, Guid idUser)
        {
            return from AC in db.AdvogadoContato.AsNoTracking()
                   join TC in db.TipoContato.AsNoTracking() on AC.IdTipoContato equals TC.Id
                   where AC.Delete == false && AC.IdAdvogado == idAdvogado && AC.IdUser == idUser
                   select new AdvogadoContatoModel()
                   {
                       IdTipoContato = AC.IdTipoContato,
                       Contato = AC.Contato,
                       TipoContato = TC.Nome,
                       Delete = AC.Delete,
                       Id = AC.Id,
                       IdAdvogado = AC.IdAdvogado,
                       Date = AC.Date
                   };
        }

        public AdvogadoContatoModel Get(int id, int idAdvogado, Guid idUser)
        {
            var model = (from AC in db.AdvogadoContato.AsNoTracking()
                         join TC in db.TipoContato.AsNoTracking() on AC.IdTipoContato equals TC.Id
                         where AC.Id == id && AC.IdUser == idUser && AC.Delete == false && AC.IdAdvogado == idAdvogado
                         select new AdvogadoContatoModel()
                         {
                             IdTipoContato = AC.IdTipoContato,
                             Contato = AC.Contato,
                             Delete = AC.Delete,
                             Id = AC.Id,
                             IdAdvogado = AC.IdAdvogado,
                             Date = AC.Date,
                             TipoContato = TC.Nome
                         }).FirstOrDefault();

            if (model == null) model = new AdvogadoContatoModel() { IdAdvogado = idAdvogado };

            return model;
        }

        public AdvogadoContato Get(int id, Guid idUser)
        {
            return db.AdvogadoContato.AsNoTracking().Where(w => w.Id == id && w.IdUser == idUser && w.Delete == false).FirstOrDefault();
        }
    }
}
