using Application.IO.Site.Data;
using Application.IO.Site.Models.Source;
using Application.IO.Site.Models.Source.Notifications;
using Application.IO.Site.Services.Business.Select;
using System;
using System.ComponentModel.DataAnnotations;

namespace Application.IO.Site.Models.Domain
{
    public class AdvogadoAreaAtuacao : Entity
    {
        [Required]
        public Guid IdInsertUser { get; private set; }

        [Required]
        public int IdAdvogado { get; private set; }

        [Required]
        public int IdAreaAtuacao { get; private set; }

        [Required]
        public DateTime DateInsert { get; private set; }

        public AdvogadoAreaAtuacao(Guid idInsertUser, int idAdvogado, int idAreaAtuacao)
        {
            if (new AdvogadoAreaAtuacaoSelect().GetByAdvArea(idAreaAtuacao, idAdvogado) != null) Add(new DomainNotification("AdvogadoAreaAtuacao", $"Área de Atuação já relacionada."));

            IdInsertUser = idInsertUser;
            IdAdvogado = idAdvogado;
            IdAreaAtuacao = idAreaAtuacao;
            DateInsert = DateTime.Now;
        }

        // EF Construtor
        protected AdvogadoAreaAtuacao() { }

        // EF Propriedade de Navegação
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Advogado Advogado { get; set; }
        public virtual AreaAtuacao AreaAtuacao { get; set; }
    }
}
