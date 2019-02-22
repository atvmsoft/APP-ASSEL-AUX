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
        public Guid IdUser { get; private set; }

        [Required]
        public int IdAdvogado { get; private set; }

        [Required]
        public int IdTipoContato { get; private set; }

        [Required]
        public string Contato { get; private set; }

        [Required]
        public DateTime Date { get; private set; }

        [Required]
        public bool Delete { get; private set; }

        public AdvogadoContato(Guid idUser, int idAdvogado, int idTipoContato, string contato)
        {
            if (new AdvogadoSelect().GetById(idAdvogado, idUser) == null) Add(new DomainNotification("AdvogadoContato", $"O advogado não existe, ou você não tem permissão sobre este cadastro."));
            if (new AdvogadoContatoSelect().GetByAdvContato(idAdvogado, idTipoContato, contato) != null) Add(new DomainNotification("AdvogadoContato", $"O Contato \"'{ contato }'\" já existe."));

            IdUser = idUser;
            IdAdvogado = idAdvogado;
            IdTipoContato = idTipoContato;
            Contato = contato;
            Date = DateTime.Now;
        }

        // EF Construtor
        protected AdvogadoContato() { }

        // EF Propriedade de Navegação
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Advogado Advogado { get; set; }
        public virtual TipoContato TipoContato { get; set; }
    }
}
