using Application.IO.Site.Data;
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
        public Guid IdInsertUser { get; private set; }

        [Required]
        public string Nome { get; private set; }

        public string Formato { get; private set; }

        [Required]
        public DateTime DateInsert { get; private set; }

        public TipoContato(Guid idInsertUser, string nome, string formato)
        {
            if (new TipoContatoSelect().GetByName(nome) != null) Add(new DomainNotification("TipoContato", $"O Tipo de Contato \"'{ nome }'\" já existe."));

            IdInsertUser = idInsertUser;
            DateInsert = DateTime.Now;
            Nome = nome;
            Formato = Formato;
        }

        // EF Construtor
        protected TipoContato() { }

        // EF Propriedade de Navegação
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<AdvogadoContato> AdvogadoContato { get; set; }
    }
}
