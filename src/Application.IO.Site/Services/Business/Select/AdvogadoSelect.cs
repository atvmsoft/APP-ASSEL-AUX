using Application.IO.Site.Models.Domain;
using Application.IO.Site.Models.Services.Abstractions;
using System.Linq;

namespace Application.IO.Site.Services.Business.Select
{
    public class AdvogadoSelect : AbstractionContext
    {
        public Advogado GetByNumOrdem(string numOrdem)
        {
            return db.Advogado.Where(w => w.NumOrdem == numOrdem).FirstOrDefault();
        }
    }
}
