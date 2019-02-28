using Application.IO.Site.Models.Source;
using Application.IO.Site.Models.Source.Notifications;
using Application.IO.Site.Services.Business.Select;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

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

        #region VALIDATORS
        protected void ValidaContato(string contato)
        {
            if (!new Regex(@"\([0-9]{2}\) [0-9]{8,9}").IsMatch(contato.Trim())) Add(new DomainNotification("AdvogadoContato", "O Contato está incorreto"));
        }

        protected void ValidaAdvogado(Guid idUser, int idAdvogado)
        {
            if (new AdvogadoSelect().GetById(idAdvogado, idUser) == null) Add(new DomainNotification("AdvogadoContato", "Advogado não encontrado."));
        }

        protected void ValidaTipoContato(int idTipoContato)
        {
            if (new TipoContatoSelect().GetById(idTipoContato) == null) Add(new DomainNotification("AdvogadoContato", "Tipo Contato não encontrado."));
        }

        protected void ValidaAdvogadoContato(int idAdvogado, int idTipoContato, string contato)
        {
            if (new AdvogadoContatoSelect().GetByAdvContato(idAdvogado, idTipoContato, contato) != null) Add(new DomainNotification("AdvogadoContato", $"O Contato \"'{ contato }'\" já existe."));
        }
        #endregion

        public AdvogadoContato(Guid idUser, int idAdvogado, int idTipoContato, string contato)
        {
            ValidaContato(contato);
            ValidaAdvogado(idUser, idAdvogado);
            ValidaTipoContato(idTipoContato);
            ValidaAdvogadoContato(idAdvogado, idTipoContato, contato);

            IdUser = idUser;
            IdAdvogado = idAdvogado;
            IdTipoContato = idTipoContato;
            Contato = contato;
            Date = DateTime.Now;
        }

        public void ChangeEntity(Guid idUser, int idAdvogado, int idTipoContato, string contato, bool delete)
        {
            if (!delete)
            {
                ValidaContato(contato);
                ValidaAdvogado(idUser, idAdvogado);
                ValidaTipoContato(idTipoContato);
                ValidaAdvogadoContato(idAdvogado, idTipoContato, contato);

                IdUser = idUser;
                IdAdvogado = idAdvogado;
                IdTipoContato = idTipoContato;
                Contato = contato;
            }

            Date = DateTime.Now;
            Delete = delete;
        }

        // EF Construtor
        protected AdvogadoContato() { }

        // EF Propriedade de Navegação
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Advogado Advogado { get; set; }
        public virtual TipoContato TipoContato { get; set; }
    }
}
