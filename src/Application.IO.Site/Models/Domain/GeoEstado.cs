using Application.IO.Site.Models.Source;
using Application.IO.Site.Models.Source.Notifications;
using Application.IO.Site.Services.Business.Select;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.IO.Site.Models.Domain
{
    public class GeoEstado : Entity
    {
        [Required]
        public string Nome { get; private set; }

        [Required]
        public string Sigla { get; private set; }

        public GeoEstado(string nome, string sigla)
        {
            if (new GeoEstadoSelect().GetByName(nome.Trim()) != null) Add(new DomainNotification("Estado", $"O Estado (Nome) \"'{ nome.Trim() }'\" já existe."));
            if (new GeoEstadoSelect().GetByInitials(sigla.Trim()) != null) Add(new DomainNotification("Estado", $"O Estado (Sigla) \"'{ sigla.Trim() }'\" já existe."));

            Nome = nome.Trim();
            Sigla = sigla.Trim();
        }

        // EF Construtor
        protected GeoEstado() { }

        public virtual ICollection<GeoCidade> GeoCidade { get; set; }
    }
}
