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
        public string CodCep { get; set; }

        [Display(Name = "Logradouro")]
        [Required(ErrorMessage = "\"{0}\" é obrigatório")]
        public string Logradouro { get; set; }

        [Display(Name = "Bairro")]
        [Required(ErrorMessage = "\"{0}\" é obrigatório")]
        public string Bairro { get; set; }

        [Display(Name = "Cidade")]
        [Required(ErrorMessage = "\"{0}\" é obrigatório")]
        public int IdGeoCidade { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "\"{0}\" é obrigatório")]
        public int IdGeoEstado { get; set; }

        [Display(Name = "Nº")]
        [Required(ErrorMessage = "\"{0}\" é obrigatório")]
        public string Numero { get; set; }

        [Display(Name = "Complemento")]
        public string Complemento { get; set; }
        
        public string Endereco { get; set; }

        #region EXTRA DATA
        [Display(Name = "Cidade")]
        public string Cidade { get; set; }
        [Display(Name = "Estado")]
        public string Estado { get; set; }
        public string TipoEndereco { get; set; }
        public int IdGeoCep { get; set; }
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int IdAdvogado { get; set; }
        #endregion
    }
}
