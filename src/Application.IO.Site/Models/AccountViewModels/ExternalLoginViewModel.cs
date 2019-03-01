using System.ComponentModel.DataAnnotations;

namespace Application.IO.Site.Models.AccountViewModels
{
    public class ExternalLoginViewModel
    {
        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "\"{0}\" é obrigatório")]
        [EmailAddress(ErrorMessage = "\"{0}\" inválido")]
        public string Email { get; set; }
    }
}
