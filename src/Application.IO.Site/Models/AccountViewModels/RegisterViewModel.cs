using System.ComponentModel.DataAnnotations;

namespace Application.IO.Site.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "\"{0}\" é obrigatório")]
        [StringLength(100, ErrorMessage = "\"{0}\" deve ter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string Name { get; set; }

        [Display(Name = "CPF")]
        [DisplayFormat(DataFormatString = "{0:###.###.###-##}")]
        [Required(ErrorMessage = "\"{0}\" é obrigatório")]
        public string NumDocument { get; set; }

        [Display(Name = "E-mail")]
        [EmailAddress(ErrorMessage = "Formato incorreto (a@b)")]
        [Required(ErrorMessage = "\"{0}\" é obrigatório")]
        [StringLength(256, ErrorMessage = "\"{0}\" deve ter entre {2} e {1} caracteres.", MinimumLength = 3)]
        public string Email { get; set; }

        [Display(Name = "Confirmar E-mail")]
        [Required(ErrorMessage = "\"{0}\" é obrigatório")]
        [Compare("Email", ErrorMessage = "\"{0}\" deve ser igual a \"E-mail\".")]
        public string ConfirmEmail { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "\"{0}\" é obrigatório")]
        [StringLength(10, ErrorMessage = "\"{0}\" deve ter entre {2} e {1} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirmar Senha")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "\"{0}\" é obrigatório")]
        [Compare("Password", ErrorMessage = "\"{0}\" deve ser igual a \"Senha\".")]
        public string ConfirmPassword { get; set; }
    }
}
