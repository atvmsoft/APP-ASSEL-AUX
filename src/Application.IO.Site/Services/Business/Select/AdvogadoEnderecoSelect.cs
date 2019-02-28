using Application.IO.Site.Models.Domain;
using Application.IO.Site.Models.Services.Abstractions;
using Application.IO.Site.Models.SystemModels.Advogado;
using Microsoft.EntityFrameworkCore;
using System;
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

        public AdvogadoEndereco GetById(int id, Guid idUser)
        {
            return db.AdvogadoEndereco.AsNoTracking().Where(w => w.Id == id && w.IdUser == idUser).FirstOrDefault();
        }

        public IQueryable<AdvogadoEnderecoModel> GetGrid(int idAdvogado, Guid idUser)
        {
            var lista = from AE in db.AdvogadoEndereco.AsNoTracking()
                        join TE in db.TipoEndereco.AsNoTracking() on AE.IdTipoEndereco equals TE.Id
                        join GC in db.GeoCep.AsNoTracking() on AE.IdGeoCep equals GC.Id
                        join CD in db.GeoCidade.AsNoTracking() on GC.Cidade equals CD.Nome
                        join GE in db.GeoEstado.AsNoTracking() on GC.Estado equals GE.Sigla
                        where AE.Delete == false && AE.IdAdvogado == idAdvogado && AE.IdUser == idUser
                        select new
                        {
                            AE.IdTipoEndereco,
                            CodCep = GC.Codigo,
                            Logradouro = GC.Endereco,
                            GC.Bairro,
                            AE.Numero,
                            AE.Complemento,
                            TipoEndereco = TE.Nome,
                            AE.IdGeoCep,
                            IdGeoCidade = CD.Id,
                            CD.IdGeoEstado,
                            Cidade = CD.Nome,
                            Estado = GE.Sigla,
                            AE.Id,
                            AE.Date,
                            AE.IdAdvogado
                        };

            if (lista.Any())
                return from L in lista
                       select new AdvogadoEnderecoModel()
                       {
                           IdTipoEndereco = L.IdTipoEndereco,
                           CodCep = String.Format(@"{0:00\.000\-000}", Convert.ToInt64(L.CodCep)),
                           Logradouro = L.Logradouro,
                           Bairro = L.Bairro,
                           Numero = L.Numero,
                           Complemento = L.Complemento,
                           TipoEndereco = L.TipoEndereco,
                           IdGeoCep = L.IdGeoCep,
                           IdEndGeoCidade = L.IdGeoCidade,
                           IdEndGeoEstado = L.IdGeoEstado,
                           Cidade = L.Cidade,
                           Estado = L.Estado,
                           IdEnd = L.Id,
                           Date = L.Date,
                           IdAdvogado = L.IdAdvogado,
                           Endereco = $"{ L.Logradouro }, { L.Numero }{ (string.IsNullOrEmpty(L.Complemento) ? "" : $" ({ L.Complemento })") }{ (string.IsNullOrEmpty(L.Bairro) ? "" : $", { L.Bairro }") }, { String.Format(@"{0:00\.000\-000}", Convert.ToInt64(L.CodCep)) } - { L.Cidade }/{ L.Estado }"
                       };

            return Enumerable.Empty<AdvogadoEnderecoModel>().AsQueryable();
        }

        public AdvogadoEnderecoModel GetModel(int idAdvogado, Guid idUser, int id)
        {
            return GetGrid(idAdvogado, idUser).Where(w => w.IdEnd == id).FirstOrDefault();
        }
    }
}
