using System.ComponentModel.DataAnnotations;

namespace Application.IO.Site.Models.ManageViewModels
{
    public class IndexViewModel
    {
        [Display(Name ="Usuário")]
        public string Username { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "\"{0}\" é obrigatório")]
        [StringLength(256, ErrorMessage = "\"{0}\" deve ter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string Name { get; set; }

        [Display(Name = "CPF")]
        [DisplayFormat(DataFormatString = "{0:###.###.###-##}")]
        [Required(ErrorMessage = "\"{0}\" é obrigatório")]
        public string NumDocument { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "\"{0}\" é obrigatório")]
        [EmailAddress(ErrorMessage = "\"{0}\" inválido")]
        public string Email { get; set; }

        [Display(Name = "Status")]
        public string StatusMessage { get; set; }
    }
}
