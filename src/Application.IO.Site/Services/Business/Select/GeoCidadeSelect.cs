using Application.IO.Site.Models.Domain;
using Application.IO.Site.Models.Services.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.IO.Site.Services.Business.Select
{
    public class GeoCidadeSelect : AbstractionContext
    {
        public GeoCidade GetByNameEstate(string nome, int idGeoEstado)
        {
            return db.GeoCidade.AsNoTracking().Where(w => w.Nome == nome && w.IdGeoEstado == idGeoEstado).FirstOrDefault();
        }

        public IQueryable<GeoCidade> Get(int idGeoEstado)
        {
            if (idGeoEstado == 0)
                return db.GeoCidade.AsNoTracking();
            else
                return db.GeoCidade.AsNoTracking().Where(w => w.IdGeoEstado == idGeoEstado);
        }

        public IQueryable<GeoCidade> GetById(int idGeoCidade)
        {
                return db.GeoCidade.AsNoTracking().Where(w => w.Id == idGeoCidade);
        }
    }
}
