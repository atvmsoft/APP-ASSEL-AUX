﻿using Application.IO.Site.Models.Domain;
using Application.IO.Site.Models.Services.Abstractions;
using Microsoft.EntityFrameworkCore;
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
    }
}
