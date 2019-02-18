using Application.IO.Site.Extensions;
using Application.IO.Site.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.IO.Site.Data.Mappings
{
    public class GeoCidadeMapping : EntityTypeConfiguration<GeoCidade>
    {
        public override void Map(EntityTypeBuilder<GeoCidade> builder)
        {
            builder.Property(e => e.Nome).HasColumnType("varchar(200)");

            builder.ToTable("GeoCidade");

            builder.HasOne(e => e.GeoEstado)
                .WithMany(o => o.GeoCidade)
                .HasForeignKey(e => e.IdGeoEstado).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
