using Application.IO.Site.Models.Domain;
using Application.IO.Site.Models.Services.Abstractions;
using Application.IO.Site.Models.SystemModels.GeoCep;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Application.IO.Site.Services.Business.Select
{
    public class GeoCepSelect : AbstractionContext
    {
        public List<GeoCepModel> GetByCod(string codigo)
        {
            var cod = string.Join("", codigo.ToCharArray().Where(char.IsDigit));

            return (from CP in db.GeoCep.AsNoTracking()
                    join E in db.GeoEstado.AsNoTracking() on CP.Estado equals E.Sigla
                    join C in db.GeoCidade.AsNoTracking() on new { cdd = CP.Cidade, id = E.Id } equals new { cdd = C.Nome, id = C.IdGeoEstado }
                    where CP.Codigo == cod
                    orderby CP.Bairro, CP.Endereco
                    select new GeoCepModel()
                    {
                        Id = CP.Id,
                        IdGeoCidade = C.Id,
                        IdGeoEstado = C.IdGeoEstado,
                        Codigo = CP.Codigo,
                        Endereco = CP.Endereco,
                        Bairro = CP.Bairro,
                        Cidade = CP.Cidade,
                        Estado = CP.Estado
                    }).ToList();
        }

        public GeoCep GetById(int idGeoCep)
        {
            return db.GeoCep.AsNoTracking().Where(w => w.Id == idGeoCep).FirstOrDefault();
        }
    }
}
