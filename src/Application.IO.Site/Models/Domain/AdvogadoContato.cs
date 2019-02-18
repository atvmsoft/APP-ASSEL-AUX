using Application.IO.Site.Data;
using Application.IO.Site.Models.Source;
using Application.IO.Site.Models.Source.Notifications;
using Application.IO.Site.Services.Business.Select;
using System;
using System.ComponentModel.DataAnnotations;

namespace Application.IO.Site.Models.Domain
{
    public class AdvogadoContato : Entity
    {
        [Required]
        public Guid IdInsertUser { get; private set; }

        [Required]
        public int IdAdvogado { get; private set; }

        [Required]
        public int IdTipoContato { get; private set; }

        [Required]
        public string Contato { get; private set; }

        [Required]
        public DateTime DateInsert { get; private set; }

        public AdvogadoContato(Guid idInsertUser, int idAdvogado, int idTipoContato, string contato)
        {
            if (new AdvogadoContatoSelect().GetByAdvContato(idAdvogado,contato) != null) Add(new DomainNotification("AdvogadoContato", $"O Contato \"'{ contato }'\" já existe."));

            IdInsertUser = idInsertUser;
            IdAdvogado = idAdvogado;
            IdTipoContato = idTipoContato;
            Contato = contato;
            DateInsert = DateTime.Now;
        }

        // EF Construtor
        protected AdvogadoContato() { }

        // EF Propriedade de Navegação
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Advogado Advogado { get; set; }
        public virtual TipoContato TipoContato { get; set; }
    }
}
