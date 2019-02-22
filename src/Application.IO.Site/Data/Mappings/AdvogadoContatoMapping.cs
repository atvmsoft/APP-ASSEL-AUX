using Application.IO.Site.Extensions;
using Application.IO.Site.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.IO.Site.Data.Mappings
{
    public class AdvogadoContatoMapping : EntityTypeConfiguration<AdvogadoContato>
    {
        public override void Map(EntityTypeBuilder<AdvogadoContato> builder)
        {
            builder.Property(e => e.Contato).HasColumnType("varchar(100)");
            builder.Property(e => e.Date).HasColumnType("datetime");

            builder.ToTable("AdvogadoContato");

            builder.HasOne(e => e.ApplicationUser)
                .WithMany(o => o.AdvogadoContato)
                .HasForeignKey(e => e.IdUser).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Advogado)
                .WithMany(o => o.AdvogadoContato)
                .HasForeignKey(e => e.IdAdvogado).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.TipoContato)
                .WithMany(o => o.AdvogadoContato)
                .HasForeignKey(e => e.IdTipoContato).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
