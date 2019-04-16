using System;
using System.ComponentModel.DataAnnotations;

namespace Application.IO.Site.Models.SystemModels.Advogado
{
    public class AdvogadoEnderecoModel
    {
        [Display(Name = "Tipo de Endereço")]
        [Required(ErrorMessage = "\"{0}\" é obrigatório")]
        public int IdTipoEndereco { get; set; }

        [Display(Name = "CEP")]
        [Required(ErrorMessage = "\"{0}\" é obrigatório")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "\"{0}\" deve possuir {1} caracteres")]
        public string CodCep { get; set; }

        [Display(Name = "Logradouro")]
        [Required(ErrorMessage = "\"{0}\" é obrigatório")]
        [StringLength(300, MinimumLength = 1, ErrorMessage = "\"{0}\" deve possuir até {1} caracteres")]
        public string Logradouro { get; set; }

        [Display(Name = "Bairro")]
        [Required(ErrorMessage = "\"{0}\" é obrigatório")]
        [StringLength(150, MinimumLength = 1, ErrorMessage = "\"{0}\" deve possuir até {1} caracteres")]
        public string Bairro { get; set; }

        [Display(Name = "Cidade")]
        [Required(ErrorMessage = "\"{0}\" é obrigatório")]
        public int IdEndGeoCidade { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "\"{0}\" é obrigatório")]
        public int IdEndGeoEstado { get; set; }

        [Display(Name = "Nº")]
        [Required(ErrorMessage = "\"{0}\" é obrigatório")]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "\"{0}\" deve possuir até {1} caracteres")]
        public string Numero { get; set; }

        [Display(Name = "Complemento")]
        [StringLength(50, MinimumLength = 0, ErrorMessage = "\"{0}\" deve possuir até {1} caracteres")]
        public string Complemento { get; set; }

        #region EXTRA DATA
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        [Display(Name = "Cidade")]
        public string Cidade { get; set; }

        [Display(Name = "Estado")]
        public string Estado { get; set; }

        public bool Delete { get; set; }
        public bool InsEndereco { get; set; }
        public string TipoEndereco { get; set; }
        public int IdGeoCep { get; set; }
        public int IdEnd { get; set; }
        public int IdAdvogado { get; set; }
        public DateTime Date { get; set; }
        #endregion
    }
}
