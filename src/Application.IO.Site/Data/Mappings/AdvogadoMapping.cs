using Application.IO.Site.Extensions;
using Application.IO.Site.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.IO.Site.Data.Mappings
{
    public class AdvogadoMapping : EntityTypeConfiguration<Advogado>
    {
        public override void Map(EntityTypeBuilder<Advogado> builder)
        {
            builder.Property(e => e.Nome).HasColumnType("varchar(100)");
            builder.Property(e => e.NumOrdem).HasColumnType("varchar(10)");
            builder.Property(e => e.NomePai).HasColumnType("varchar(100)");
            builder.Property(e => e.NomeMae).HasColumnType("varchar(100)");
            builder.Property(e => e.Foto).HasColumnType("varchar(50)");
            builder.Property(e => e.DateInscricaoOAB).HasColumnType("datetime");
            builder.Property(e => e.DateAtualizacao).HasColumnType("datetime");
            builder.Property(e => e.Date).HasColumnType("datetime");

            builder.ToTable("Advogado");

            builder.HasOne(e => e.ApplicationUser)
                .WithMany(o => o.AdvogadoInsert)
                .HasForeignKey(e => e.IdUser).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.GeoCidade)
                .WithMany(o => o.Advogado)
                .HasForeignKey(e => e.IdGeoCidade).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
