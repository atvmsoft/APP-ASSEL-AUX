using Application.IO.Site.Models.Domain;
using Application.IO.Site.Models.Services.Abstractions;
using System.Linq;

namespace Application.IO.Site.Services.Business.Select
{
    public class AdvogadoEnderecoSelect : AbstractionContext
    {
        public AdvogadoEndereco GetByAdvEndreco(int idAdvogado, int idTipoEndereco, int idGeoCep, string numero, string complemento)
        {
            return db.AdvogadoEndereco.Where(w => w.IdAdvogado == idAdvogado && w.IdTipoEndereco == idTipoEndereco && w.IdGeoCep == idGeoCep &&
                w.Numero == numero && w.Complemento == complemento).FirstOrDefault();
        }
    }
}
