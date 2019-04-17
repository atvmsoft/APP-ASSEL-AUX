using Application.IO.Site.Models.Source;
using Application.IO.Site.Models.Source.Notifications;
using Application.IO.Site.Services.Business.Select;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Application.IO.Site.Models.Domain
{
    public class GeoCep : Entity
    {
        [Required]
        public Guid IdUser { get; private set; }

        [Required]
        public string Codigo { get; private set; }

        [Required]
        public string Endereco { get; private set; }

        public string Bairro { get; private set; }

        [Required]
        public string Cidade { get; private set; }

        [Required]
        public string Estado { get; private set; }

        [Required]
        public DateTime Date { get; private set; }

        #region VALIDATIONS
        protected void ValidaCodigoPostal(string cod)
        {
            if (cod.Length != 8) Add(new DomainNotification("CEP", $"O CEP é inválido."));
            //else if (new GeoCepSelect().GetByCod(cod) != null) Add(new DomainNotification("CEP", $"O CEP \"'{ String.Format(@"{0:00\.000\-000}", Convert.ToInt64(cod)) }'\" já existe."));
        }

        protected Dictionary<string, string> ValidaLocalizacao(int idEndGeoCidade, int idEndGeoEstado)
        {
            var retorno = new Dictionary<string, string>();

            var cidade = new GeoCidadeSelect().GetById(idEndGeoCidade).FirstOrDefault();

            if (cidade == null) Add(new DomainNotification("CEP", "Cidade e Estado não localizados."));
            else {

                if (cidade.IdGeoEstado != idEndGeoEstado) Add(new DomainNotification("CEP", "Cidade e Estado não localizados."));
                else {
                    var estado = new GeoEstadoSelect().GetById(idEndGeoEstado);

                    if (estado == null) Add(new DomainNotification("CEP", "Cidade e Estado não localizados."));
                    else
                    {
                        retorno.Add("estado", estado.Sigla);
                        retorno.Add("cidade", cidade.Nome);
                    }
                }
            }

            return retorno;
        }

        protected void ValidaExistencia(string cod, string endereco, string bairro, string cidade, string estado)
        {
            var obj = new GeoCepSelect().GetByCod(cod).Where(w => w.Endereco.ToUpper() == endereco.ToUpper() && w.Bairro.ToUpper() == bairro.ToUpper() && w.Cidade.ToUpper() == cidade.ToUpper() && w.Estado.ToUpper() == estado.ToUpper());
            if (obj.Count() > 0)
                Add(new DomainNotification("CEP", $"O endereço: { tCase.ToTitleCase(endereco) }{ (string.IsNullOrEmpty(bairro) ? "" : $", { tCase.ToTitleCase(bairro) }") }, { String.Format(@"{0:00\.000\-000}", Convert.ToInt64(cod)) } - { tCase.ToTitleCase(cidade) }/{ estado.ToUpper() }, já existe."));
        }
        #endregion

        public GeoCep(Guid idUser, string codigo, string endereco, string bairro, int idEndGeoCidade, int idEndGeoEstado)
        {
            var cod = string.Join("", codigo.Trim().ToCharArray().Where(char.IsDigit));

            ValidaCodigoPostal(cod);
            var localizacao = ValidaLocalizacao(idEndGeoCidade, idEndGeoEstado);
            ValidaExistencia(cod, endereco.Trim(), bairro.Trim(), localizacao["cidade"], localizacao["estado"]);

            IdUser = idUser;
            Codigo = cod;
            Endereco = tCase.ToTitleCase(endereco.Trim());
            Bairro = tCase.ToTitleCase(bairro.Trim());
            Cidade = localizacao["cidade"];
            Estado = localizacao["estado"];
            Date = DateTime.Now;
        }

        // EF Construtor
        protected GeoCep() { }

        // EF Propriedade de Navegação
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<AdvogadoEndereco> AdvogadoEndereco { get; set; }
    }
}
