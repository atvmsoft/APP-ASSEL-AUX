using Application.IO.Site.Models.Source;
using Application.IO.Site.Models.Source.Notifications;
using Application.IO.Site.Services.Business.Select;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.IO.Site.Models.Domain
{
    public class Advogado : Entity
    {
        [Required]
        public Guid IdUser { get; private set; }

        [Required]
        public int IdGeoCidade { get; private set; } //Subseção

        [Required]
        public string Nome { get; private set; }

        [Required]
        public string NumOrdem { get; private set; }

        public string Foto { get; private set; }
        public string NomePai { get; private set; }
        public string NomeMae { get; private set; }
        public DateTime? DateInscricaoOAB { get; private set; }
        public DateTime? DateAtualizacao { get; private set; }

        [Required]
        public DateTime Date { get; private set; }

        [Required]
        public bool Delete { get; private set; }

        #region VALIDATIONS
        protected void ValidaGeoCidade(int idGeoCidade)
        {
            if (new GeoCidadeSelect().GetById(idGeoCidade) == null) Add(new DomainNotification("Advogado", $"Subseção não encontrada."));
        }

        protected void ValidaNumOAB(int idGeoCidade, string numOrdem)
        {
            if (new AdvogadoSelect().GetByNumOrdem(numOrdem, idGeoCidade) != null) Add(new DomainNotification("Advogado", $"O Número da Ordem \"'{ numOrdem }'\" já existe."));
        }

        protected void ValidaDataInscricao(DateTime? dateInscricaoOAB)
        {
            if (dateInscricaoOAB != null)
                if (dateInscricaoOAB.Value > DateTime.Now) Add(new DomainNotification("Advogado", $"A Inscrição: \"'{ dateInscricaoOAB.Value.ToString("dd/MM/yyyy") }'\", é maior do que hoje."));
                else if (dateInscricaoOAB.Value.Year < (DateTime.Now.Year - 100)) Add(new DomainNotification("Advogado", $"A Inscrição: \"'{ dateInscricaoOAB.Value.ToString("dd/MM/yyyy") }'\", é inválida."));
        }

        protected void ValidaDataAtualizacao(DateTime? dateAtualizacao)
        {
            if (dateAtualizacao != null)
                if (dateAtualizacao.Value > DateTime.Now) Add(new DomainNotification("Advogado", $"A Atualização: \"'{ dateAtualizacao.Value.ToString("dd/MM/yyyy") }'\", é maior do que hoje."));
                else if (dateAtualizacao.Value.Year < (DateTime.Now.Year - 100)) Add(new DomainNotification("Advogado", $"A Atualização: \"'{ dateAtualizacao.Value.ToString("dd/MM/yyyy") }'\", é inválida."));
        }

        protected void ValidaDataInscAtt(DateTime? dateInscricaoOAB, DateTime? dateAtualizacao)
        {
            if (dateInscricaoOAB != null && dateAtualizacao != null)
                if (dateInscricaoOAB.Value > dateAtualizacao.Value) Add(new DomainNotification("Advogado", $"A Atualização deve ser maior do que Inscrição."));
        }
        #endregion

        public Advogado(Guid idUser, int idGeoCidade, string nome, string numOrdem, IFormFile foto, string nomePai, string nomeMae, DateTime? dateInscricaoOAB, DateTime? dateAtualizacao)
        {
            ValidaGeoCidade(idGeoCidade);
            ValidaNumOAB(idGeoCidade, numOrdem);
            ValidaDataInscricao(dateInscricaoOAB);
            ValidaDataAtualizacao(dateAtualizacao);
            ValidaDataInscAtt(dateInscricaoOAB, dateAtualizacao);

            IdUser = idUser;
            IdGeoCidade = idGeoCidade;
            Nome = nome.ToUpper();
            NumOrdem = numOrdem;
            Foto = foto == null ? null : $"{ Guid.NewGuid().ToString() }{ foto.FileName.Substring(foto.FileName.LastIndexOf(".")) }";
            NomePai = nomePai?.ToUpper();
            NomeMae = nomeMae?.ToUpper();
            DateInscricaoOAB = dateInscricaoOAB;
            DateAtualizacao = dateAtualizacao;
            Date = DateTime.Now;
            Delete = false;
        }

        public void ChangeEntity(int idGeoCidade, string nome, string numOrdem, string nomePai, string nomeMae, DateTime? dateInscricaoOAB, DateTime? dateAtualizacao, bool delete)
        {
            if (!delete)
            {
                ValidaGeoCidade(idGeoCidade);

                var adv = new AdvogadoSelect().GetByNumOrdem(numOrdem, idGeoCidade);
                if (adv != null && adv.Id != Id) Add(new DomainNotification("Advogado", $"O Número da Ordem \"'{ numOrdem }'\" já existe."));

                ValidaDataInscricao(dateInscricaoOAB);
                ValidaDataAtualizacao(dateAtualizacao);
                ValidaDataInscAtt(dateInscricaoOAB, dateAtualizacao);

                IdGeoCidade = idGeoCidade;
                Nome = nome.ToUpper();
                NumOrdem = numOrdem;
                NomePai = nomePai?.ToUpper();
                NomeMae = nomeMae?.ToUpper();
                DateInscricaoOAB = dateInscricaoOAB;
                DateAtualizacao = dateAtualizacao;
            }

            Delete = delete;
            Date = DateTime.Now;
        }

        public void ChangeAvatar(string foto)
        {
            Foto = foto;
            Date = DateTime.Now;
        }

        // EF Construtor
        protected Advogado() { }

        // EF Propriedade de Navegação
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual GeoCidade GeoCidade { get; set; }
        public virtual ICollection<AdvogadoContato> AdvogadoContato { get; set; }
        public virtual ICollection<AdvogadoEndereco> AdvogadoEndereco { get; set; }
        public virtual ICollection<AdvogadoAreaAtuacao> AdvogadoAreaAtuacao { get; set; }
        public virtual ICollection<AdvogadoSituacao> AdvogadoSituacao { get; set; }
    }
}
