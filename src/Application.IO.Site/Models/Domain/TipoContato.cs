using Application.IO.Site.Models.Source;
using Application.IO.Site.Models.Source.Notifications;
using Application.IO.Site.Services.Business.Select;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.IO.Site.Models.Domain
{
    public class TipoContato : Entity
    {
        [Required]
        public Guid IdUser { get; private set; }

        [Required]
        public string Nome { get; private set; }

        [Required]
        public DateTime Date { get; private set; }

        [Required]
        public bool Delete { get; private set; }

        public TipoContato(Guid idUser, string nome)
        {
            if (new TipoContatoSelect().GetByName(nome) != null) Add(new DomainNotification("TipoContato", $"O Tipo de Contato \"'{ nome }'\" já existe."));

            IdUser = idUser;
            Date = DateTime.Now;
            Nome = nome.ToUpper();
        }

        public void ChangeEntity(string nome, bool delte)
        {
            Date = DateTime.Now;
            Nome = nome.ToUpper();
            Delete = delte;
        }

        // EF Construtor
        protected TipoContato() { }

        // EF Propriedade de Navegação
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<AdvogadoContato> AdvogadoContato { get; set; }
    }
}
