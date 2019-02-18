using Application.IO.Site.Models.Domain;
using Application.IO.Site.Models.Services.Abstractions;
using System.Linq;

namespace Application.IO.Site.Services.Business.Select
{
    public class AdvogadoContatoSelect : AbstractionContext
    {
        public AdvogadoContato GetByAdvContato(int idAdvogado, string contato)
        {
            return db.AdvogadoContato.Where(w => w.Contato == contato && w.IdAdvogado == idAdvogado).FirstOrDefault();
        }
    }
}
