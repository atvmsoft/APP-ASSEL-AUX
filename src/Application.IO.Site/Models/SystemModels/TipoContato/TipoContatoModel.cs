using System.ComponentModel.DataAnnotations;

namespace Application.IO.Site.Models.SystemModels.TipoContato
{
    public class TipoContatoModel
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "\"{0}\" é obrigatório")]
        [StringLength(200, ErrorMessage = "\"{0}\" deve ter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string Nome { get; set; }

        public bool Delete { get; set; }

        public int Id { get; set; }
    }
}
