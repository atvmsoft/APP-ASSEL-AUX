using Application.IO.Site.Interfaces;
using Application.IO.Site.Models.Domain;
using Application.IO.Site.Models.Services.Abstractions;
using System.Linq;

namespace Application.IO.Site.Services.Business.Select
{
    public class AdvogadoAreaAtuacaoSelect : AbstractionContext
    {
        public AdvogadoAreaAtuacao GetByAdvArea(int idAreaAtuacao, int idAdvogado)
        {
            return db.AdvogadoAreaAtuacao.Where(w => w.IdAreaAtuacao == idAreaAtuacao && w.IdAdvogado == idAdvogado).FirstOrDefault();
        }
    }
}
