using Application.IO.Site.Extensions;
using Application.IO.Site.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.IO.Site.Data.Mappings
{
    public class SituacaoMapping : EntityTypeConfiguration<Situacao>
    {
        public override void Map(EntityTypeBuilder<Situacao> builder)
        {
            builder.Property(e => e.Nome).HasColumnType("varchar(100)");
            builder.Property(e => e.Date).HasColumnType("datetime");

            builder.ToTable("Situacao");

            builder.HasOne(e => e.ApplicationUser)
                .WithMany(o => o.Situacao)
                .HasForeignKey(e => e.IdUser).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
