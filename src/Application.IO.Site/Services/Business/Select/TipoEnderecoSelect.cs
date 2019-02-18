using Application.IO.Site.Models.Domain;
using Application.IO.Site.Models.Services.Abstractions;
using System.Linq;

namespace Application.IO.Site.Services.Business.Select
{
    public class TipoEnderecoSelect : AbstractionContext
    {
        public TipoEndereco GetByName(string nome)
        {
            return db.TipoEndereco.Where(w => w.Nome == nome).FirstOrDefault();
        }
    }
}
