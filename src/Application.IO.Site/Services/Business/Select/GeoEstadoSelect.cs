using Application.IO.Site.Models.Domain;
using Application.IO.Site.Models.Services.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.IO.Site.Services.Business.Select
{
    public class GeoEstadoSelect : AbstractionContext
    {
        public GeoEstado GetByName(string nome)
        {
            return db.GeoEstado.AsNoTracking().Where(w => w.Nome == nome).FirstOrDefault();
        }

        public GeoEstado GetByInitials(string sigla)
        {
            return db.GeoEstado.AsNoTracking().Where(w => w.Sigla == sigla).FirstOrDefault();
        }

        public GeoEstado GetById(int id)
        {
            return Get().Where(w => w.Id == id).FirstOrDefault();
        }

        public IQueryable<GeoEstado> Get()
        {
            return db.GeoEstado.AsNoTracking();
        }
    }
}
