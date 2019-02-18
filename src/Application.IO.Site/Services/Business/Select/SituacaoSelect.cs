using Application.IO.Site.Models.Domain;
using Application.IO.Site.Models.Services.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.IO.Site.Services.Business.Select
{
    public class SituacaoSelect : AbstractionContext
    {
        public Situacao GetByName(string nome)
        {
            return db.Situacao.Where(w => w.Nome == nome).FirstOrDefault();
        }

        public Situacao GetById(int id)
        {
            return db.Situacao.AsNoTracking().Where(w => w.Id == id && w.Delete == false).FirstOrDefault();
        }

        public IQueryable<Situacao> Get()
        {
            return db.Situacao.AsNoTracking().Where(w => w.Delete == false).OrderBy(o => o.Nome);
        }
    }
}
