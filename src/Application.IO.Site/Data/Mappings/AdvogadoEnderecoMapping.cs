using Application.IO.Site.Extensions;
using Application.IO.Site.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.IO.Site.Data.Mappings
{
    public class AdvogadoEnderecoMapping : EntityTypeConfiguration<AdvogadoEndereco>
    {
        public override void Map(EntityTypeBuilder<AdvogadoEndereco> builder)
        {
            builder.Property(e => e.Numero).HasColumnType("varchar(10)");
            builder.Property(e => e.Complemento).HasColumnType("varchar(50)");
            builder.Property(e => e.DateInsert).HasColumnType("datetime");

            builder.ToTable("AdvogadoEndereco");

            builder.HasOne(e => e.ApplicationUser)
                .WithMany(o => o.AdvogadoEndereco)
                .HasForeignKey(e => e.IdInsertUser).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Advogado)
                .WithMany(o => o.AdvogadoEndereco)
                .HasForeignKey(e => e.IdAdvogado).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.TipoEndereco)
                .WithMany(o => o.AdvogadoEndereco)
                .HasForeignKey(e => e.IdTipoEndereco).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.GeoCep)
                .WithMany(o => o.AdvogadoEndereco)
                .HasForeignKey(e => e.IdGeoCep).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
