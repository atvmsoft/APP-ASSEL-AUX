using Application.IO.Site.Models.Domain;
using Application.IO.Site.Models.Services.Abstractions;
using System.Linq;

namespace Application.IO.Site.Services.Business.Select
{
    public class AdvogadoSituacaoSelect : AbstractionContext
    {
        public AdvogadoSituacao GetByAdvSituacao(int idSituacao, int idAdvogado)
        {
            return db.AdvogadoSituacao.Where(w => w.IdSituacao == idSituacao && w.IdAdvogado == idAdvogado).FirstOrDefault();
        }
    }
}
