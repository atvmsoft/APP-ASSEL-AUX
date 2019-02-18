using System;
using System.ComponentModel.DataAnnotations;

namespace Application.IO.Site.Models.SystemModels.Advogado
{
    public class AdvogadoModel
    {
        [Display(Name = "Atualização")]
        public DateTime DateAtualizacao { get; set; }

        [Display(Name = "Inscrição")]
        public DateTime DateInscricaoOAB { get; set; }

        [Display(Name = "Subseção")]
        public int IdGeoCidade { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "\"{0}\" é obrigatório")]
        [StringLength(100, ErrorMessage = "\"{0}\" deve ter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string Nome { get; set; }

        [Display(Name = "Nome da Mãe")]
        [StringLength(100, ErrorMessage = "\"{0}\" deve ter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string NomeMae { get; set; }

        [Display(Name = "Nome do Pai")]
        [StringLength(100, ErrorMessage = "\"{0}\" deve ter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string NomePai { get; set; }

        [Display(Name = "Nº OAB")]
        [StringLength(8, ErrorMessage = "\"{0}\" deve ter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string NumOrdem { get; set; }

        public bool Delete { get; set; }

        public int Id { get; set; }
    }
}
