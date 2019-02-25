using Application.IO.Site.Models.Services.Abstractions;
using System.Linq;

namespace Application.IO.Site.Services.Business.Delete
{
    public class AdvogadoAreaAtuacaoDelete : AbstractionContext
    {
        public void DeleteAll(int idAdvogado)
        {
            db.AdvogadoAreaAtuacao.RemoveRange(db.AdvogadoAreaAtuacao.Where(w => w.IdAdvogado == idAdvogado).ToList());
            db.SaveChanges();
        }
    }
}
