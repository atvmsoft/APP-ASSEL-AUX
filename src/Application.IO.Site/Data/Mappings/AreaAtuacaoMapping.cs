using Application.IO.Site.Extensions;
using Application.IO.Site.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.IO.Site.Data.Mappings
{
    public class AreaAtuacaoMapping : EntityTypeConfiguration<AreaAtuacao>
    {
        public override void Map(EntityTypeBuilder<AreaAtuacao> builder)
        {
            builder.Property(e => e.Nome).HasColumnType("varchar(200)");
            builder.Property(e => e.DateInsert).HasColumnType("datetime");

            builder.ToTable("AreaAtuacao");

            builder.HasOne(e => e.ApplicationUser)
                .WithMany(o => o.AreaAtuacao)
                .HasForeignKey(e => e.IdInsertUser).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
