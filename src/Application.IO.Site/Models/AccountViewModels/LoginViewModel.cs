using System.ComponentModel.DataAnnotations;

namespace Application.IO.Site.Models.AccountViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "E-mail"), Required]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Senha"), Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Mantenha-me conectado")]
        public bool RememberMe { get; set; }
    }
}
