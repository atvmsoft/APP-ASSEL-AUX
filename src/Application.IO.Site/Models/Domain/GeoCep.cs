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
            else if (new GeoCepSelect().GetByCod(cod) != null) Add(new DomainNotification("CEP", $"O CEP \"'{ String.Format(@"{0:00\.000\-000}", Convert.ToInt64(cod)) }'\" já existe."));
        }
        #endregion

        public GeoCep(Guid idUser, string codigo, string endereco, string bairro, string cidade, string estado)
        {
            var cod = string.Join("", codigo.ToCharArray().Where(char.IsDigit));

            ValidaCodigoPostal(cod);

            IdUser = idUser;
            Codigo = cod;
            Endereco = tCase.ToTitleCase(endereco);
            Bairro = tCase.ToTitleCase(bairro);
            Cidade = tCase.ToTitleCase(cidade);
            Estado = estado.ToUpper();
            Date = DateTime.Now;
        }

        // EF Construtor
        protected GeoCep() { }

        // EF Propriedade de Navegação
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<AdvogadoEndereco> AdvogadoEndereco { get; set; }
    }
}
