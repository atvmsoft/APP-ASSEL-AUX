using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.IO.Site.Extensions
{
    public abstract class EntityTypeConfiguration<TEntity> where TEntity : class
    {
        public abstract void Map(EntityTypeBuilder<TEntity> builder);
    }
}
