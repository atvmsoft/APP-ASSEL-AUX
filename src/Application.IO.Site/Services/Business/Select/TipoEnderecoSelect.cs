using Application.IO.Site.Models.Domain;
using Application.IO.Site.Models.Services.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.IO.Site.Services.Business.Select
{
    public class TipoEnderecoSelect : AbstractionContext
    {
        public TipoEndereco GetByName(string nome)
        {
            return db.TipoEndereco.Where(w => w.Nome == nome).FirstOrDefault();
        }

        public TipoEndereco GetById(int id)
        {
            return db.TipoEndereco.AsNoTracking().Where(w => w.Id == id && w.Delete == false).FirstOrDefault();
        }

        public IQueryable<TipoEndereco> Get()
        {
            return db.TipoEndereco.AsNoTracking().Where(w => w.Delete == false).OrderBy(o => o.Nome);
        }
    }
}
