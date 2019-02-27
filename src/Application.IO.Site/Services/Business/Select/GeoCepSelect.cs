﻿using Application.IO.Site.Models.Domain;
using Application.IO.Site.Models.Services.Abstractions;
using System.Linq;

namespace Application.IO.Site.Services.Business.Select
{
    public class GeoCepSelect : AbstractionContext
    {
        public GeoCep GetByCod(string codigo)
        {
            var cod = string.Join("", codigo.ToCharArray().Where(char.IsDigit));

            return db.GeoCep.Where(w => w.Codigo == cod).FirstOrDefault();
        }
    }
}
