using Application.IO.Site.Models.Domain;
using Application.IO.Site.Models.Services.Abstractions;
using System.Linq;

namespace Application.IO.Site.Services.Business.Select
{
    public class SituacaoSelect : AbstractionContext
    {
        public Situacao GetByName(string nome)
        {
            return db.Situacao.Where(w => w.Nome == nome).FirstOrDefault();
        }
    }
}
