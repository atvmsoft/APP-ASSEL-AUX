using System.ComponentModel.DataAnnotations;

namespace Application.IO.Site.Models.AccountViewModels
{
    public class ResetPasswordViewModel
    {
        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "\"{0}\" é obrigatório")]
        [EmailAddress(ErrorMessage = "\"{0}\" inválido")]
        public string Email { get; set; }

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

        public string Code { get; set; }
    }
}
