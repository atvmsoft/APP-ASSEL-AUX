using Application.IO.Site.Extensions;
using Application.IO.Site.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.IO.Site.Data.Mappings
{
    public class GeoCepMapping : EntityTypeConfiguration<GeoCep>
    {
        public override void Map(EntityTypeBuilder<GeoCep> builder)
        {
            builder.Property(e => e.Codigo).HasColumnType("varchar(8)");
            builder.Property(e => e.Endereco).HasColumnType("varchar(300)");
            builder.Property(e => e.Bairro).HasColumnType("varchar(150)");
            builder.Property(e => e.Cidade).HasColumnType("varchar(100)");
            builder.Property(e => e.Estado).HasColumnType("varchar(20)");
            builder.Property(e => e.DateInsert).HasColumnType("datetime");

            builder.ToTable("GeoCep");

            builder.HasOne(e => e.ApplicationUser)
                .WithMany(o => o.GeoCep)
                .HasForeignKey(e => e.IdInsertUser).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
