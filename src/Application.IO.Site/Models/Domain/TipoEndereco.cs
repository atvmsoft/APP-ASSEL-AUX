using Application.IO.Site.Data;
using Application.IO.Site.Models.Source;
using Application.IO.Site.Models.Source.Notifications;
using Application.IO.Site.Services.Business.Select;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.IO.Site.Models.Domain
{
    public class TipoEndereco : Entity
    {
        [Required]
        public Guid IdInsertUser { get; private set; }

        [Required]
        public string Nome { get; private set; }

        [Required]
        public DateTime DateInsert { get; private set; }

        public TipoEndereco(Guid idInsertUser, string nome)
        {
            if (new TipoEnderecoSelect().GetByName(nome) != null) Add(new DomainNotification("TipoEndereco", $"O Tipo de Endereço \"'{ nome }'\" já existe."));

            IdInsertUser = idInsertUser;
            DateInsert = DateTime.Now;
            Nome = nome;
        }

        // EF Construtor
        protected TipoEndereco() { }

        // EF Propriedade de Navegação
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<AdvogadoEndereco> AdvogadoEndereco { get; set; }
    }
}
