using Application.IO.Site.Models.Services.Abstractions;
using System.Linq;

namespace Application.IO.Site.Services.Business.Delete
{
    public class AdvogadoSituacaoDelete : AbstractionContext
    {
        public void DeleteAll(int idAdvogado)
        {
            db.AdvogadoSituacao.RemoveRange(db.AdvogadoSituacao.Where(w => w.IdAdvogado == idAdvogado).ToList());
            db.SaveChanges();
        }
    }
}
