using Application.IO.Site.Data;
using Application.IO.Site.Models.Source;
using Application.IO.Site.Models.Source.Notifications;
using Application.IO.Site.Services.Business.Select;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.IO.Site.Models.Domain
{
    public class Situacao : Entity
    {
        [Required]
        public Guid IdInsertUser { get; private set; }

        [Required]
        public string Nome { get; private set; }

        [Required]
        public DateTime DateInsert { get; private set; }

        public Situacao(Guid idInsertUser, string nome)
        {
            if (new SituacaoSelect().GetByName(nome) != null) Add(new DomainNotification("Situacao", $"A Situação \"'{ nome }'\" já existe."));

            IdInsertUser = idInsertUser;
            DateInsert = DateTime.Now;
            Nome = nome;
        }

        // EF Construtor
        protected Situacao() { }

        // EF Propriedade de Navegação
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<AdvogadoSituacao> AdvogadoSituacao { get; set; }
    }
}
