using Application.IO.Site.Data;
using Application.IO.Site.Models.Source;
using Application.IO.Site.Models.Source.Notifications;
using Application.IO.Site.Services.Business.Select;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.IO.Site.Models.Domain
{
    public class AreaAtuacao : Entity
    {
        [Required]
        public Guid IdInsertUser { get; private set; }

        [Required]
        public string Nome { get; private set; }

        [Required]
        public DateTime DateInsert { get; private set; }

        [Required]
        public bool LogicalDelete { get; private set; }

        public AreaAtuacao(Guid idInsertUser, string nome)
        {
            if (new AreaAtuacaoSelect().GetByName(nome) != null) Add(new DomainNotification("Area", $"A Área de Atuação \"'{ nome.ToUpper() }'\" já existe."));

            IdInsertUser = idInsertUser;
            DateInsert = DateTime.Now;
            Nome = nome.ToUpper();
            LogicalDelete = false;
        }

        public void ChangeEntity(string nome, bool logicalDelte)
        {
            DateInsert = DateTime.Now;
            Nome = nome.ToUpper();
            LogicalDelete = logicalDelte;
        }

        // EF Construtor
        protected AreaAtuacao() { }

        // EF Propriedade de Navegação
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<AdvogadoAreaAtuacao> AdvogadoAreaAtuacao { get; set; }
    }
}
