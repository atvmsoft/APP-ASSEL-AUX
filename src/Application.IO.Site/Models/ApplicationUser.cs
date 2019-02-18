using Application.IO.Site.Models.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.IO.Site.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser<Guid>
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required, MaxLength(40)]
        public string NumDocument { get; set; }

        [Required, DataType(DataType.DateTime)]
        public DateTime DateCreated { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? UserEmailConfirm { get; set; }

        [Required]
        public bool LogicalDeleted { get; set; }

        public ApplicationUser()
        {
            DateCreated = DateTime.Now;
        }

        public virtual ICollection<TipoEndereco> TipoEndereco { get; set; }
        public virtual ICollection<TipoContato> TipoContato { get; set; }
        public virtual ICollection<Situacao> Situacao { get; set; }
        public virtual ICollection<GeoCep> GeoCep { get; set; }
        public virtual ICollection<AreaAtuacao> AreaAtuacao { get; set; }
        public virtual ICollection<AdvogadoSituacao> AdvogadoSituacao { get; set; }
        public virtual ICollection<AdvogadoEndereco> AdvogadoEndereco { get; set; }
        public virtual ICollection<AdvogadoContato> AdvogadoContato { get; set; }
        public virtual ICollection<AdvogadoAreaAtuacao> AdvogadoAreaAtuacao { get; set; }
        public virtual ICollection<Advogado> AdvogadoInsert { get; set; }
    }
}
