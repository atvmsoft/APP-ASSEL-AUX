using Application.IO.Site.Extensions;
using Application.IO.Site.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.IO.Site.Data.Mappings
{
    public class TipoEnderecoMapping : EntityTypeConfiguration<TipoEndereco>
    {
        public override void Map(EntityTypeBuilder<TipoEndereco> builder)
        {
            builder.Property(e => e.Nome).HasColumnType("varchar(50)");
            builder.Property(e => e.DateInsert).HasColumnType("datetime");

            builder.ToTable("TipoEndereco");

            builder.HasOne(e => e.ApplicationUser)
                .WithMany(o => o.TipoEndereco)
                .HasForeignKey(e => e.IdInsertUser).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
