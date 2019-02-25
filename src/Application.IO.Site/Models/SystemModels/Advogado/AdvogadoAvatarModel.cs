using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Application.IO.Site.Models.SystemModels.Advogado
{
    public class AdvogadoAvatarModel
    {
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Display(Name = "Foto")]
        public IFormFile IFoto { get; set; }

        public int Id { get; set; }
        public string Foto { get; set; }
    }
}
