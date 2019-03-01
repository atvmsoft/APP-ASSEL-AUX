using System.ComponentModel.DataAnnotations;

namespace Application.IO.Site.Models.ManageViewModels
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "\"{0}\" é obrigatório")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha atual")]
        public string OldPassword { get; set; }

        [Display(Name = "Nova Senha")]
        [Required(ErrorMessage = "\"{0}\" é obrigatório")]
        [StringLength(10, ErrorMessage = "\"{0}\" deve ter entre {2} e {1} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Display(Name = "Confirmar Nova Senha")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "\"{0}\" é obrigatório")]
        [Compare("NewPassword", ErrorMessage = "\"{0}\" deve ser igual a \"Nova Senha\".")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Status")]
        public string StatusMessage { get; set; }
    }
}
