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
        public Guid IdUser { get; private set; }

        [Required]
        public string Nome { get; private set; }

        [Required]
        public DateTime Date { get; private set; }

        [Required]
        public bool Delete { get; private set; }

        public TipoEndereco(Guid idUser, string nome)
        {
            if (new TipoEnderecoSelect().GetByName(nome.Trim()) != null) Add(new DomainNotification("TipoEndereco", $"O Tipo de Endereço \"'{ nome.Trim() }'\" já existe."));

            IdUser = idUser;
            Date = DateTime.Now;
            Nome = nome.Trim().ToUpper();
        }

        public void ChangeEntity(string nome, bool delte)
        {
            Date = DateTime.Now;
            Nome = nome.Trim().ToUpper();
            Delete = delte;
        }

        // EF Construtor
        protected TipoEndereco() { }

        // EF Propriedade de Navegação
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<AdvogadoEndereco> AdvogadoEndereco { get; set; }
    }
}
