using Application.IO.Site.Models.Domain;
using Application.IO.Site.Models.Services.Abstractions;
using Application.IO.Site.Models.SystemModels.AreaAtuacao;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Application.IO.Site.Services.Business.Select
{
    public class AreaAtuacaoSelect : AbstractionContext
    {
        public AreaAtuacao GetByName(string nome)
        {
            return db.AreaAtuacao.AsNoTracking().Where(w => w.Nome == nome && w.Delete == false).FirstOrDefault();
        }

        public AreaAtuacao GetById(int id)
        {
            return db.AreaAtuacao.AsNoTracking().Where(w => w.Id == id && w.Delete == false).FirstOrDefault();
        }

        public IQueryable<AreaAtuacao> Get()
        {
            return db.AreaAtuacao.AsNoTracking().Where(w => w.Delete == false).OrderBy(o => o.Nome);
        }

        public List<AreaAtuacaoModel> AreaAtuacaoAdvogado(int idAdvogado)
        {
            return (from AA in db.AreaAtuacao.AsNoTracking()
                    join AAA in db.AdvogadoAreaAtuacao.AsNoTracking() on AA.Id equals AAA.IdAreaAtuacao into AAS
                    from AAA in AAS.Where(w => w.IdAdvogado == idAdvogado).DefaultIfEmpty()
                    orderby AA.Nome
                    where AA.Delete == false
                    select new AreaAtuacaoModel()
                    {
                        Id = AA.Id,
                        Nome = AA.Nome,
                        Selected = AAA != null
                    }).ToList();
        }
    }
}
