using Application.IO.Site.Data;
using Application.IO.Site.Models.Source;
using Application.IO.Site.Models.Source.Notifications;
using Application.IO.Site.Services.Business.Select;
using System;
using System.ComponentModel.DataAnnotations;

namespace Application.IO.Site.Models.Domain
{
    public class AdvogadoEndereco : Entity
    {
        [Required]
        public Guid IdUser { get; private set; }

        [Required]
        public int IdAdvogado { get; private set; }

        [Required]
        public int IdTipoEndereco { get; private set; }

        [Required]
        public int IdGeoCep { get; private set; }

        [Required]
        public string Numero { get; private set; }

        public string Complemento { get; private set; }

        [Required]
        public bool Delete { get; private set; }

        [Required]
        public DateTime Date { get; private set; }

        public AdvogadoEndereco(Guid idUser, int idAdvogado, int idTipoEndereco, int idGeoCep, string numero, string complemento)
        {
            if (new AdvogadoEnderecoSelect().GetByAdvEndreco(idAdvogado, idTipoEndereco,idGeoCep, numero, complemento) != null) Add(new DomainNotification("AdvogadoEndereco", $"Este endereço já existe."));

            IdUser = idUser;
            IdAdvogado = idAdvogado;
            IdTipoEndereco = idTipoEndereco;
            IdGeoCep = idGeoCep;
            Numero = numero;
            Complemento = complemento;
            Date = DateTime.Now;
        }

        // EF Construtor
        protected AdvogadoEndereco() { }

        // EF Propriedade de Navegação
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Advogado Advogado { get; set; }
        public virtual TipoEndereco TipoEndereco { get; set; }
        public virtual GeoCep GeoCep { get; set; }
    }
}
