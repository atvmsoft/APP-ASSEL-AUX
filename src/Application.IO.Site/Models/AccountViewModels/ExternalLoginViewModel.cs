using System.ComponentModel.DataAnnotations;

namespace Application.IO.Site.Models.AccountViewModels
{
    public class ExternalLoginViewModel
    {
        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "\"{0}\" � obrigat�rio")]
        [EmailAddress(ErrorMessage = "\"{0}\" inv�lido")]
        public string Email { get; set; }
    }
}
