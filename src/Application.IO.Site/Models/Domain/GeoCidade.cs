using Application.IO.Site.Models.Source;
using Application.IO.Site.Models.Source.Notifications;
using Application.IO.Site.Services.Business.Select;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.IO.Site.Models.Domain
{
    public class GeoCidade : Entity
    {
        [Required]
        public int IdGeoEstado { get; private set; }

        [Required]
        public string Nome { get; private set; }

        public GeoCidade(int idGeoEstado, string nome)
        {
            if (new GeoCidadeSelect().GetByNameEstate(nome, idGeoEstado) != null) Add(new DomainNotification("Cidade", $"A Cidade \"'{ nome }'\" já existe."));

            Nome = nome;
            IdGeoEstado = idGeoEstado;
        }

        // EF Construtor
        protected GeoCidade() { }

        // EF Propriedade de Navegação
        public virtual GeoEstado GeoEstado { get; set; }
        public virtual ICollection<Advogado> Advogado { get; set; }
    }
}
