using Application.IO.Site.Data.Mappings;
using Application.IO.Site.Extensions;
using Application.IO.Site.Models;
using Application.IO.Site.Models.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Application.IO.Site.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public virtual DbSet<AreaAtuacao> AreaAtuacao { get; set; }
        public virtual DbSet<Situacao> Situacao { get; set; }
        public virtual DbSet<GeoCep> GeoCep { get; set; }
        public virtual DbSet<GeoEstado> GeoEstado { get; set; }
        public virtual DbSet<GeoCidade> GeoCidade { get; set; }
        public virtual DbSet<Advogado> Advogado { get; set; }
        public virtual DbSet<TipoContato> TipoContato { get; set; }
        public virtual DbSet<AdvogadoContato> AdvogadoContato { get; set; }
        public virtual DbSet<TipoEndereco> TipoEndereco { get; set; }
        public virtual DbSet<AdvogadoEndereco> AdvogadoEndereco { get; set; }
        public virtual DbSet<AdvogadoAreaAtuacao> AdvogadoAreaAtuacao { get; set; }
        public virtual DbSet<AdvogadoSituacao> AdvogadoSituacao { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new AreaAtuacaoMapping());
            modelBuilder.AddConfiguration(new SituacaoMapping());
            modelBuilder.AddConfiguration(new GeoCepMapping());
            modelBuilder.AddConfiguration(new GeoEstadoMapping());
            modelBuilder.AddConfiguration(new GeoCidadeMapping());
            modelBuilder.AddConfiguration(new AdvogadoMapping());
            modelBuilder.AddConfiguration(new TipoContatoMapping());
            modelBuilder.AddConfiguration(new AdvogadoContatoMapping());
            modelBuilder.AddConfiguration(new TipoEnderecoMapping());
            modelBuilder.AddConfiguration(new AdvogadoEnderecoMapping());
            modelBuilder.AddConfiguration(new AdvogadoAreaAtuacaoMapping());
            modelBuilder.AddConfiguration(new AdvogadoSituacaoMapping());

            base.OnModelCreating(modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
