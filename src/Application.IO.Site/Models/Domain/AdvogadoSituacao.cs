using Application.IO.Site.Models.Source;
using Application.IO.Site.Models.Source.Notifications;
using Application.IO.Site.Services.Business.Select;
using System;
using System.ComponentModel.DataAnnotations;

namespace Application.IO.Site.Models.Domain
{
    public class AdvogadoSituacao : Entity
    {
        [Required]
        public Guid IdUser { get; private set; }

        [Required]
        public int IdAdvogado { get; private set; }

        [Required]
        public int IdSituacao { get; private set; }

        [Required]
        public DateTime Date { get; private set; }

        public AdvogadoSituacao(Guid idUser, int idAdvogado, int idSituacao)
        {
            if (new AdvogadoSituacaoSelect().GetByAdvSituacao(idSituacao, idAdvogado) != null) Add(new DomainNotification("AdvogadoSituacao", $"Situação já relacionada."));

            var adv = new AdvogadoSelect().GetById(IdAdvogado, idUser);
            if (adv == null) Add(new DomainNotification("AdvogadoSituacao", $"Situação já relacionada."));

            IdUser = idUser;
            IdAdvogado = idAdvogado;
            IdSituacao = idSituacao;
            Date = DateTime.Now;
        }

        // EF Construtor
        protected AdvogadoSituacao() { }

        // EF Propriedade de Navegação
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Advogado Advogado { get; set; }
        public virtual Situacao Situacao { get; set; }
    }
}
