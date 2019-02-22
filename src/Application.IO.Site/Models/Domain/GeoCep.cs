using Application.IO.Site.Data;
using Application.IO.Site.Models.Source;
using Application.IO.Site.Models.Source.Notifications;
using Application.IO.Site.Services.Business.Select;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        public GeoCep(Guid idUser, string codigo, string endereco, string bairro, string cidade, string estado)
        {
            if (new GeoCepSelect().GetByCod(codigo) != null) Add(new DomainNotification("CEP", $"O CEP \"'{ codigo }'\" já existe."));

            IdUser = idUser;
            Codigo = codigo;
            Endereco = endereco;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Date = DateTime.Now;
        }

        // EF Construtor
        protected GeoCep() { }

        // EF Propriedade de Navegação
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<AdvogadoEndereco> AdvogadoEndereco { get; set; }
    }
}
