using Application.IO.Site.Extensions;
using Application.IO.Site.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.IO.Site.Data.Mappings
{
    public class TipoContatoMapping : EntityTypeConfiguration<TipoContato>
    {
        public override void Map(EntityTypeBuilder<TipoContato> builder)
        {
            builder.Property(e => e.Nome).HasColumnType("varchar(50)");
            builder.Property(e => e.Formato).HasColumnType("varchar(20)");
            builder.Property(e => e.DateInsert).HasColumnType("datetime");

            builder.ToTable("TipoContato");

            builder.HasOne(e => e.ApplicationUser)
                .WithMany(o => o.TipoContato)
                .HasForeignKey(e => e.IdInsertUser).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
