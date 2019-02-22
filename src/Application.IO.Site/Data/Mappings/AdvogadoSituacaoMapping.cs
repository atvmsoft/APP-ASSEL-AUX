using Application.IO.Site.Extensions;
using Application.IO.Site.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.IO.Site.Data.Mappings
{
    public class AdvogadoSituacaoMapping : EntityTypeConfiguration<AdvogadoSituacao>
    {
        public override void Map(EntityTypeBuilder<AdvogadoSituacao> builder)
        {
            builder.Property(e => e.Date).HasColumnType("datetime");

            builder.ToTable("AdvogadoSituacao");

            builder.HasOne(e => e.ApplicationUser)
                .WithMany(o => o.AdvogadoSituacao)
                .HasForeignKey(e => e.IdUser).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Advogado)
                .WithMany(o => o.AdvogadoSituacao)
                .HasForeignKey(e => e.IdAdvogado).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Situacao)
                .WithMany(o => o.AdvogadoSituacao)
                .HasForeignKey(e => e.IdSituacao).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
