using Application.IO.Site.Models.Domain;
using Application.IO.Site.Models.Services.Abstractions;
using Application.IO.Site.Models.SystemModels.Situacao;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Application.IO.Site.Services.Business.Select
{
    public class SituacaoSelect : AbstractionContext
    {
        public Situacao GetByName(string nome)
        {
            return db.Situacao.Where(w => w.Nome == nome).FirstOrDefault();
        }

        public Situacao GetById(int id)
        {
            return db.Situacao.AsNoTracking().Where(w => w.Id == id && w.Delete == false).FirstOrDefault();
        }

        public IQueryable<Situacao> Get()
        {
            return db.Situacao.AsNoTracking().Where(w => w.Delete == false).OrderBy(o => o.Nome);
        }

        public List<SituacaoModel> SituacaoAdvogado(int idAdvogado)
        {
            return (from S in db.Situacao.AsNoTracking()
                    join AS in db.AdvogadoSituacao.AsNoTracking() on S.Id equals AS.IdSituacao into LAS
                    from AS in LAS.Where(w => w.IdAdvogado == idAdvogado).DefaultIfEmpty()
                    orderby S.Nome
                    where S.Delete == false
                    select new SituacaoModel()
                    {
                        Id = S.Id,
                        Nome = S.Nome,
                        Selected = AS != null
                    }).ToList();
        }
    }
}
