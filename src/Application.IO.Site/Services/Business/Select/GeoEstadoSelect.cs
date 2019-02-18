using Application.IO.Site.Models.Domain;
using Application.IO.Site.Models.Services.Abstractions;
using System.Linq;

namespace Application.IO.Site.Services.Business.Select
{
    public class GeoEstadoSelect : AbstractionContext
    {
        public GeoEstado GetByName(string nome)
        {
            return db.GeoEstado.Where(w => w.Nome == nome).FirstOrDefault();
        }

        public GeoEstado GetByInitials(string sigla)
        {
            return db.GeoEstado.Where(w => w.Sigla == sigla).FirstOrDefault();
        }
    }
}
