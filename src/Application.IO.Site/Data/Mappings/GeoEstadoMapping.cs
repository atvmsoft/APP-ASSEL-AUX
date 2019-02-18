using Application.IO.Site.Extensions;
using Application.IO.Site.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.IO.Site.Data.Mappings
{
    public class GeoEstadoMapping : EntityTypeConfiguration<GeoEstado>
    {
        public override void Map(EntityTypeBuilder<GeoEstado> builder)
        {
            builder.Property(e => e.Nome).HasColumnType("varchar(20)");
            builder.Property(e => e.Sigla).HasColumnType("varchar(2)");

            builder.ToTable("GeoEstado");
        }
    }
}
