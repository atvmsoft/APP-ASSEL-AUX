using Application.IO.Site.Models.Domain;
using Application.IO.Site.Models.Services.Abstractions;
using Application.IO.Site.Models.SystemModels.Advogado;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.IO.Site.Services.Business.Select
{
    public class AdvogadoContatoSelect : AbstractionContext
    {
        public AdvogadoContato GetByAdvContato(int idAdvogado, int idTipoContato, string contato)
        {
            return db.AdvogadoContato.AsNoTracking().Where(w => w.Contato == contato && w.IdAdvogado == idAdvogado && w.IdTipoContato == idTipoContato && w.Delete == false).FirstOrDefault();
        }

        public IQueryable<AdvogadoContatoModel> GetGrid(int idAdvogado)
        {
            return from AC in db.AdvogadoContato.AsNoTracking()
                   join TC in db.TipoContato.AsNoTracking() on AC.IdTipoContato equals TC.Id
                   where AC.Delete == false && AC.IdAdvogado == idAdvogado
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
    }
}
