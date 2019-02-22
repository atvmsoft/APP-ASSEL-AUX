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
        public Guid IdUser { get; private set; }

        [Required]
        public string Nome { get; private set; }

        [Required]
        public DateTime Date { get; private set; }

        [Required]
        public bool Delete { get; private set; }

        public AreaAtuacao(Guid idUser, string nome)
        {
            if (new AreaAtuacaoSelect().GetByName(nome) != null) Add(new DomainNotification("Area", $"A Área de Atuação \"'{ nome.ToUpper() }'\" já existe."));

            IdUser = idUser;
            Date = DateTime.Now;
            Nome = nome.ToUpper();
            Delete = false;
        }

        public void ChangeEntity(string nome, bool delete)
        {
            Date = DateTime.Now;
            Nome = nome.ToUpper();
            Delete = delete;
        }

        // EF Construtor
        protected AreaAtuacao() { }

        // EF Propriedade de Navegação
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<AdvogadoAreaAtuacao> AdvogadoAreaAtuacao { get; set; }
    }
}
