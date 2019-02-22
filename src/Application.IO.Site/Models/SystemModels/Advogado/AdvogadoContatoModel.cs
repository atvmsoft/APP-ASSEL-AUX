using System;
using System.ComponentModel.DataAnnotations;

namespace Application.IO.Site.Models.SystemModels.Advogado
{
    public class AdvogadoContatoModel
    {
        [Display(Name = "Tipo de Contato")]
        [Required(ErrorMessage = "\"{0}\" é obrigatório")]
        public int IdTipoContato { get; set; }

        [Display(Name = "Contato")]
        [Required(ErrorMessage = "\"{0}\" é obrigatório")]
        [StringLength(100, ErrorMessage = "\"{0}\" deve ter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string Contato { get; set; }

        public bool Delete { get; set; }
        public int Id { get; set; }
        public int IdAdvogado { get; set; }
        public DateTime Date { get; set; }

        public string TipoContato { get; set; }
    }
}
