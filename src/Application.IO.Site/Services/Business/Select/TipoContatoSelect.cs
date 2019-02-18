using Application.IO.Site.Models.Domain;
using Application.IO.Site.Models.Services.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.IO.Site.Services.Business.Select
{
    public class TipoContatoSelect : AbstractionContext
    {
        public TipoContato GetByName(string nome)
        {
            return db.TipoContato.Where(w => w.Nome == nome).FirstOrDefault();
        }

        public TipoContato GetById(int id)
        {
            return db.TipoContato.AsNoTracking().Where(w => w.Id == id && w.Delete == false).FirstOrDefault();
        }

        public IQueryable<TipoContato> Get()
        {
            return db.TipoContato.AsNoTracking().Where(w => w.Delete == false).OrderBy(o => o.Nome);
        }
    }
}
