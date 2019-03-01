using System.ComponentModel.DataAnnotations;

namespace Application.IO.Site.Models.AccountViewModels
{
    public class LoginWithRecoveryCodeViewModel
    {
        [Required(ErrorMessage = "\"{0}\" é obrigatório")]
        [DataType(DataType.Text)]
        [Display(Name = "Código de recuperação")]
        public string RecoveryCode { get; set; }
    }
}
