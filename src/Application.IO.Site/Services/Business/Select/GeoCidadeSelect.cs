using Application.IO.Site.Models.Domain;
using Application.IO.Site.Models.Services.Abstractions;
using System.Linq;

namespace Application.IO.Site.Services.Business.Select
{
    public class GeoCidadeSelect : AbstractionContext
    {
        public GeoCidade GetByNameEstate(string nome, int idGeoEstado)
        {
            return db.GeoCidade.Where(w => w.Nome == nome && w.IdGeoEstado == idGeoEstado).FirstOrDefault();
        }
    }
}
