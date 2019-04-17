using Application.IO.Site.Models.Source;
using Application.IO.Site.Models.Source.Notifications;
using Application.IO.Site.Services.Business.Select;
using System;
using System.ComponentModel.DataAnnotations;

namespace Application.IO.Site.Models.Domain
{
    public class AdvogadoEndereco : Entity
    {
        [Required]
        public Guid IdUser { get; private set; }

        [Required]
        public int IdAdvogado { get; private set; }

        [Required]
        public int IdTipoEndereco { get; private set; }

        [Required]
        public int IdGeoCep { get; private set; }

        [Required]
        public string Numero { get; private set; }

        public string Complemento { get; private set; }

        [Required]
        public bool Delete { get; private set; }

        [Required]
        public DateTime Date { get; private set; }

        #region VALIDATORS
        protected void ValidaAdvEndereco(int idAdvogado, int idTipoEndereco, int idGeoCep, string numero, string complemento)
        {
            if (new AdvogadoEnderecoSelect().GetByAdvEndreco(idAdvogado, idTipoEndereco, idGeoCep, numero, complemento) != null) Add(new DomainNotification("AdvogadoEndereco", $"Este endereço já existe."));
        }

        protected void ValidaAdvogado(Guid idUser, int idAdvogado)
        {
            if (new AdvogadoSelect().Get(idAdvogado, idUser) == null) Add(new DomainNotification("AdvogadoEndereco", $"Advogado não encontrado."));
        }

        protected void ValidaTipoEndereco(int idTipoEndereco)
        {
            if (new TipoEnderecoSelect().GetById(idTipoEndereco) == null) Add(new DomainNotification("AdvogadoEndereco", $"Tipo de Endereço não encontrado."));
        }

        protected void ValidaGeoCep(int idGeoCep)
        {
            if (new GeoCepSelect().GetById(idGeoCep) == null) Add(new DomainNotification("AdvogadoEndereco", $"CEP não encontrado."));
        }
        #endregion

        public AdvogadoEndereco(Guid idUser, int idAdvogado, int idTipoEndereco, int idGeoCep, string numero, string complemento)
        {
            ValidaTipoEndereco(idTipoEndereco);
            ValidaGeoCep(idGeoCep);
            ValidaAdvogado(idUser, idAdvogado);
            ValidaAdvEndereco(idAdvogado, idTipoEndereco, idGeoCep, numero.Trim(), complemento?.Trim());

            IdUser = idUser;
            IdAdvogado = idAdvogado;
            IdTipoEndereco = idTipoEndereco;
            IdGeoCep = idGeoCep;
            Numero = numero.Trim().ToUpper();
            Complemento = string.IsNullOrEmpty(complemento) ? null : tCase.ToTitleCase(complemento.Trim());
            Date = DateTime.Now;
        }

        public void ChangeEntity(Guid idUser, int idAdvogado, int idTipoEndereco, int idGeoCep, string numero, string complemento, bool delele)
        {
            if (!delele)
            {
                ValidaTipoEndereco(idTipoEndereco);
                ValidaGeoCep(idGeoCep);
                ValidaAdvogado(idUser, idAdvogado);
                ValidaAdvEndereco(idAdvogado, idTipoEndereco, idGeoCep, numero.Trim(), complemento?.Trim());

                IdUser = idUser;
                IdAdvogado = idAdvogado;
                IdTipoEndereco = idTipoEndereco;
                IdGeoCep = idGeoCep;
                Numero = numero.ToUpper();
                Complemento = string.IsNullOrEmpty(complemento) ? null : tCase.ToTitleCase(complemento.Trim());
            }

            Delete = delele;
            Date = DateTime.Now;
        }

        // EF Construtor
        protected AdvogadoEndereco() { }

        // EF Propriedade de Navegação
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Advogado Advogado { get; set; }
        public virtual TipoEndereco TipoEndereco { get; set; }
        public virtual GeoCep GeoCep { get; set; }
    }
}
