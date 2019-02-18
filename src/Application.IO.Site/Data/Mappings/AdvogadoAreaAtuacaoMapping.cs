using Application.IO.Site.Extensions;
using Application.IO.Site.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.IO.Site.Data.Mappings
{
    public class AdvogadoAreaAtuacaoMapping : EntityTypeConfiguration<AdvogadoAreaAtuacao>
    {
        public override void Map(EntityTypeBuilder<AdvogadoAreaAtuacao> builder)
        {
            builder.Property(e => e.DateInsert).HasColumnType("datetime");

            builder.ToTable("AdvogadoAreaAtuacao");

            builder.HasOne(e => e.ApplicationUser)
                .WithMany(o => o.AdvogadoAreaAtuacao)
                .HasForeignKey(e => e.IdInsertUser).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Advogado)
                .WithMany(o => o.AdvogadoAreaAtuacao)
                .HasForeignKey(e => e.IdAdvogado).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.AreaAtuacao)
                .WithMany(o => o.AdvogadoAreaAtuacao)
                .HasForeignKey(e => e.IdAreaAtuacao).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
