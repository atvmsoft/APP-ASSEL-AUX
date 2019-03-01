using System.ComponentModel.DataAnnotations;

namespace Application.IO.Site.Models.AccountViewModels
{
    public class LoginWith2faViewModel
    {
        [Required(ErrorMessage = "\"{0}\" é obrigatório")]
        [StringLength(7, ErrorMessage = "O {0} deve ter entre {2} e {1} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Text)]
        [Display(Name = "Código")]
        public string TwoFactorCode { get; set; }

        [Display(Name = "Mantenha-me conectado neste dispositivo")]
        public bool RememberMachine { get; set; }

        [Display(Name = "Mantenha-me conectado")]
        public bool RememberMe { get; set; }
    }
}
