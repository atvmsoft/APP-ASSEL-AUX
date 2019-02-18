using Application.IO.Site.Models.Domain;
using Application.IO.Site.Models.Services.Abstractions;
using System.Linq;

namespace Application.IO.Site.Services.Business.Select
{
    public class TipoContatoSelect : AbstractionContext
    {
        public TipoContato GetByName(string nome)
        {
            return db.TipoContato.Where(w => w.Nome == nome).FirstOrDefault();
        }
    }
}
