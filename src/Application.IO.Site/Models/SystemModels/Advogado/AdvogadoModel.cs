using Application.IO.Site.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace Application.IO.Site.Models.SystemModels.Advogado
{
    public class AdvogadoModel
    {
        [Display(Name = "Atualização")]
        [ModelBinder(BinderType = typeof(PtBrDateTimeBinder))]
        public DateTime DateAtualizacao { get; set; }

        [Display(Name = "Inscrição")]
        [ModelBinder(BinderType = typeof(PtBrDateTimeBinder))]
        public DateTime DateInscricaoOAB { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "\"{0}\" é obrigatório")]
        public int IdGeoEstado { get; set; }

        [Display(Name = "Subseção")]
        [Required(ErrorMessage = "\"{0}\" é obrigatório")]
        public int IdGeoCidade { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "\"{0}\" é obrigatório")]
        [StringLength(100, ErrorMessage = "\"{0}\" deve ter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string Nome { get; set; }

        [Display(Name = "Nome da Mãe")]
        [StringLength(100, ErrorMessage = "\"{0}\" deve ter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string NomeMae { get; set; }

        [Display(Name = "Nome do Pai")]
        [StringLength(100, ErrorMessage = "\"{0}\" deve ter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string NomePai { get; set; }

        [Display(Name = "Nº OAB")]
        [StringLength(10, ErrorMessage = "\"{0}\" deve ter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string NumOrdem { get; set; }

        public string ListSituacao { get; set; }
        public string ListAreaAtuacao { get; set; }
        public string Foto { get; set; }
        public string EstadoSigla { get; set; }

        [Display(Name = "Foto")]
        public IFormFile IFoto { get; set; }

        public bool Delete { get; set; }

        public int Id { get; set; }

        public DateTime Date { get; set; }
    }
}
