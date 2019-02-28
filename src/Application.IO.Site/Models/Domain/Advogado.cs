using Application.IO.Site.Models.Source;
using Application.IO.Site.Models.Source.Notifications;
using Application.IO.Site.Services.Business.Select;
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

        [Required]
        public string Foto { get; private set; }

        public string NomePai { get; private set; }
        public string NomeMae { get; private set; }

        [Required]
        public DateTime DateInscricaoOAB { get; private set; }

        [Required]
        public DateTime DateAtualizacao { get; private set; }

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

        protected void ValidaDataInscricao(DateTime dateInscricaoOAB)
        {
            if (dateInscricaoOAB > DateTime.Now) Add(new DomainNotification("Advogado", $"A Inscrição: \"'{ dateInscricaoOAB.ToString("dd/MM/yyyy") }'\", é maior do que hoje."));
            else if (dateInscricaoOAB.Year < (DateTime.Now.Year - 100)) Add(new DomainNotification("Advogado", $"A Inscrição: \"'{ dateInscricaoOAB.ToString("dd/MM/yyyy") }'\", é inválida."));
        }

        protected void ValidaDataAtualizacao(DateTime dateAtualizacao)
        {
            if (dateAtualizacao > DateTime.Now) Add(new DomainNotification("Advogado", $"A Atualização: \"'{ dateAtualizacao.ToString("dd/MM/yyyy") }'\", é maior do que hoje."));
            else if (dateAtualizacao.Year < (DateTime.Now.Year - 100)) Add(new DomainNotification("Advogado", $"A Atualização: \"'{ dateAtualizacao.ToString("dd/MM/yyyy") }'\", é inválida."));
        }

        protected void ValidaDataInscAtt(DateTime dateInscricaoOAB, DateTime dateAtualizacao)
        {
            if (dateInscricaoOAB > dateAtualizacao) Add(new DomainNotification("Advogado", $"A Atualização deve ser maior do que Inscrição."));
        }

        protected void ValidaAvatar(string foto)
        {
            if (string.IsNullOrEmpty(foto)) Add(new DomainNotification("Advogado", $"A Foto não foi fornecida."));
        }
        #endregion

        public Advogado(Guid idUser, int idGeoCidade, string nome, string numOrdem, string foto, string nomePai, string nomeMae, DateTime dateInscricaoOAB, DateTime dateAtualizacao)
        {
            ValidaGeoCidade(idGeoCidade);
            ValidaNumOAB(idGeoCidade, numOrdem);
            ValidaDataInscricao(dateInscricaoOAB);
            ValidaDataAtualizacao(dateAtualizacao);
            ValidaDataInscAtt(dateInscricaoOAB, dateAtualizacao);
            ValidaAvatar(foto);

            IdUser = idUser;
            IdGeoCidade = idGeoCidade;
            Nome = nome.ToUpper();
            NumOrdem = numOrdem;
            Foto = foto;
            NomePai = nomePai.ToUpper();
            NomeMae = nomeMae.ToUpper();
            DateInscricaoOAB = dateInscricaoOAB;
            DateAtualizacao = dateAtualizacao;
            Date = DateTime.Now;
            Delete = false;
        }

        public void ChangeEntity(int idGeoCidade, string nome, string numOrdem, string nomePai, string nomeMae, DateTime dateInscricaoOAB, DateTime dateAtualizacao, bool delete)
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
                NomePai = nomePai.ToUpper();
                NomeMae = nomeMae.ToUpper();
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
