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
        public Guid IdInsertUser { get; private set; }

        [Required]
        public int IdGeoCidade { get; private set; } //Subseção

        [Required]
        public string Nome { get; private set; }

        [Required]
        public string NumOrdem { get; private set; }

        public string NomePai { get; private set; }
        public string NomeMae { get; private set; }

        [Required]
        public DateTime DateInscricaoOAB { get; private set; }

        [Required]
        public DateTime DateAtualizacao { get; private set; }

        [Required]
        public DateTime DateInsert { get; private set; }

        public Advogado(Guid idInsertUser, int idGeoCidade, string nome, string numOrdem, string nomePai, string nomeMae, DateTime dateInscricaoOAB, DateTime dateAtualizacao)
        {
            if (new AdvogadoSelect().GetByNumOrdem(numOrdem) != null) Add(new DomainNotification("Advogado", $"O Número da Ordem \"'{ numOrdem }'\" já existe."));

            IdInsertUser = idInsertUser;
            Nome = nome;
            NumOrdem = numOrdem;
            NomePai = nomePai;
            NomeMae = nomeMae;
            DateInscricaoOAB = dateInscricaoOAB;
            DateAtualizacao = dateAtualizacao;
            DateInsert = DateTime.Now;
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
